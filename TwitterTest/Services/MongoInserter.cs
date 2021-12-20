﻿using MongoDB.Driver;
using Tweetinvi.Models.V2;

namespace TwitterTest.Services;

public interface IMongoInserter
{
    Task InsertTweetAsync(TweetV2 tweet);
}

public class MongoNullInserter : IMongoInserter
{

    public Task InsertTweetAsync(TweetV2 tweet)
    {
        return Task.CompletedTask;
    }

}

public class MongoInserter : IMongoInserter
{
    private IMongoCollection<TweetV2> _tweetCollection;

    public MongoInserter(IMongoClient mongoDatabase)
    {
        _tweetCollection = mongoDatabase.GetTweetCollection();
    }

    public Task InsertTweetAsync(TweetV2 tweet)
    {
        return _tweetCollection.InsertOneAsync(tweet);
    }
}
