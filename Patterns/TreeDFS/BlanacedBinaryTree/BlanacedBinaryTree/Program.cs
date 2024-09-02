
static bool IsBalanced(TreeNode root)
{
    if (root == null)
        return true;
    Stack<TreeNode> stack = new Stack<TreeNode>();
    Dictionary<TreeNode, int> heights = new Dictionary<TreeNode, int>();
    stack.Push(root);
    while (stack.Count > 0)
    {
        var current = stack.Peek();
        if (current.left != null && !heights.ContainsKey(current.left))
            stack.Push(current.left);
        else if (current.right != null && !heights.ContainsKey(current.right))
            stack.Push(current.right);
        else
        {
            stack.Pop();
            int leftHeight = current.left != null ? heights[current.left] : 0;
            int rightHeight = current.right != null ? heights[current.right] : 0;
            if (Math.Abs(leftHeight - rightHeight) > 1)
                return false;
            heights[current] = Math.Max(leftHeight, rightHeight) + 1;
        }
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