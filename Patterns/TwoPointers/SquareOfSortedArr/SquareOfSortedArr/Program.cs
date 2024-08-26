int[] ins = [-7, -3, 2, 3, 11];

foreach (var item in SortedSquares(ins))
{
    Console.WriteLine(item);
}
static int[] SortedSquares(int[] nums)
{
    int left = 0;
    int right = nums.Length - 1;
    int counter = nums.Length - 1;
    int[] result = new int[nums.Length];
    while (left <= right)
    {

        if (Math.Abs(nums[left]) < Math.Abs(nums[right]))
        {
            result[counter] = nums[right] * nums[right];
            counter--;
            right--;
        }
        else if (Math.Abs(nums[left]) >= Math.Abs(nums[right])) 
        {
            result[counter] = nums[left] * nums[left];
            counter--;
            left++;
        }
    }
    return result;
}