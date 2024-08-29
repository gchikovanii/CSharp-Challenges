
int[] nums = [9, 6, 4, 2, -3, 5, 7, 0, 1];
int missingNumber = SmallestMissingNumber(nums);
Console.WriteLine(missingNumber); 
static int SmallestMissingNumber(int[] nums) 
{
    for (int i = 0; i < nums.Length; i++)
    {
        while (nums[i] > 0 && nums[i] <= nums.Length && nums[nums[i] - 1] != nums[i])
        {
            int correctIndex = nums[i] - 1;
            int temp = nums[correctIndex];
            nums[correctIndex] = nums[i];
            nums[i] = temp;
        }
    }


    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] != i + 1)
            return i + 1;
    }
    return nums.Length + 1;
}