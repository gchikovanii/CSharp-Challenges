static bool IsSameTree(TreeNode p, TreeNode q)
{
    TreeNode pHead = p;
    TreeNode qHead = q;

    Stack<(TreeNode, TreeNode)> stack = new Stack<(TreeNode, TreeNode)>();
    stack.Push((p, q));
    while (stack.Count > 0)
    {
        (TreeNode node1, TreeNode node2) = stack.Pop();

        if (node1 == node2)
            continue;
        if (node1 == null || node2 == null)
            return false;
        if (node1.val != node2.val)
            return false;
        stack.Push((node1.left, node2.left));
        stack.Push((node1.right, node2.right));
    }
    return true;
}


public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

