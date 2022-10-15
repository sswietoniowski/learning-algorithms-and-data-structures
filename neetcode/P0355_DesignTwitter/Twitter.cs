namespace neetcode.P0355_DesignTwitter;

// https://leetcode.com/problems/design-twitter/
// https://youtu.be/pNichitDD2E
public class Twitter
{
    private static int count = 0;
    private readonly Dictionary<int, HashSet<int>> _follows;
    private readonly Dictionary<int, List<(int, int)>> _tweets;

    public Twitter()
    {
        _follows = new Dictionary<int, HashSet<int>>();
        _tweets = new Dictionary<int, List<(int, int)>>();
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!_tweets.ContainsKey(userId))
        {
            _tweets.Add(userId, new List<(int, int)>());
        }

        count++;
        _tweets[userId].Add((tweetId, count));
    }

    public IList<int> GetNewsFeed(int userId)
    {
        var result = new List<int>();

        var maxHeap = new PriorityQueue<int, int>();

        if (_follows.ContainsKey(userId))
        {
            foreach (var followee in _follows[userId])
            {
                if (_tweets.ContainsKey(followee))
                {
                    int index = _tweets[followee].Count - 1;
                    int counter = 0;

                    while (index >= 0 && counter < 10)
                    {
                        var (tweetId, count) = _tweets[followee][index];
                        maxHeap.Enqueue(tweetId, -count);
                        index--;
                        counter++;
                    }
                }
            }
        }

        if (_tweets.ContainsKey(userId))
        {
            int index = _tweets[userId].Count - 1;
            int counter = 0;
            
            while (index >= 0 && counter < 10)
            {
                var (tweetId, count) = _tweets[userId][index];
                maxHeap.Enqueue(tweetId, -count);
                index--;
                counter++;
            }
        }

        int i = 0;
        while (i < 10 && maxHeap.Count > 0)
        {
            var tweetId = maxHeap.Dequeue();
            result.Add(tweetId);
            i++;
        }

        return result;
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!_follows.ContainsKey(followerId))
        {
            _follows.Add(followerId, new HashSet<int>());
        }

        _follows[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (_follows.ContainsKey(followerId))
        {
            _follows[followerId].Remove(followeeId);
        }
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */