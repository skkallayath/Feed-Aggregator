namespace Suyati.FeedAggreagator
{
    /// <summary>
    /// The interface to the Feed
    /// </summary>
    public interface IFeed
    {
        /// <summary>
        /// The Feed Type
        /// </summary>
        FeedType Type { get; }
    }
}
