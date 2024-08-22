using LinkedListTwoNumReerseSum;

static ListNode addTwoNumbers(ListNode l1, ListNode l2)
{
    var tempFirstNode = l1;
    var tempSecondNode = l2;

    int numberCountFristNode = LinkedCount(l1);
    int numberCountSecondNode = LinkedCount(l2);

    int mainCount = numberCountFristNode > numberCountSecondNode
        ? numberCountFristNode : numberCountSecondNode;
    int added = 0, sum = 0;
    List<int> nums = new List<int>();
    while(mainCount > 0)
    {
        var firstValue = tempFirstNode?.val ?? 0;
        var secondValue = tempSecondNode?.val ?? 0;
        sum += (firstValue + secondValue + added) % 10;
        added = (firstValue + secondValue + added) / 10;
        mainCount--;
        nums.Add(sum);
        tempFirstNode = tempFirstNode?.next;
        tempSecondNode = tempSecondNode?.next;
    }
    if (added != 0)
        nums.Add(added);
    return NumbetToListNode(nums);
}

static int LinkedCount(ListNode node)
{
    int count = 0;
    var temp = node;

    while(temp != null)
    {
        count++;
        temp = temp.next;
    }
    return count;
}

static ListNode NumbetToListNode(List<int> nums)
{
    ListNode temp = null;
    for (int i = nums.Count -1; i > 0; i--)
    {
        if (i > 0)
        {
            var node = new ListNode(nums[i],temp);
            temp = node;
            continue;
        }
        else
        {
            var node = new ListNode(nums[i], temp);
            return node;
        }
    }
    return null;
}