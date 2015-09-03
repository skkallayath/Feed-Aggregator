namespace Suyati.FeedAggreagator
{
    using System;
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
        public DateTime? Published { get; set; }

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
    }

    /// <summary>
    /// The Youtube Feed Item
    /// </summary>
    public class YoutubeFeedItem
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
        public DateTime? Published { get; set; }

        /// <summary>
        /// The Updated Date
        /// </summary>
        [Element(Name = "updated")]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// The Media Groups
        /// </summary>
        [Element(Name = "media:group")]
        public YoutubeFeedItemMediaGroup MediaGroup { get; set; }
    }

    /// <summary>
    /// The Youtube Feed Item Media Group
    /// </summary>
    public class YoutubeFeedItemMediaGroup
    {
        /// <summary>
        /// The Media Title
        /// </summary>
        [Element(Name = "media:title")]
        public string MediaTitle { get; set; }

        /// <summary>
        /// The Media Content
        /// </summary>
        [Element(Name = "media:content")]
        public YoutubeFeedMediaContent MediaContent { get; set; }

        /// <summary>
        /// The Media Thumbnail
        /// </summary>
        [Element(Name = "media:thumbnail")]
        public MeediaRSSFeedThumbnail MediaThumbnail { get; set; }

        /// <summary>
        /// The media description
        /// </summary>
        [Element(Name = "media:description")]
        public string MediaDescription { get; set; }

        /// <summary>
        /// The media Community
        /// </summary>
        [Element(Name = "media:community")]
        public YoutubeFeedMediaCommunity MediaCommunity { get; set; }
    }

    /// <summary>
    /// The youtube media Content
    /// </summary>
    public class YoutubeFeedMediaContent
    {
        /// <summary>
        /// The Type
        /// </summary>
        [Element(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The Width
        /// </summary>
        [Property(Name = "width")]
        public int Width { get; set; }

        /// <summary>
        /// The Height
        /// </summary>
        [Property(Name = "height")]
        public int Height { get; set; }

        /// <summary>
        /// the Url
        /// </summary>
        [Property(Name = "url")]
        public string Url { get; set; }
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
