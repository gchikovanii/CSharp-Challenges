
int[] nums = [2, 3, 4, 7, 11];
int missingNumber = SmallestMissingNumber(nums, 5);
Console.WriteLine(missingNumber); 
static int SmallestMissingNumber(int[] nums, int k) 
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
    int counter = 0;
    var toComp = nums.Max(i => i);
    for (int i = 0; i < toComp; i++)
    {
        if (nums[i] != i && counter != k)
        {
            counter++;
            continue;
        }
        else if (nums[i] != i + 1 && counter == k)
            return i + 1;
    }
    return nums.Length + 1;
}