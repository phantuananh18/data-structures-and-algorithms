//https://leetcode.com/problems/range-sum-of-bst/
// Definition for a binary tree node.
//Input: root = [10,5,15,3,7,null,18], low = 7, high = 15
//Output: 32
//Explanation: Nodes 7, 10, and 15 are in the range [7, 15]. 7 + 10 + 15 = 32.
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

public class Solution
{
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        if (root == null)
            return 0;
        if (root.val > high)
            return RangeSumBST(root.left, low, high);
        if (root.val < low)
            return RangeSumBST(root.right, low, high);
        return root.val + RangeSumBST(root.left, low, high) + RangeSumBST(root.right, low, high);
    }
}