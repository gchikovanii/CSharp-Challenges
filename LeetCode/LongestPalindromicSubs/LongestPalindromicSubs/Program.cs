string input = "aabbaa";
string inputtwo = "cbbd";
Console.WriteLine(LongestPalindrome(input));
Console.WriteLine(LongestPalindrome(inputtwo));

//Just Method to get if is palindrome the whole string, not using
string palindromeSequence(string text)
{
    var center = text.Length / 2;
    var firsstHalf = text.Substring(0, center);
    string secondHalf = string.Empty;
    if (text.Length % 2 != 0)
        secondHalf = text.Substring(center + 1);
    else
        secondHalf = text.Substring(center);
    var arr = secondHalf.ToCharArray();
    Array.Reverse(arr);
    var reveresedStr = new string(arr);
    return firsstHalf.Equals(reveresedStr) ? reveresedStr : string.Empty;
}

string LongestPalindrome(string text)
{
    string longestPalindrom = string.Empty;
    string tempPalindrome = string.Empty;
    string tempPalindromeTwo= string.Empty;
    for (int i = 0; i < text.Length; i++)
    {
            tempPalindrome = ExpandAroundCenter(text, i, i);
            if (tempPalindrome.Length > longestPalindrom.Length)
                longestPalindrom = tempPalindrome;
            tempPalindromeTwo = ExpandAroundCenter(text, i, i +1);
            if (tempPalindromeTwo.Length > longestPalindrom.Length)
                longestPalindrom = tempPalindromeTwo;
    }
    return longestPalindrom;
}



string ExpandAroundCenter(string text, int left, int right)
{

    while(left >= 0 && right < text.Length && text[left] == text[right])
    {
        left--;
        right++;
    }
    return text.Substring(left + 1, right - left - 1);
}