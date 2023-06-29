/*
 * @lc app=leetcode id=11 lang=csharp
 *
 * [11] Container With Most Water
 */

// @lc code=start
public class Solution {
    public int MaxArea(int[] height) {
        int max = 0;
        int left = 0;
        int right = height.Length - 1;
        while (left < right) {
            int area = Math.Min(height[left], height[right]) * (right - left);
            max = Math.Max(max, area);
            if (height[left] < height[right]) {
                left++;
            } else {
                right--;
            }
        }
        return max;
    }
}
// @lc code=end

