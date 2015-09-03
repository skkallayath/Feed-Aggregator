namespace Suyati.FeedAggreagator
{
    using System;
    using System.Net;
    using System.Xml;
    using XmlExtractor;

    /// <summary>
    /// The Syndication Feed
    /// </summary>
    public class SyndicationFeed
    {
        #region Properties

        /// <summary>
        /// The Feed Url
        /// </summary>
        public virtual string FeedUrl { get; protected set; }

        /// <summary>
        /// The FeedType
        /// </summary>
        public virtual FeedType FeedType { get; protected set; }

        /// <summary>
        /// The Feed
        /// </summary>
        public IFeed Feed { get; protected set; }

        /// <summary>
        /// The Feed XML Document
        /// </summary>
        private XmlDocument FeedXML { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// To check whether the feed Url is valid
        /// </summary>
        /// <param name="feedUrl"></param>
        /// <returns></returns>
        public static bool IsValidFeed(string feedUrl)
        {
            // Checking whether a valid URL
            if (!Uri.IsWellFormedUriString(feedUrl, UriKind.Absolute))
            {
                return false;
            }

            // Downloading content to check whether the URL exist
            string xml = string.Empty;
            try
            {
                xml = WebHelper.DownloadContent(feedUrl);
            }
            catch (WebException)
            {
                return false;
            }

            // Loading the content to check whether its an XML content
            var xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.LoadXml(xml);
            }
            catch (XmlException)
            {
                return false;
            }

            // Checking whether Atom/RSS Feed
            var xmlDocElement = xmlDoc.DocumentElement;
            if (xmlDocElement == null || (xmlDocElement.Name != "feed" && xmlDocElement.Name != "rss"))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// To Load The Syndication Feed
        /// </summary>
        /// <param name="feedUrl"></param>
        /// <returns></returns>
        public static SyndicationFeed Load(string feedUrl)
        {
            return new SyndicationFeed(feedUrl);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The private constructor
        /// </summary>
        /// <param name="feedUrl"></param>
        private SyndicationFeed(string feedUrl)
        {
            // Initializing
            Initialize(feedUrl);

            // Extracting Data
            ExtractData();
        }

        /// <summary>
        /// To extract Data
        /// </summary>
        private void ExtractData()
        {
            IFeed feed = null;
            switch (FeedType)
            {
                case FeedType.RSS:
                    feed = new RSSFeed();
                    break;
                case FeedType.YouTube:
                    feed = new YoutubeFeed();
                    break;
                case FeedType.Atom:
                    feed = new AtomFeed();
                    break;
                case FeedType.MediaRSS:
                    feed = new MediaRSSFeed();
                    break;
                default:
                    break;
            }
            if (feed != null)
            {
                feed.Extract(this.FeedXML.DocumentElement);
                this.Feed = feed;
            }
        }

        /// <summary>
        /// To initialize the Syndication Feed
        /// </summary>
        /// <param name="feedUrl"></param>
        private void Initialize(string feedUrl)
        {
            // Checking whether the url is valid
            if (!Uri.IsWellFormedUriString(feedUrl, UriKind.Absolute))
            {
                throw new ArgumentException("Invalid Feed Url");
            }

            // Setting the feed Url
            this.FeedUrl = feedUrl;

            // Loding the XML content
            LoadXml();

            // Setting the feed Type
            SetFeedType();
        }

        /// <summary>
        /// To load the xml content
        /// </summary>
        private void LoadXml()
        {
            this.FeedXML = new XmlDocument();
            string xml = WebHelper.DownloadContent(this.FeedUrl);
            this.FeedXML.LoadXml(xml);
        }

        /// <summary>
        /// To set the feed Type
        /// </summary>
        private void SetFeedType()
        {
            // If Atom
            if (this.FeedXML.DocumentElement.Name == "feed")
            {
                this.FeedType = FeedType.Atom;
                // Checking for Youtube Feed
                var schemaAttribute = FeedXML.DocumentElement.Attributes["xmlns:yt"];
                if (schemaAttribute != null)
                {
                    string schema = schemaAttribute.Value;
                    if (!string.IsNullOrEmpty(schema) && schema.StartsWith(@"http://www.youtube.com/xml/schemas/", StringComparison.InvariantCultureIgnoreCase))
                    {
                        FeedType = FeedType.YouTube;
                    }
                }
                return;
            }

            // If RSS
            if (this.FeedXML.DocumentElement.Name == "rss")
            {
                FeedType = FeedType.RSS;

                // Checking for Media RSS
                var schemaAttribute = FeedXML.DocumentElement.Attributes["xmlns:media"];
                if (schemaAttribute != null)
                {
                    string schema = schemaAttribute.Value;
                    if (!string.IsNullOrEmpty(schema) && schema.Equals(@"http://search.yahoo.com/mrss/", StringComparison.InvariantCultureIgnoreCase))
                    {
                        FeedType = FeedType.MediaRSS;
                    }
                }
                return;
            }

            // If not RSS/Atom
            throw new InvalidOperationException("Invalid Feed Format");
        }

        #endregion
    }
}
