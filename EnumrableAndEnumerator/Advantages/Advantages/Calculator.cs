namespace Advantages
{
    public class Calculator
    {
        public static IEnumerable<int> GetEvenNumbers(int max)
        {
            for (int i = 0; i < max; i++)
            {
                if (max % 2 == 0)
                    yield return i;
            }
        }
    }
}
