namespace Suyati.FeedAggreagator
{
    using System;
    using System.Collections.Generic;
    using XmlExtractor;

    /// <summary>
    /// The RSS Feed
    /// </summary>
    public class RSSFeed : IFeed
    {
        /// <summary>
        /// The Feed Type
        /// </summary>
        public FeedType Type { get { return FeedType.RSS; } }

        /// <summary>
        /// The Version
        /// </summary>
        [Property(Name = "version")]
        public string Version { get; set; }

        /// <summary>
        /// The Channel
        /// </summary>
        [Element(Name = "channel")]
        public RSSFeedChannel Channel { get; set; }

        /// <summary>
        /// The Title
        /// </summary>
        public string Title
        {
            get
            {
                if (this.Channel != null)
                {
                    return Channel.Title;
                }
                return null;
            }
        }

        /// <summary>
        /// The Description
        /// </summary>
        public string Description
        {
            get
            {
                if (this.Channel != null)
                {
                    return Channel.Description;
                }
                return null;
            }
        }

        /// <summary>
        /// The Url
        /// </summary>
        public string Url
        {
            get
            {
                if (this.Channel != null)
                {
                    return Channel.Link;
                }
                return null;
            }
        }

        /// <summary>
        /// The Image Url
        /// </summary>
        public string ImageUrl
        {
            get
            {
                if (this.Channel != null)
                {
                    if (Channel.Image != null)
                    {
                        return Channel.Image.Url;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// The Items
        /// </summary>
        public IList<IFeedItem> Items
        {
            get
            {
                IList<IFeedItem> list = new List<IFeedItem>();
                if (Channel != null && Channel.Items != null)
                {
                    foreach (IFeedItem item in Channel.Items)
                    {
                        list.Add(item);
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// The Published Date
        /// </summary>
        public DateTime? PublishedDate
        {
            get
            {
                if (this.Channel != null)
                {
                    return Channel.PublishedDate;
                }
                return null;
            }
        }

        /// <summary>
        /// The Published Date
        /// </summary>
        public DateTime? LastUpdatedDate
        {
            get
            {
                if (this.Channel != null)
                {
                    return Channel.LastBuildDate;
                }
                return null;
            }
        }
    }

    /// <summary>
    /// The RSS Feed Channel
    /// </summary>
    public class RSSFeedChannel
    {
        #region Required RSS Channel Properties

        /// <summary>
        /// The Link
        /// </summary>
        [Element(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        [Element(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The Title
        /// </summary>
        [Element(Name = "title")]
        public string Title { get; set; }

        #endregion

        /// <summary>
        /// The Items
        /// </summary>
        [Element(Name = "item")]
        public IList<RSSFeedItem> Items { get; set; }

        #region Optional Properties

        /// <summary>
        /// The Language
        /// </summary>
        [Element(Name = "language")]
        public string Language { get; set; }

        /// <summary>
        /// The Copyright
        /// </summary>
        [Element(Name = "copyright")]
        public string Copyright { get; set; }

        /// <summary>
        /// The managing Editor
        /// </summary>
        [Element(Name = "managingEditor")]
        public string ManagingEditor { get; set; }

        /// <summary>
        /// The WebMaster
        /// </summary>
        [Element(Name = "webMaster")]
        public string webMaster { get; set; }

        /// <summary>
        /// The Published Date
        /// </summary>
        [Element(Name = "pubDate")]
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// The Last Build Date
        /// </summary>
        [Element(Name = "lastBuildDate")]
        public DateTime? LastBuildDate { get; set; }

        /// <summary>
        /// The List Of Categories
        /// </summary>
        [Element(Name = "category")]
        public IList<string> Categories { get; set; }

        /// <summary>
        /// The Generator Software
        /// </summary>
        [Element(Name = "generator")]
        public string Generator { get; set; }

        /// <summary>
        /// The Documentsation
        /// </summary>
        [Element(Name = "docs")]
        public string Documentation { get; set; }

        /// <summary>
        /// The RSS Cloud Service Info
        /// </summary>
        [Element(Name = "cloud")]
        public RSSCloudServiceInfo Cloud { get; set; }

        /// <summary>
        /// The Time To Live
        /// </summary>
        [Element(Name = "ttl")]
        public int? TimeToLive { get; set; }

        /// <summary>
        /// The Image
        /// </summary>
        [Element(Name = "image")]
        public RSSFeedImage Image { get; set; }

        /// <summary>
        /// The Text Input
        /// </summary>
        [Element(Name = "textInput")]
        public RSSTextInput TextInput { get; set; }

        /// <summary>
        /// The Skip Hours
        /// </summary>
        [Element(Name = "skipHours")]
        public string SkipHours { get; set; }

        /// <summary>
        /// The Skip Days
        /// </summary>
        [Element(Name = "skipDays")]
        public string SkipDays { get; set; }

        #endregion
    }

    /// <summary>
    /// RSS Feed Image
    /// </summary>
    public class RSSFeedImage
    {
        /// <summary>
        /// The Url
        /// </summary>
        [Element(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The Title
        /// </summary>
        [Element(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// the Link
        /// </summary>
        [Element(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// The width
        /// </summary>
        [Element(Name = "width")]
        public int Width { get; set; }

        /// <summary>
        /// The Height
        /// </summary>
        [Element(Name = "height")]
        public int Height { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        [Element(Name = "description")]
        public string Description { get; set; }
    }

    /// <summary>
    /// The RSS Cloud Service Info
    /// </summary>
    public class RSSCloudServiceInfo
    {
        /// <summary>
        /// The domain
        /// </summary>
        [Property(Name = "domain")]
        public string Domain { get; set; }

        /// <summary>
        /// The Port
        /// </summary>
        [Property(Name = "port")]
        public int Port { get; set; }

        /// <summary>
        /// The Register Procedure
        /// </summary>
        [Property(Name = "registerProcedure")]
        public sbyte RegisterProcedure { get; set; }

        /// <summary>
        /// The Protocol
        /// </summary>
        [Property(Name = "protocol")]
        public string Protocol { get; set; }
    }

    /// <summary>
    /// The RSSTextInput
    /// </summary>
    public class RSSTextInput
    {
        /// <summary>
        ///  The label of the Submit button in the text input area
        /// </summary>
        [Element(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Explains the text input area
        /// </summary>
        [Element(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The name of the text object in the text input area
        /// </summary>
        [Element(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The URL of the CGI script that processes text input requests
        /// </summary>
        [Element(Name = "link")]
        public string Link { get; set; }
    }

    /// <summary>
    /// The RSS feed Item
    /// </summary>
    public class RSSFeedItem : IFeedItem
    {
        /// <summary>
        /// The Title
        /// </summary>
        [Element(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// the Link
        /// </summary>
        [Element(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// The Description
        /// </summary>
        [Element(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The Author
        /// </summary>
        [Element(Name = "author")]
        public string Author { get; set; }

        /// <summary>
        /// The List Of Categories
        /// </summary>
        [Element(Name = "category")]
        public IList<RSSFeedCategory> Categories { get; set; }

        /// <summary>
        /// The Comments
        /// </summary>
        [Element(Name = "comments")]
        public string Comments { get; set; }

        /// <summary>
        /// The RSS Feed Enclosure
        /// </summary>
        [Element(Name = "enclosure")]
        public RSSFeedEnclosure Enclosure { get; set; }

        /// <summary>
        /// The RSS feed GUID
        /// </summary>
        [Element(Name = "guid")]
        public RSSFeedGUID GUID { get; set; }

        /// <summary>
        /// The Published Date
        /// </summary>
        [Element(Name = "pubDate")]
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// The RSS Feed Source
        /// </summary>
        [Element(Name = "source")]
        public RSSFeedSource Source { get; set; }

        /// <summary>
        /// The media content
        /// </summary>
        [Element(Name = "media:content")]
        public MediaRSSFeedContentMetadata MediaContent { get; set; }

        /// <summary>
        /// The content Encoded
        /// </summary>
        [Element(Name = "content:encoded")]
        public string ContentEncoded { get; set; }

        /// <summary>
        /// The Image
        /// </summary>
        [Element(Name = "image")]
        public RSSFeedImage Image { get; set; }

        /// <summary>
        /// The Thumbnail
        /// </summary>
        [Element(Name = "media:thumbnail")]
        public MediaRSSFeedThumbnail MediaThumbnail { get; set; }

        /// <summary>
        /// The Url
        /// </summary>
        public string Url
        {
            get
            {
                if (!string.IsNullOrEmpty(Link))
                {
                    return this.Link;
                }
                if (GUID != null)
                {
                    return GUID.Value;
                }
                return null;
            }
        }

        /// <summary>
        /// The ImageUrl
        /// </summary>
        public string ImageUrl
        {
            get
            {
                if (Image != null)
                {
                    return Image.Url;
                }

                if (MediaThumbnail != null)
                {
                    return MediaThumbnail.Url;
                }
                return null;
            }
        }
    }

    /// <summary>
    /// The RSS Feed Enclosure
    /// </summary>
    public class RSSFeedEnclosure
    {
        /// <summary>
        /// The URL
        /// </summary>
        [Property(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The Length
        /// </summary>
        [Property(Name = "length")]
        public int Length { get; set; }

        /// <summary>
        /// The Type
        /// </summary>
        [Property(Name = "type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// The RSS feed Source
    /// </summary>
    public class RSSFeedSource : ContentElement
    {
        /// <summary>
        /// The Url
        /// </summary>
        [Property(Name = "url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// The RSS Feed Category
    /// </summary>
    public class RSSFeedCategory : ContentElement
    {
        /// <summary>
        /// The Domain
        /// </summary>
        [Property(Name = "domain")]
        public string Domain { get; set; }
    }

    /// <summary>
    /// The RSS Feed GUID
    /// </summary>
    public class RSSFeedGUID : ContentElement
    {
        /// <summary>
        /// The is Permanenet Link
        /// </summary>
        [Property(Name = "isPermaLink")]
        public bool? IsPermaLink { get; set; }
    }
}
