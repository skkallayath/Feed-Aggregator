namespace Suyati.FeedAggreagator
{
    using System;
    using System.Collections.Generic;
    using XmlExtractor;

    /// <summary>
    /// The Atom Feed
    /// </summary>
    public class AtomFeed : IFeed
    {
        /// <summary>
        /// The FeedType
        /// </summary>
        public FeedType Type { get { return FeedType.Atom; } }

        #region Required Atom Feed Properties

        /// <summary>
        /// The Id
        /// </summary>
        [Element(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The Title
        /// </summary>
        [Element(Name = "title")]
        public AtomFeedContent Title { get; set; }

        /// <summary>
        /// The Updated
        /// </summary>
        [Element(Name = "updated")]
        public DateTime Updated { get; set; }

        #endregion

        #region Optional Properties

        /// <summary>
        /// The Author
        /// </summary>
        [Element(Name = "author")]
        public AtomFeedPerson Author { get; set; }

        /// <summary>
        /// The Link
        /// </summary>
        [Element(Name = "link")]
        public AtomFeedLink Link { get; set; }

        /// <summary>
        /// The list of categories
        /// </summary>
        [Element(Name = "category")]
        public IList<AtomFeedCategory> Categories { get; set; }

        /// <summary>
        /// The List of Contributors
        /// </summary>
        [Element(Name = "contributor")]
        public IList<AtomFeedPerson> Contributors { get; set; }

        /// <summary>
        /// The Feed Generator
        /// </summary>
        [Element(Name = "generator")]
        public AtomFeedGenerator Generator { get; set; }

        /// <summary>
        /// The Icon Image Url
        /// </summary>
        [Element(Name = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// The Logo Image Url
        /// </summary>
        [Element(Name = "logo")]
        public string Logo { get; set; }

        /// <summary>
        /// The Copy Right
        /// </summary>
        [Element(Name = "rights")]
        public AtomFeedContent Rights { get; set; }

        /// <summary>
        /// The SubTitle Or Description
        /// </summary>
        [Element(Name = "subtitle")]
        public string SubTitle { get; set; }

        #endregion

        /// <summary>
        /// The list of Items
        /// </summary>
        [Element(Name = "entry")]
        public IList<AtomFeedItem> Items { get; set; }
    }

    /// <summary>
    /// The AtomFeed Item
    /// </summary>
    public class AtomFeedItem
    {
        #region Required Properties

        /// <summary>
        /// The Id
        /// </summary>
        [Element(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        [Element(Name = "title")]
        public AtomFeedContent Title { get; set; }

        /// <summary>
        /// The Updated
        /// </summary>
        [Element(Name = "updated")]
        public DateTime Updated { get; set; }

        #endregion

        #region Optional Properties

        /// <summary>
        /// the Author
        /// </summary>
        [Element(Name = "author")]
        public AtomFeedPerson Author { get; set; }

        /// <summary>
        /// The Content
        /// </summary>
        [Element(Name = "content")]
        public AtomFeedContent Content { get; set; }

        /// <summary>
        /// The Link
        /// </summary>
        [Element(Name = "link")]
        public AtomFeedLink Link { get; set; }

        /// <summary>
        /// The Summary
        /// </summary>
        [Element(Name = "summary")]
        public AtomFeedContent Summary { get; set; }

        /// <summary>
        /// The categories
        /// </summary>
        [Element(Name = "category")]
        public IList<AtomFeedCategory> Categories { get; set; }

        /// <summary>
        /// The Published Date
        /// </summary>
        [Element(Name = "published")]
        public DateTime? Published { get; set; }

        /// <summary>
        /// The Source
        /// </summary>
        [Element(Name = "source")]
        public AtomFeedSource Source { get; set; }

        /// <summary>
        /// The copyright info
        /// </summary>
        [Element(Name = "rights")]
        public AtomFeedContent Rights { get; set; }

        #endregion
    }

    /// <summary>
    /// The Atom Feed Person
    /// </summary>
    public class AtomFeedPerson : NamedEntity
    {
        /// <summary>
        /// The Email
        /// </summary>
        [Element(Name = ("email"))]
        public string Email { get; set; }

        /// <summary>
        /// The Url
        /// </summary>
        [Element(Name = "url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// The Atom Feed Category
    /// </summary>
    public class AtomFeedCategory
    {
        /// <summary>
        /// The Term
        /// </summary>
        [Property(Name = "term")]
        public string Term { get; set; }

        /// <summary>
        /// The scheme
        /// </summary>
        [Property(Name = "scheme")]
        public string Scheme { get; set; }

        /// <summary>
        /// The Label
        /// </summary>
        [Property(Name = "label")]
        public string Label { get; set; }
    }

    /// <summary>
    /// the Atom feed generator
    /// </summary>
    public class AtomFeedGenerator : ContentElement
    {
        /// <summary>
        /// The version
        /// </summary>
        [Property(Name = "version")]
        public string Version { get; set; }

        /// <summary>
        /// The URI
        /// </summary>
        [Property(Name = "uri")]
        public string Url { get; set; }
    }

    /// <summary>
    /// The Atom Feed Resource Base
    /// </summary>
    public class AtomFeedResourceBase
    {
        /// <summary>
        /// The Id
        /// </summary>
        [Element(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The Title
        /// </summary>
        [Element(Name = "title")]
        public AtomFeedContent Title { get; set; }

        /// <summary>
        /// The Updated
        /// </summary>
        [Element(Name = "updated")]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// The Rights
        /// </summary>
        [Element(Name = "rights")]
        public AtomFeedContent Rights { get; set; }
    }

    /// <summary>
    /// The Atom feed Source Base
    /// </summary>
    public class AtomFeedSource : AtomFeedResourceBase
    {

    }

    /// <summary>
    /// The Atom Feed Content
    /// </summary>
    public class AtomFeedContent : ContentElement
    {
        /// <summary>
        /// The Type
        /// </summary>
        [Property(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The Sorce
        /// </summary>
        [Property(Name = "src")]
        public string Src { get; set; }
    }

    /// <summary>
    /// The Atom Feed link
    /// </summary>
    public class AtomFeedLink
    {
        /// <summary>
        /// The Href
        /// </summary>
        [Property(Name = "href")]
        public string Href { get; set; }

        /// <summary>
        /// The rel contains a single link relationship type. It can be a full URI (see extensibility), or one of the following predefined values (default=alternate):
        /// alternate: an alternate representation of the entry or feed, for example a permalink to the html version of the entry, or the front page of the weblog.
        /// enclosure: a related resource which is potentially large in size and might require special handling, for example an audio or video recording.
        /// related: an document related to the entry or feed.
        /// self: the feed itself.
        /// via: the source of the information provided in the entry.
        /// </summary>
        [Property(Name = "rel")]
        public string Rel { get; set; }

        /// <summary>
        /// The Type
        /// </summary>
        [Property(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The Href Language
        /// </summary>
        [Property(Name = "hreflang")]
        public string HrefLang { get; set; }

        /// <summary>
        /// The Title
        /// </summary>
        [Element(Name = "title")]
        public AtomFeedContent Title { get; set; }

        /// <summary>
        /// The Length
        /// </summary>
        [Element(Name = "length")]
        public long? Length { get; set; }

        /// <summary>
        /// To String 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Href;
        }
    }
}
