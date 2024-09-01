

///Depth First Search  - DFS
static IList<string> BinaryTreePaths(TreeNode root)
{
    var list = new List<string>();
    if(root == null)
        return list;
    Stack<(TreeNode node, string path)> stack 
        = new Stack<(TreeNode, string)>();
    stack.Push((root, root.val.ToString()));

    while (stack.Count > 0)
    {
        var(node, path) = stack.Pop();
        if(node.left == null && node.right == null)
            list.Add(path);
        if (node.right != null)
            stack.Push((node.right, path + "->" + node.right.val));
        if (node.left != null)
            stack.Push((node.left, path + "->" + node.left.val));
    }
    return list; 
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