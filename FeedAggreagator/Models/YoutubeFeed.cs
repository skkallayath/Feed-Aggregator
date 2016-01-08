namespace Suyati.FeedAggreagator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using XmlExtractor;

    /// <summary>
    /// The Youtube Feed
    /// </summary>
    public class YoutubeFeed : IFeed
    {
        /// <summary>
        /// The Links
        /// </summary>
        [Element(Name = "link")]
        public IList<AtomFeedLink> Links { get; set; }

        /// <summary>
        /// The Id
        /// </summary>
        [Element(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The Youtube Channel Id
        /// </summary>
        [Element(Name = "yt:channelId")]
        public string YoutubeChannelId { get; set; }

        /// <summary>
        /// The Title
        /// </summary>
        [Element(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The Author
        /// </summary>
        [Element(Name = "author")]
        public YoutubeFeedAuthor Author { get; set; }

        /// <summary>
        /// The Published
        /// </summary>
        [Element(Name = "published")]
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// The Entry
        /// </summary>
        [Element(Name = "entry")]
        public IList<YoutubeFeedItem> Items { get; set; }

        /// <summary>
        /// The Feed Type
        /// </summary>
        public FeedType Type
        {
            get { return FeedType.YouTube; }
        }

        /// <summary>
        /// The Description
        /// </summary>
        public string Description
        {
            get
            {
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
                if (Links != null && Links.Count > 0)
                {
                    var link = this.Links.FirstOrDefault(l => l.Rel.Equals("self"));
                    if (link != null)
                    {
                        return link.Href;
                    }
                    link = this.Links.FirstOrDefault(l => l.Rel.Equals("alternate"));
                    if (link != null)
                    {
                        return link.Href;
                    }
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
                return null;
            }
        }

        /// <summary>
        /// The Items
        /// </summary>
        IList<IFeedItem> IFeed.Items
        {
            get
            {
                IList<IFeedItem> list = new List<IFeedItem>();
                if (this.Items != null)
                {
                    foreach (IFeedItem item in this.Items)
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
        public DateTime? LastUpdatedDate
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// The Author Name
        /// </summary>
        public string AuthorName
        {
            get
            {
                if (this.Author != null)
                {
                    return this.Author.Name;
                }
                return null;
            }
        }
    }

    /// <summary>
    /// The Youtube Feed Item
    /// </summary>
    public class YoutubeFeedItem : IFeedItem
    {
        /// <summary>
        /// The Id
        /// </summary>
        [Element(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The Youtube Video Id
        /// </summary>
        [Element(Name = "yt:videoId")]
        public string YoutubeVideoId { get; set; }

        /// <summary>
        /// The Youtube Channel Id
        /// </summary>
        [Element(Name = "yt:channelId")]
        public string YoutubeChannelId { get; set; }

        /// <summary>
        /// The Title
        /// </summary>
        [Element(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The Link
        /// </summary>
        [Element(Name = "link")]
        public AtomFeedLink Link { get; set; }

        /// <summary>
        /// The Author
        /// </summary>
        [Element(Name = "author")]
        public YoutubeFeedAuthor Author { get; set; }

        /// <summary>
        /// The Published Date
        /// </summary>
        [Element(Name = "published")]
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// The Updated Date
        /// </summary>
        [Element(Name = "updated")]
        public DateTime? LastUpdatedDate { get; set; }

        /// <summary>
        /// The Media Groups
        /// </summary>
        [Element(Name = "media:group")]
        public MediaRSSFeedItemMediaGroup MediaGroup { get; set; }

        /// <summary>
        /// The Description
        /// </summary>
        public string Description
        {
            get
            {
                if (MediaGroup != null)
                {
                    return MediaGroup.MediaDescription;
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
                if (Link != null)
                {
                    return Link.Href;
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
                if (MediaGroup != null)
                {
                    if (MediaGroup.MediaThumbnail != null)
                    {
                        return MediaGroup.MediaThumbnail.Url;
                    }
                }
                return null;
            }
        }
    }

    /// <summary>
    /// The Youtube Feed Media Community
    /// </summary>
    public class YoutubeFeedMediaCommunity
    {
        /// <summary>
        /// The Media Star Rating
        /// </summary>
        [Element(Name = "media:starRating")]
        public YoutubeFeedMediaStarRating MesiaStarRating { get; set; }

        /// <summary>
        /// The Media Statistics
        /// </summary>
        [Element(Name = "media:statistics")]
        public YoutubeFeedMediaStatistics MediaStatistics { get; set; }
    }

    /// <summary>
    /// The Youtube feed Media Star rating
    /// </summary>
    public class YoutubeFeedMediaStarRating
    {
        /// <summary>
        /// The Count
        /// </summary>
        [Property(Name = "count")]
        public long Count { get; set; }

        /// <summary>
        /// The Average
        /// </summary>
        [Property(Name = "average")]
        public double Average { get; set; }

        /// <summary>
        /// The min rating
        /// </summary>
        [Property(Name = "min")]
        public double Min { get; set; }

        /// <summary>
        /// The max rating
        /// </summary>
        [Property(Name = "max")]
        public double Max { get; set; }
    }

    /// <summary>
    /// The youtube media statistics
    /// </summary>
    public class YoutubeFeedMediaStatistics
    {
        /// <summary>
        /// The number of views
        /// </summary>
        [Property(Name = "views")]
        public long Views { get; set; }
    }

    /// <summary>
    /// The Youtube Feed Author
    /// </summary>
    public class YoutubeFeedAuthor
    {
        /// <summary>
        /// The Name
        /// </summary>
        [Element(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The URI
        /// </summary>
        [Element(Name = "uri")]
        public string Uri { get; set; }
    }
}
