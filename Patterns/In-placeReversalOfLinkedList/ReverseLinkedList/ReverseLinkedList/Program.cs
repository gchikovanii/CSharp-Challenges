static ListNode ReverseList(ListNode head)
{
    ListNode current = head;
    ListNode previuos = null;
    while(current != null)
    {
        var temp = current.next;
        current.next = previuos;
        previuos = current;
        current = temp;
    }
    return previuos;
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0,ListNode next = null)
    {
        val = val;
        next = null;
    }
}