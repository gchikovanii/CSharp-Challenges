
int[] nums =[2, 3,0,1, 4, 7, 11];
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
	int cc = 0;
	for (int i = 0; i < nums[nums.Length - 1]; i++)
	{
		if (nums[i] != i)
			cc++;
		else if (nums[i] != i && cc == 5)
			return i + 1;
	}
	return nums.Length;
}
