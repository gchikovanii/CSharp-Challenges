//Write a program that generates all permutations using Backtracking algorithm

string input = "ABC";
List<string> permutations = new List<string>();
GeneratePermutations("",input,permutations);
foreach (var item in permutations)
{
    Console.WriteLine(item);
}
                                    
void GeneratePermutations(string currentPermutation, string remainingCharacters, List<string> permutations)
{
    if(remainingCharacters.Length == 0)
        permutations.Add(currentPermutation);
    else
    {
        for (int i = 0; i < remainingCharacters.Length; i++)
        {
            char chosenChar = remainingCharacters[i];

            string newRemaining = remainingCharacters.Substring(0, i) + remainingCharacters.Substring(i + 1);
            GeneratePermutations(currentPermutation + chosenChar, newRemaining, permutations);
        }
    }
}