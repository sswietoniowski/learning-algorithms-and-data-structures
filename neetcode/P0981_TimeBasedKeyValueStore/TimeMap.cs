namespace neetcode.P0981_TimeBasedKeyValueStore
{
    // https://leetcode.com/problems/time-based-key-value-store/
    // https://youtu.be/fu2cD_6E8Hw
    public class TimeMap
    {
        private readonly Dictionary<string, List<(string, int)>> _store;


        public TimeMap()
        {
            _store = new Dictionary<string, List<(string, int)>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (!_store.ContainsKey(key))
            {
                _store.Add(key, new());
            }

            _store[key].Add((value, timestamp));
        }

        public string Get(string key, int timestamp)
        {
            string result = string.Empty;

            if (_store.ContainsKey(key))
            {
                var list = _store[key];
                int left = 0;
                int right = list.Count - 1;

                while (left <= right)
                {
                    int midle = (left + right) / 2;
                    if (list[midle].Item2 <= timestamp)
                    {
                        result = list[midle].Item1;
                        left = midle + 1;
                    }
                    else
                    {
                        right = midle - 1;
                    }
                }
            }

            return result;
        }
    }

    /**
     * Your TimeMap object will be instantiated and called as such:
     * TimeMap obj = new TimeMap();
     * obj.Set(key,value,timestamp);
     * string param_2 = obj.Get(key,timestamp);
     */
}
