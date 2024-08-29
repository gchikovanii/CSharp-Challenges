int[] arr1 = { 2, 3, 4, 7, 11 };
int k1 = 5;
Console.WriteLine(FindKthPositive(arr1, k1));  // Output: 9

int[] arr2 = { 1, 2, 3, 4 };
int k2 = 2;
Console.WriteLine(FindKthPositive(arr2, k2));

static int FindKthPositive(int[] arr, int k)
{
    int missingCount = 0;
	int lastNumber = 0;
    for (int i = 0; i < arr.Length; i++)
	{
		int excepctedValue = i + 1;
		missingCount += arr[i] - excepctedValue - missingCount;

        if (missingCount >= k)
		{
			return arr[i] - (missingCount - k + 1);
		}
		lastNumber = arr[i];
	}
	return lastNumber + (k - missingCount);
}