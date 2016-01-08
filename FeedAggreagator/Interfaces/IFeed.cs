namespace Suyati.FeedAggreagator
{
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// The interface to the Feed
    /// </summary>
    public interface IFeed
    {
        /// <summary>
        /// The Feed Type
        /// </summary>
        FeedType Type { get; }

        /// <summary>
        /// The Title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// The Description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The Url
        /// </summary>
        string Url { get; }

        /// <summary>
        /// The image Url
        /// </summary>
        string ImageUrl { get; }

        /// <summary>
        /// The Items
        /// </summary>
        IList<IFeedItem> Items { get; }

        /// <summary>
        /// The Published Date
        /// </summary>
        DateTime? PublishedDate { get; }

        /// <summary>
        /// The Last Updated Date
        /// </summary>
        DateTime? LastUpdatedDate { get; }

        /// <summary>
        /// The Author Name
        /// </summary>
        string AuthorName { get; }
    }
}
