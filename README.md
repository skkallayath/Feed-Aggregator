# Feed-Aggregator
[![Travis](https://travis-ci.org/skkallayath/Feed-Aggregator.svg?branch=master)](https://travis-ci.org/skkallayath/Feed-Aggregator) [![NuGet](http://img.shields.io/nuget/v/FeedAggregator.svg)](https://www.nuget.org/packages/FeedAggregator/) [![Downloads](http://img.shields.io/nuget/dt/FeedAggregator.svg)](https://www.nuget.org/packages/FeedAggregator/)

This nuget package will help you to get Feed contents from an URL. It supports RSS and Atom Feeds. 

##Installation

To install Feed-Aggregator, run the following command in the Package Manager Console

```sh
PM> Install-Package FeedAggregator
```

##Quick Start

It is recommended that you install FeedAggregator via NuGet.Or Add a reference to the FeedAggregator.dll

You can check a given url contains a valid feed 

```csharp
bool isValidFeed = SyndicationFeed.IsValidFeed(FeedUrl);
```

If a url has valid feed, you can follow the steps

1) Load The Feed From Url.

```csharp
SyndicationFeed syndicationFeed = new SyndicationFeed.Load(FeedUrl);
```

2) You can get the FeedType from the SyndicationFeed.
And You can type cast the Feed property to RSSFeed or AtomFeed or MediaRSSFeed or YouTubeFeed object according to the type

```csharp
FeedType type = syndicationFeed.FeedType;
if(type == FeedType.RSS)
{
  RSSFeed rss = (RSSFeed)syndicationFeed.Feed;
}
```

Or you can simply use it as IFeed which has Properties that are common to all feed types 

```csharp
IFeed feed = syndicationFeed.Feed;
var imageUrl = feed.ImageUrl;
var url = feed.Url;
var title = feed.Title;
var description = feed.Descriptions;
```

3) You can get the feed items also. The feed item will contain the common properties of various kind of feed items.

```csharp
foreach(IFeedItem item in feed.Items)
{
  var imageUrl = item.ImageUrl;
  var url = item.Url;
  var title = item.Title;
  var description = item.Descriptions;
}
```
