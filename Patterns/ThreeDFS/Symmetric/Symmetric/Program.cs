static bool IsSameTree(TreeNode root)
{
    if (root == null)
        return true;
    Stack<(TreeNode, TreeNode)> stack = new Stack<(TreeNode, TreeNode)>();
    stack.Push((root.left, root.right));
    while (stack.Count > 0)
    {
        (TreeNode node1, TreeNode node2) = stack.Pop();
        if (node1 == null && node2 == null)
            continue;
        if (node1 == null || node2 == null)
            return false;
        if (node1.val != node2.val)
            return false;
        stack.Push((node1.left, node2.right));
        stack.Push((node1.right, node2.left));
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

