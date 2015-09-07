namespace Suyati.FeedAggreagator
{
    using System;

    public interface IFeedItem
    {
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
        /// The Published Date
        /// </summary>
        DateTime? PublishedDate { get; }
    }
}
