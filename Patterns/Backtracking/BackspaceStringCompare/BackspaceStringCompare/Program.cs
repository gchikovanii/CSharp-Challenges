

string s = "a#";
string t = "b";
Console.WriteLine(BackspaceCompare(s, t));
static bool BackspaceCompare(string s, string t)
{
    string resultString(string k)
    {
        Stack<char> stack = new Stack<char>();
        
        foreach (var ks in k)
        {
            if(ks != '#')
                stack.Push(ks);
            else if (stack.Count > 0)
                stack.Pop();
        }
        return new string(stack.ToArray());
    }
    return resultString(s).Equals(resultString(t));   
}

