namespace leetcode.P0359_LoggerRateLimiter;

public class Logger
{
    private readonly HashSet<string> _messages = new();
    private readonly Dictionary<string, int> _timestamps = new();

    public Logger()
    {
    }

    public bool ShouldPrintMessage(int timestamp, string message)
    {
        if (_messages.Contains(message) && timestamp - _timestamps[message] < 10)
        {
            return false;
        }
        else
        {
            _messages.Add(message);
            if (!_timestamps.ContainsKey(message))
                _timestamps.Add(message, timestamp);
            else
                _timestamps[message] = timestamp;
            return true;
        }
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */