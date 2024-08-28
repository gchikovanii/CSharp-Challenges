
int[][] overs = [[1, 3], [2, 6], [8, 10], [15, 18]];

Merge(overs);
static int[][] Merge(int[][] intervals)
{
	if (intervals.Length == 0 || intervals.Length ==1)
		return intervals;
    //Sorted List
	Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));
	List<int[]> mergedList = new List<int[]>();
    
    //Taking first array because it will be smallest, after sort
    int[] currentInterval = intervals[0];   
    mergedList.Add(currentInterval);

    for (int i = 1; i < intervals.Length; i++)
	{
        int currentEnd = currentInterval[1];
        int nextStart = intervals[i][0];
        int nextEnd = intervals[i][1];
        if(currentEnd >= nextStart)
            ///Bacause merged List takes its reference will be updated in List too
            currentInterval[1] = Math.Max(currentEnd,nextEnd);
        else
        {
            currentInterval = intervals[i];
            mergedList.Add(currentInterval);
        }
	}
	return mergedList.ToArray();
}