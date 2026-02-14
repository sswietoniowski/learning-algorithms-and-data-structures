namespace neetcode.P1472_DesignBrowserHistory;

public class BrowserHistory
{
    private List<string> history;
    private int currIndex;
    private int maxIndex;

    public BrowserHistory(string homepage)
    {
        history = new List<string>();
        history.Add(homepage);
        currIndex = 0;
        maxIndex = 0;
    }

    public void Visit(string url)
    {
        currIndex++;

        if (currIndex < history.Count)
        {
            history[currIndex] = url;
        }
        else
        {
            history.Add(url);
        }

        maxIndex = currIndex;
    }

    public string Back(int steps)
    {
        currIndex = Math.Max(0, currIndex - steps);
        return history[currIndex];
    }

    public string Forward(int steps)
    {
        currIndex = Math.Min(maxIndex, currIndex + steps);
        return history[currIndex];
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */
