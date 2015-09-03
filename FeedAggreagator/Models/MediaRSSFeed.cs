namespace Suyati.FeedAggreagator
{
    using System;
    using System.Collections.Generic;
    using XmlExtractor;

    /// <summary>
    /// The Media RSS Feed
    /// </summary>
    public class MediaRSSFeed : IFeed
    {
        /// <summary>
        /// The Version
        /// </summary>
        [Property(Name = "version")]
        public string Version { get; set; }

        /// <summary>
        /// The Schema
        /// </summary>
        [Property(Name = "xmlns:media")]
        public string XMLNSMedia { get; set; }

        /// <summary>
        /// The Channel
        /// </summary>
        [Element(Name = "channel")]
        public MediaRSSChannel Channel { get; set; }

        /// <summary>
        /// The FeedType
        /// </summary>
        public FeedType Type
        {
            get { return FeedType.MediaRSS; }
        }
    }

    /// <summary>
    /// The MeidaRSS Channel
    /// </summary>
    public class MediaRSSChannel
    {
        /// <summary>
        /// The Title
        /// </summary>
        [Element(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The Link
        /// </summary>
        [Element(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// The Description
        /// </summary>
        [Element(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The Language
        /// </summary>
        [Element(Name = "language")]
        public string Language { get; set; }

        /// <summary>
        /// The copy right
        /// </summary>
        [Element(Name = "copyright")]
        public string Copyright { get; set; }

        /// <summary>
        /// The published Date
        /// </summary>
        [Element(Name = "pubDate")]
        public string PublishedDate { get; set; }

        /// <summary>
        /// The Generator
        /// </summary>
        [Element(Name = "generator")]
        public string Generator { get; set; }

        /// <summary>
        /// The Documentation
        /// </summary>
        [Element(Name = "docs")]
        public string Documentation { get; set; }

        /// <summary>
        /// The Icon
        /// </summary>
        [Element(Name = "atom:icon")]
        public string Icon { get; set; }

        /// <summary>
        /// The Atom Links
        /// </summary>
        [Element(Name = "atom:link")]
        public IList<AtomFeedLink> AtomLinks { get; set; }

        /// <summary>
        /// The list of Items
        /// </summary>
        [Element(Name = "item")]
        public IList<MediaRSSFeedItem> Items { get; set; }
    }

    /// <summary>
    /// The MediaRSS FeedItem
    /// </summary>
    public class MediaRSSFeedItem
    {
        /// <summary>
        /// The Title
        /// </summary>
        [Element(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The Link
        /// </summary>
        [Element(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// The Published Date
        /// </summary>
        [Element(Name = "pubDate")]
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// The GUID
        /// </summary>
        [Element(Name = "guid")]
        public RSSFeedGUID GUID { get; set; }

        /// <summary>
        /// The Description
        /// </summary>
        [Element(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The Midea Content Metadata
        /// </summary>
        [Element(Name = "media:content")]
        public MediaRSSFeedContentMetadata MediaContent { get; set; }

        /// <summary>
        /// The Media Thumbnail
        /// </summary>
        [Element(Name = "thumbnail")]
        public IList<MeediaRSSFeedThumbnail> MediaThumbnails { get; set; }

        /// <summary>
        /// The Media Keywords
        /// </summary>
        [Element(Name = "keywords")]
        public string MediaKeywords { get; set; }

        /// <summary>
        /// The list of categories
        /// </summary>
        [Element(Name = "media:category")]
        public IList<MediaRSSFeedCategory> MediaCategories { get; set; }

        /// <summary>
        /// The Media Rating
        /// </summary>
        [Element(Name = "media:rating")]
        public string MediaRating { get; set; }

        /// <summary>
        /// The Media Credits
        /// </summary>
        [Element(Name = "media:credit")]
        public IList<MediaRSSCredit> MediaCredits { get; set; }

        /// <summary>
        /// The Media Title
        /// </summary>
        [Element(Name = "media:title")]
        public MediaRSSFeedContent MediaTitle { get; set; }

        /// <summary>
        /// The Media Description
        /// </summary>
        [Element(Name = "media:description")]
        public MediaRSSFeedContent MediaDescription { get; set; }

        /// <summary>
        /// The copyright
        /// </summary>
        [Element(Name = "media:copyright")]
        public MediaRSSFeedCopyrightInfo Copyright { get; set; }

        /// <summary>
        /// The Media Text
        /// </summary>
        [Element(Name = "media:text")]
        public MediaRSSFeedContent MediaText { get; set; }

        /// <summary>
        /// The View Count
        /// </summary>
        [Element(Name = "viewCount")]
        public long Viewcount { get; set; }

        /// <summary>
        /// The Embed HTML
        /// </summary>
        [Element(Name = "embedHtml")]
        public string EmbedHtml { get; set; }

        /// <summary>
        /// The Restriction
        /// </summary>
        [Element(Name = "restriction")]
        public MediaRSSRestriction Restriction { get; set; }

        /// <summary>
        /// The Expire Date
        /// </summary>
        [Element(Name = "expireDate")]
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// The Payment Info
        /// </summary>
        [Element(Name = "payment")]
        public MediaRSSFeedPaymentInfo Payment { get; set; }
    }

    /// <summary>
    /// The MediaRSS Copyright Info
    /// </summary>
    public class MediaRSSFeedCopyrightInfo : ContentElement
    {
        /// <summary>
        /// The Url
        /// </summary>
        [Property(Name = "url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// The MediaRSS Feed Content
    /// </summary>
    public class MediaRSSFeedContent : ContentElement
    {
        /// <summary>
        /// The Type
        /// </summary>
        [Property(Name = "type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// The MediaRSS Credit
    /// </summary>
    public class MediaRSSCredit : ContentElement
    {
        /// <summary>
        /// The Role
        /// </summary>
        [Property(Name = "role")]
        public string Role { get; set; }

        /// <summary>
        /// The Scheme
        /// </summary>
        [Property(Name = "scheme")]
        public string Scheme { get; set; }
    }

    /// <summary>
    /// The MediaRSS Payment Info
    /// </summary>
    public class MediaRSSFeedPaymentInfo
    {
        /// <summary>
        /// The Type
        /// </summary>
        [Property(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The Price
        /// </summary>
        [Property(Name = "price")]
        public double Price { get; set; }

        /// <summary>
        /// The Currency
        /// </summary>
        [Property(Name = "currency")]
        public string Currency { get; set; }
    }

    /// <summary>
    /// The MediaRSS Feed Content Metadata
    /// </summary>
    public class MediaRSSFeedContentMetadata
    {
        /// <summary>
        /// The URL
        /// </summary>
        [Property(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The Type
        /// </summary>
        [Property(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The medium
        /// </summary>
        [Property(Name = "medium")]
        public string Medium { get; set; }

        /// <summary>
        /// The Height
        /// </summary>
        [Property(Name = "height")]
        public int Height { get; set; }

        /// <summary>
        /// The Width
        /// </summary>
        [Property(Name = "width")]
        public int Width { get; set; }

        /// <summary>
        /// The Duration
        /// </summary>
        [Property(Name = "duration")]
        public long Duration { get; set; }

        /// <summary>
        /// The File Size
        /// </summary>
        [Property(Name = "fileSize")]
        public long FileSize { get; set; }

        /// <summary>
        /// The Bit Rate
        /// </summary>
        [Property(Name = "bitrate")]
        public int BitRate { get; set; }
    }

    /// <summary>
    /// The Medis RSS Feed Thumbnail
    /// </summary>
    public class MeediaRSSFeedThumbnail
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
    /// The MediaRSS restrictions
    /// </summary>
    public class MediaRSSRestriction : ContentElement
    {
        /// <summary>
        /// The relationship
        /// </summary>
        [Property(Name = "relationship")]
        public string Relationship { get; set; }

        /// <summary>
        /// The Type
        /// </summary>
        [Property(Name = "type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// The Media RSS Feed Category
    /// </summary>
    public class MediaRSSFeedCategory : ContentElement
    {
        /// <summary>
        /// The Label
        /// </summary>
        [Property(Name = "label")]
        public string Label { get; set; }
    }
}
