int[] nums = [1, 1, 1, 2, 2, 3];
int k = 2;
Console.WriteLine(TopKFrequent(nums,k));

int[] TopKFrequent(int[] nums, int k)
{
    Dictionary<int,int> map = new Dictionary<int,int>();
    foreach(int i in nums)
    {
        if (map.ContainsKey(i))
            map[i]++;
        else
            map[i] = 1;
    }
    return map.OrderByDescending(i => i.Value)
        .Take(k)
        .Select(i => i.Key)
        .ToArray();
}