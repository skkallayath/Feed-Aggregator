# Feed-Aggregator
Travis:    [![Travis](https://travis-ci.org/skkallayath/Feed-Aggregator.svg?branch=master)](https://travis-ci.org/skkallayath/Feed-Aggregator) 

This nuget package will help you to get Feed contents from an URL. It supports RSS and Atom Feeds. 

##Installation

To install Feed-Aggregator, run the following command in the Package Manager Console

```sh
PM> Install-Package FeedAggregator
```

##Quick Start

It is recommended that you install FeedAggregator via NuGet.Or Add a reference to the FeedAggregator.dll

1) Load The Feed From Url.

```csharp
SyndicationFeed syndicationFeed=new SyndicationFeed.Load(FeedUrl);
```

2) Get the FeedType from the SyndicationFeed

```csharp
FeedType type=sundicationFeed.Type;
```

3) Type cast the Feed property to RSSFeed or AtomFeed or MediaRSSFeed object according to the type

```csharp
RSSFeed rss=(RSSFeed)syndicationFeed.Feed;
```

Then you can get all properties of the Feed

You can also check a given url contains a valid feed 

```csharp
bool isValid=SyndicationFeed.IsValidFeed(FeedUrl);
```

