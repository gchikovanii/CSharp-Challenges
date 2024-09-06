static ListNode MergeKLists(ListNode[] lists)
{
    //Hold nodes in sorterd order in Min-Heap

    var pq = new SortedSet<(int, ListNode)>((Comparer<(int, ListNode)>.Create((a, b) =>
        a.Item1 == b.Item1 ? a.Item2.GetHashCode().CompareTo(b.Item2.GetHashCode()) : a.Item1.CompareTo(b.Item1))));
    //Fill the heap with the head node of each list
    foreach (var node in lists)
    {
        if (node != null)
            pq.Add((node.val, node));
    }

    //Dummy node for appening easier
    ListNode dummy = new ListNode(0);
    ListNode current = dummy;
    while (pq.Count > 0)
    {
        var smallest = pq.Min;
        pq.Remove(smallest);
        //Add smallest to the result list
        current.next = smallest.Item2;
        current = current.next;
        //If next node exists add it to heap
        if (smallest.Item2.next != null)
            pq.Add((smallest.Item2.next.val, smallest.Item2.next));
    }
    return dummy.next;

}
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}