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
                    if (Channel.Description != null)
                    {
                        return Channel.Description;
                    }
                    return Channel.MediaDescription;
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
        /// The ImageUrl
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
                    if (string.IsNullOrEmpty(Channel.Icon))
                    {
                        return Channel.Icon;
                    }
                    if (Channel.MediaThumbnail != null)
                    {
                        return Channel.MediaThumbnail.Url;
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
        public DateTime? PublishedDate { get; set; }

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
        /// The Media Thumbnail
        /// </summary>
        [Element(Name = "media:thumbnail")]
        public MediaRSSFeedThumbnail MediaThumbnail { get; set; }

        /// <summary>
        /// The Image
        /// </summary>
        [Element(Name = "image")]
        public RSSFeedImage Image { get; set; }

        /// <summary>
        /// The Media CopyRight
        /// </summary>
        [Element(Name = "media:copyright")]
        public string MediaCopyright { get; set; }

        /// <summary>
        /// The Media CopyRight
        /// </summary>
        [Element(Name = "media:rating")]
        public MediaRSSRating MediaRating { get; set; }

        /// <summary>
        /// The Last build date
        /// </summary>
        [Element(Name = "lastBuildDate")]
        public DateTime? LastBuildDate { get; set; }

        /// <summary>
        /// The Time To Live
        /// </summary>
        [Element(Name = "ttl")]
        public long TimeToLive { get; set; }

        /// <summary>
        /// The Atom Links
        /// </summary>
        [Element(Name = "atom:link")]
        public IList<AtomFeedLink> AtomLinks { get; set; }

        /// <summary>
        /// The Media Description
        /// </summary>
        [Element(Name = "media:description")]
        public string MediaDescription { get; set; }

        /// <summary>
        /// The CloudService Info
        /// </summary>
        [Element(Name = "cloud")]
        public RSSCloudServiceInfo Cloud { get; set; }

        /// <summary>
        /// The list of Items
        /// </summary>
        [Element(Name = "item")]
        public IList<MediaRSSFeedItem> Items { get; set; }
    }

    /// <summary>
    /// The media RSS Rating
    /// </summary>
    public class MediaRSSRating : ContentElement
    {
        /// <summary>
        /// The Content Element
        /// </summary>
        [Property(Name = "scheme")]
        public string Scheme { get; set; }
    }

    /// <summary>
    /// The MediaRSS Feed Item Media Group
    /// </summary>
    public class MediaRSSFeedItemMediaGroup
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
        public IList<MediaRSSFeedMediaContent> MediaContentList { get; set; }

        /// <summary>
        /// The Media Thumbnail
        /// </summary>
        [Element(Name = "media:thumbnail")]
        public MediaRSSFeedThumbnail MediaThumbnail { get; set; }

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
    /// The Media RSS Feed media Content
    /// </summary>
    public class MediaRSSFeedMediaContent
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
    /// The MediaRSS FeedItem
    /// </summary>
    public class MediaRSSFeedItem : IFeedItem
    {
        /// <summary>
        /// The Comments
        /// </summary>
        [Element(Name = "comments")]
        public string Comments { get; set; }

        /// <summary>
        /// The Author
        /// </summary>
        [Element(Name = "author")]
        public string Author { get; set; }

        /// <summary>
        /// The Source
        /// </summary>
        [Element(Name = "source")]
        public RSSFeedSource Source { get; set; }

        /// <summary>
        /// The media Group
        /// </summary>
        [Element(Name = "media:group")]
        public MediaRSSFeedItemMediaGroup MediaGroup { get; set; }

        /// <summary>
        /// The Content Encoded
        /// </summary>
        [Element(Name = "content:encoded")]
        public string ContentEncoded { get; set; }

        /// <summary>
        /// The Content Thumbnail
        /// </summary>
        [Element(Name = "content:thumbnail")]
        public MediaRSSFeedThumbnail ContentThumbnail { get; set; }

        /// <summary>
        /// The Atom Links
        /// </summary>
        [Element(Name = "atom:link")]
        public IList<AtomFeedLink> AtomLinks { get; set; }

        /// <summary>
        /// The categories
        /// </summary>
        [Element(Name = "category")]
        public IList<string> Categories { get; set; }

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
        [Element(Name = "media:thumbnail")]
        public IList<MediaRSSFeedThumbnail> MediaThumbnails { get; set; }

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

        /// <summary>
        /// The Url
        /// </summary>
        public string Url
        {
            get { return this.Link; }
        }

        /// <summary>
        /// The ImageUrl
        /// </summary>
        public string ImageUrl
        {
            get
            {
                if (this.ContentThumbnail != null)
                {
                    return ContentThumbnail.Url;
                }
                if (this.MediaThumbnails != null && this.MediaThumbnails.Count > 0)
                {
                    return this.MediaThumbnails[0].Url;
                }
                if (MediaContent != null)
                {
                    return MediaContent.Url;
                }
                return null;
            }
        }
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
    public class MediaRSSFeedThumbnail : ContentElement
    {
        /// <summary>
        /// The Type
        /// </summary>
        [Property(Name = "type")]
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
