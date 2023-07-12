/*
 * @lc app=leetcode id=42 lang=cpp
 *
 * [42] Trapping Rain Water
 */

// @lc code=start
class Solution
{
public:
    int trap(vector<int> &height)
    {
        int n = height.size();
        if (n == 0)
            return 0;

        int left = 0, right = n - 1;
        int leftMax = height[left], rightMax = height[right];
        int res = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] < leftMax)
                {
                    res += leftMax - height[left];
                }
                else
                {
                    leftMax = height[left];
                }
                left++;
            }
            else
            {
                if (height[right] < rightMax)
                {
                    res += rightMax - height[right];
                }
                else
                {
                    rightMax = height[right];
                }
                right--;
            }
        }
        return res;
    }
};
// @lc code=end
