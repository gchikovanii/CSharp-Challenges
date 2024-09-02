
KthLargest kthLargest = new KthLargest(3, new int[] { 4, 5, 8, 2 });
Console.WriteLine(kthLargest.Add(3));  
Console.WriteLine(kthLargest.Add(5));
Console.WriteLine(kthLargest.Add(10));
Console.WriteLine(kthLargest.Add(9));  
Console.WriteLine(kthLargest.Add(4));

public class KthLargest
{
    private readonly int _k;
    private readonly PriorityQueue<int,int> _minHeap;
    public KthLargest(int k, int[] nums)
    {
        _k = k;
        _minHeap = new PriorityQueue<int,int>();
        foreach (int i in nums)
        {
            Add(i);
        }
    }

    public int Add(int val)
    {
        _minHeap.Enqueue(val,val);
        if(_minHeap.Count > _k)
            _minHeap.Dequeue();
        return _minHeap.Peek();
    }
}
