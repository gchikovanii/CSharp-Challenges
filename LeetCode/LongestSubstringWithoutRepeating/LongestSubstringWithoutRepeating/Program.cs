string input = "KukuKata";
LengthOfLongestSubstring(input);
static int LengthOfLongestSubstring(string s)
{
    List<char> charSet = new List<char>();
    int start = 0;
    int maxLength = 0;
    string longestSubstring = "";

    for (int end = 0; end < s.Length; end++)
    {
        while (charSet.Contains(s[end]))
        {
            charSet.Remove(s[start]);
            start++;
        }

        charSet.Add(s[end]);
        if (end - start + 1 > maxLength)
        {
            maxLength = end - start + 1;
            longestSubstring = s.Substring(start, maxLength);
        }
    }

    return longestSubstring.Length;
}


