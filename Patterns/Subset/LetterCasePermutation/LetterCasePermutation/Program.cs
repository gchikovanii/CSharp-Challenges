var permutations = LetterCasePermutation("a1b2");
foreach (var p in permutations)
{
    Console.WriteLine(p);
}


static IList<string> LetterCasePermutation(string s)
{
    var result = new List<string>();
    Backtrack(result, "", 0, s);
    return result;
}

static void Backtrack(List<string> results, string currentPermutation,int index,string s)
{
    if(index == s.Length)
    {
        results.Add(currentPermutation);
        return;
    }
    char currentChar = s[index];
    if (char.IsDigit(currentChar))
    {
        Backtrack(results, currentPermutation + currentChar, index + 1, s);
    }
    else
    {
        Backtrack(results,currentPermutation + Char.ToUpper(currentChar), index + 1, s);
        Backtrack(results,currentPermutation + Char.ToLower(currentChar), index + 1, s);
    }
}