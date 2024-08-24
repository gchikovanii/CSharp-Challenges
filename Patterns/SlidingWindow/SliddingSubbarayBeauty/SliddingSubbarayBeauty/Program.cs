
using System.Diagnostics.Metrics;
using System;

var result = GetSubarrayBeauty([-1, -2, -3, -4, -5],2,2);
var secondMock = GetSubarrayBeauty([-3, 1, 2, -3, 0, -3], 2,1);
foreach (var item in result) 
{
    Console.WriteLine(item);
}
Console.WriteLine("Second Mock nums");
foreach (var item in secondMock)
{
    Console.WriteLine(item);
}
//My First Solution
//static int[] GetSubarrayBeauty(int[] nums, int sequence, int pointer)
//{
//    var resultNums = new List<int>();
//    var tempNums = new List<int>();
//    var count = (nums.Length - sequence) + 1;
//    for (int i = 0; i < count; i++)
//    {
//        for (int j = i; j < sequence; j++)
//        {
//            tempNums.Add(nums[j]);
//        }
//        sequence++;
//        var sortedNums = tempNums.OrderBy(i => i).ToList();
//        if (sortedNums[pointer - 1] >= 0)
//            resultNums.Add(0);
//        else
//            resultNums.Add(sortedNums[pointer - 1]);
//        tempNums.Clear();
//    }
//    return resultNums.ToArray();
//}


//Advanced Solution
static int[] GetSubarrayBeauty(int[] nums, int subarraySize, int x)
{
    var resultNums = new List<int>();
    var sortedWindow = new SortedList<int, int>();

    // Initialize the first window
    for (int i = 0; i < subarraySize; i++)
    {
        if (nums[i] < 0)
            if (sortedWindow.ContainsKey(nums[i]))
                sortedWindow[nums[i]]++;
            else
                sortedWindow[nums[i]] = 1;
    }

    // Function to get the beauty of the current window
    int GetBeauty()
    {
        int count = 0;
        foreach (var key in sortedWindow.Keys)
        {
            count += sortedWindow[key];
            if (count >= x)
                return key;
        }
        return 0;
    }

    // Add the beauty of the first window
    resultNums.Add(GetBeauty());

    // Slide the window over the array
    for (int i = subarraySize; i < nums.Length; i++)
    {
        int outgoing = nums[i - subarraySize];
        int incoming = nums[i];

        // Remove the outgoing element
        if (outgoing < 0)
        {
            if (sortedWindow[outgoing] == 1)
                sortedWindow.Remove(outgoing);
            else
                sortedWindow[outgoing]--;
        }

        // Add the incoming element
        if (incoming < 0)
        {
            if (sortedWindow.ContainsKey(incoming))
                sortedWindow[incoming]++;
            else
                sortedWindow[incoming] = 1;
        }

        // Get the beauty of the current window
        resultNums.Add(GetBeauty());
    }

    return resultNums.ToArray();
}