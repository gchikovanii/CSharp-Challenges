
int[] nums = [-1, 0, 3, 5, 9, 12];
Console.WriteLine(Search(nums,9));
static int Search(int[] nums, int target)
{
	int left = 0;
	int right = nums.Length - 1;

	while(left <= right)
	{
		//Safety for int overflow
		int mid = left + (right - left) / 2;
		if (target == nums[mid])
			return mid;
		else if (nums[mid] < target)
			left = mid + 1;
		else
			right = mid - 1;
    }
	return -1;
}