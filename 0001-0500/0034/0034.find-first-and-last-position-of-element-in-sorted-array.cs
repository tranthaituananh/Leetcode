/*
 * @lc app=leetcode id=34 lang=csharp
 *
 * [34] Find First and Last Position of Element in Sorted Array
 */

// @lc code=start
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int[] result = new int[2];
        result[0] = -1;
        result[1] = -1;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == target) {
                if (result[0] == -1) {
                    result[0] = i;
                }
                result[1] = i;
            }
        }        
        return result;
    }
}
// @lc code=end

