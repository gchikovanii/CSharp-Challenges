foreach (var item in SumZero(4))
{
    Console.WriteLine(item);
}


int[] SumZero(int n)
{
    List<int> result = new List<int>();
    if (n == 1)
    {
        return new int[1] {0};
    }
    int num = 1;
    if (n % 2 == 0)
    {
       
        for (int i = 0; i < n / 2; i ++)
        {
            result.Add(num);
            result.Add(-num);
            num++;
        }
    }
    else
    {

        for (int i = 0; i < (n - 1) / 2; i++)
        {
            result.Add(num);
            result.Add(-num);
            num++;
        }
        result.Add(0);
    }
    return result.ToArray();
}