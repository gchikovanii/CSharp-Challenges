
int[] nums = [9, 6, 4, 2, 3, 5, 7, 0, 1];
Console.WriteLine(MissingNumber(nums));

static int MissingNumber(int[] nums)
{
	int counter = 0;
	while (counter < nums.Length)
	{
		if (nums[counter] == counter)
			counter++;
		else if (nums[counter] >= nums.Length)
		{
			counter++;
			continue;
        }
		else
		{
			var temp = nums[nums[counter]];
			nums[nums[counter]] = nums[counter];
			nums[counter] = temp;
		}
	}

	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] != i)
			return i;
	}
	return nums.Length;
}
