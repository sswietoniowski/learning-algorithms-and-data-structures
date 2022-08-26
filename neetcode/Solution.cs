using System.Text;

namespace neetcode
{
    public class Solution
    {
        // https://leetcode.com/problems/contains-duplicate/
        // https://youtu.be/3OamzN90kPg
        public bool ContainsDuplicate(int[] nums)
        {
            // v1
            //bool result = false;

            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        if (nums[i] == nums[j])
            //        {
            //            result = true;
            //            break;
            //        }
            //    }

            //    if (result)
            //    {
            //        break;
            //    }
            //}

            //return result;

            // v2
            //var numsSet = new HashSet<int>();

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (numsSet.Contains(nums[i]))
            //    {
            //        return true;
            //    }

            //    numsSet.Add(nums[i]);
            //}

            //return false;

            // v3
            //var numsDict = new Dictionary<int, int>();

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    var exists = !numsDict.TryAdd(nums[i], 1);
            //    if (exists)
            //    {
            //        return true;
            //    }
            //}

            //return false;

            // v4
            Array.Sort(nums);

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    return true;
                }
            }

            return false;
        }


        // https://leetcode.com/problems/group-anagrams/
        // https://youtu.be/vzdNOK2oB2E
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();
            var wordsSet = new HashSet<string>();
            var anagramsDictionary = new Dictionary<string, IList<string>>();

            foreach (var word in strs)
            {
                char[] chars = word.ToCharArray();
                Array.Sort(chars);
                var key = new String(chars);
                if (!wordsSet.Contains(key))
                {
                    wordsSet.Add(key);
                    anagramsDictionary[key] = new List<string>();
                }

                anagramsDictionary[key].Add(word);
            }

            foreach (var kvp in anagramsDictionary)
            {
                result.Add(kvp.Value);
            }

            return result;
        }

        // https://leetcode.com/problems/valid-anagram/
        // https://youtu.be/9UtInBqnCgA
        public bool IsAnagram(string s, string t)
        {
            // v1
            //if (s.Length != t.Length)
            //{
            //    return false;
            //}

            //int[] counters = new int[26];

            //for (int i = 0; i < s.Length; i++)
            //{
            //    counters[s[i] - 'a']++;
            //    counters[t[i] - 'a']--;
            //}

            //foreach (int counter in counters)
            //{
            //    if (counter != 0)
            //    {
            //        return false;
            //    }
            //}

            //return true;

            // v2
            var sArr = s.ToCharArray();
            Array.Sort(sArr);
            var tArr = t.ToCharArray();
            Array.Sort(tArr);
            return new String(sArr) == new String(tArr);
        }

        // https://leetcode.com/problems/two-sum/
        // https://youtu.be/KLlXCFG5TnA
        public int[] TwoSum(int[] nums, int target)
        {
            // v1
            //int[] result = new int[2];
            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        if (nums[i] + nums[j] == target)
            //        {
            //            result[0] = i;
            //            result[1] = j;
            //            return result;
            //        }
            //    }
            //}
            //return result;

            // v2
            Dictionary<int, int> mapping = new();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (mapping.ContainsKey(complement))
                {
                    return new int[] { mapping[complement], i };
                }

                if (!mapping.ContainsKey(nums[i]))
                {
                    mapping.Add(nums[i], i);
                }
            }

            return null;
        }

        // https://leetcode.com/problems/single-number/
        // https://youtu.be/qMPX1AOa83k
        public int SingleNumber(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            Dictionary<int, int> occurrences = new();

            for (int i = 0; i < nums.Length; i++)
            {
                if (occurrences.ContainsKey(nums[i]))
                {
                    occurrences[nums[i]] += 1;
                }
                else
                {
                    occurrences.Add(nums[i], 1);
                }
            }

            foreach (var kvp in occurrences)
            {
                if (kvp.Value == 1)
                {
                    return kvp.Key;
                }
            }

            throw new ArgumentException();
        }

        // https://leetcode.com/problems/number-of-1-bits/
        // https://youtu.be/5Km3utixwZs
        public int HammingWeight(uint n)
        {
            // v1
            //int counter = 0;
            //for (int i = 0; i < 32; i++)
            //{
            //    if ((n & (1 << i)) != 0)
            //    {
            //        counter++;
            //    }
            //}
            //return counter;
            // v2
            int counter = 0;
            int mask = 1;
            for (int i = 0; i < 32; i++)
            {
                if ((n & mask) != 0)
                {
                    counter++;
                }

                mask <<= 1;
            }

            return counter;
        }

        // https://leetcode.com/problems/reverse-bits/
        // https://youtu.be/UcoN6UjAI64
        // v1
        //public uint reverseBits(uint n)
        //{
        //    //uint result = 0;

        //    //uint inMask = 1;
        //    //uint outMask = (uint)1 << 31;
        //    //for (int i = 0; i < 32; i++)
        //    //{
        //    //    if ((n & inMask) != 0)
        //    //    {
        //    //        result |= outMask;
        //    //    }

        //    //    inMask <<= 1;
        //    //    outMask >>= 1;
        //    //}

        //    //return result;
        //}

        // v2
        private byte reverseByte(byte b)
        {
            return (byte)((((uint)b) * 0x0202020202 & 0x010884422010) % 1023);
        }

        public uint reverseBits(uint n)
        {
            uint result = 0;

            for (int i = 0; i < 4; i++)
            {
                byte b = (byte)((n >> (i * 8)) & 0xff);
                result += ((uint)reverseByte(b)) << ((3 - i) * 8);
            }

            return result;
        }


        // https://leetcode.com/problems/missing-number/
        // https://youtu.be/WnPLSRLSANE
        public int MissingNumber(int[] nums)
        {
            // v1
            //Array.Sort(nums);
            //int number = 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] != number)
            //    {
            //        return number;
            //    }
            //    number++;
            //}
            //return number;

            // v2
            int n = nums.Length;

            for (int i = 0; i < nums.Length; i++)
            {
                n ^= i ^ nums[i];
            }

            return n;
        }

        private string StripExtraCharacters(string s)
        {
            // v1
            //StringBuilder sb = new();

            //foreach (var ch in s.ToLower())
            //{
            //    if ((ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9'))
            //    {
            //        sb.Append(ch);
            //    }
            //}

            //return sb.ToString();

            StringBuilder sb = new();

            foreach (var ch in s.ToLower())
            {
                if (Char.IsLetterOrDigit(ch))
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

        // https://leetcode.com/problems/valid-palindrome/
        // https://youtu.be/jJXJ16kPFWg
        public bool IsPalindrome(string s)
        {
            var cleanedString = StripExtraCharacters(s);
            var length = cleanedString.Length;

            for (int i = 0; i < length / 2; i++)
            {
                if (cleanedString[i] != cleanedString[length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        // https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        // https://youtu.be/cQ1Oz4ckceM
        public int[] TwoSumII(int[] numbers, int target)
        {
            int i = 0;
            int j = numbers.Length - 1;

            while (true)
            {
                if (numbers[i] + numbers[j] == target)
                {
                    return new int[] { i + 1, j + 1 };
                }
                else if (numbers[i] + numbers[j] < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }

            return new int[] { -1, -1 };
        }

        // https://leetcode.com/explore/interview/card/google/67/sql-2/3044/
        public int NumUniqueEmails(string[] emails)
        {
            var uniqueEmails = new HashSet<string>();

            foreach (var email in emails)
            {
                string[] parts = email.Split('@');
                string username = parts[0];
                string domain = parts[1];
                int plusPosition = username.IndexOf('+');
                if (plusPosition > 0)
                {
                    username = username.Substring(0, plusPosition);
                }

                string rest = username;
                int dotPosition = rest.IndexOf('.');
                StringBuilder sb = new();
                while (dotPosition > 0)
                {
                    sb.Append(rest.Substring(0, dotPosition));
                    if (dotPosition < rest.Length - 1)
                    {
                        rest = rest.Substring(dotPosition + 1, rest.Length - dotPosition - 1);
                    }

                    dotPosition = rest.IndexOf('.');
                }

                if (rest.Length > 0)
                {
                    sb.Append(rest);
                }

                username = sb.ToString();
                uniqueEmails.Add($"{username}@{domain}");
            }

            return uniqueEmails.Count;
        }

        // https://leetcode.com/problems/evaluate-reverse-polish-notation/
        public int EvalRPN(string[] tokens)
        {
            var operators = new HashSet<string>() { "+", "-", "*", "/" };
            var stack = new Stack<int>();

            foreach (var token in tokens)
            {
                if (operators.Contains(token))
                {
                    int b = stack.Pop();
                    int a = stack.Pop();
                    int c = token switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => a / b,
                        _ => 0
                    };

                    stack.Push(c);
                }
                else
                {
                    stack.Push(int.Parse(token));
                }
            }

            return stack.Pop();
        }

        private bool IsValidPair(char opening, char closing)
        {
            return (opening == '(' && closing == ')') ||
                   (opening == '[' && closing == ']') ||
                   (opening == '{' && closing == '}');
        }

        // https://leetcode.com/problems/valid-parentheses/
        // https://youtu.be/WTzjTskDFMg
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();

            foreach (var ch in s)
            {
                if ("([{".Contains(ch))
                {
                    stack.Push(ch);
                    continue;
                }

                if (stack.Count == 0)
                {
                    return false;
                }

                var opening = stack.Pop();

                if (!IsValidPair(opening, ch))
                {
                    return false;
                }
            }

            if (stack.Count > 0)
            {
                return false;
            }

            return true;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        // https://leetcode.com/problems/reverse-linked-list/
        // https://youtu.be/G0_I-ZF0S38
        public ListNode ReverseList(ListNode head)
        {
            ListNode oldHead = null;
            ListNode newHead = null;

            while (head != null)
            {
                oldHead = newHead;
                newHead = new ListNode()
                {
                    val = head.val,
                    next = oldHead
                };

                head = head.next;
            }

            return newHead;
        }

        // https://leetcode.com/problems/merge-two-sorted-lists/
        // https://youtu.be/XIdigk956u0
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            // v1
            //ListNode head = null;
            //ListNode currentNode = null;
            //ListNode previousNode = null;

            //while (list1 != null || list2 != null)
            //{
            //    if (list1 == null)
            //    {
            //        currentNode = new ListNode(list2.val, null);
            //        list2 = list2.next;
            //    }
            //    else if (list2 == null)
            //    {
            //        currentNode = new ListNode(list1.val, null);
            //        list1 = list1.next;
            //    }
            //    else if (list1.val <= list2.val)
            //    {
            //        currentNode = new ListNode(list1.val, null);
            //        list1 = list1.next;
            //    }
            //    else
            //    {
            //        currentNode = new ListNode(list2.val, null);
            //        list2 = list2.next;
            //    }

            //    if (head == null)
            //    {
            //        head = currentNode;
            //    }

            //    if (previousNode != null)
            //    {
            //        previousNode.next = currentNode;
            //    }

            //    previousNode = currentNode;
            //}

            //return head;

            // v2
            ListNode dummyHead = new ListNode(0);
            ListNode previousHead = dummyHead;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    previousHead.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    previousHead.next = list2;
                    list2 = list2.next;
                }

                previousHead = previousHead.next;
            }

            previousHead.next = list1 == null ? list2 : list1;

            return dummyHead.next;
        }

        // https://leetcode.com/problems/binary-search/
        // https://youtu.be/s4DPM8ct1pI
        public int BinarySearch(int[] nums, int target)
        {
            int low = 0;
            int mid;
            int high = nums.Length - 1;

            while (low <= high)
            {
                mid = low + (high - low) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }
    }
}
