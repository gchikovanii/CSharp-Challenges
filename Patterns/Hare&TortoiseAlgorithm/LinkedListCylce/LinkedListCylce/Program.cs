
Console.WriteLine(  );

static bool HasCycle(ListNode head)
{
    ListNode slow = head;
    ListNode fast = head;
    
    while (fast != null && fast.next != null)
    {
        slow = slow.next;
        fast = fast.next.next;
        if (fast == slow)
            return true;
    }
    return false;
}


public class ListNode
{
     public int val;
     public ListNode next;
     public ListNode(int x)
     {
        val = x;
        next = null;
     }
 }

