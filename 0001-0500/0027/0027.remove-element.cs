/*
 * @lc app=leetcode id=27 lang=csharp
 *
 * [27] Remove Element
 */

// @lc code=start
public class Solution {
    public int RemoveElement(int[] nums, int val) {
        if(nums == null || nums.Length == 0) return 0;
        int i = 0;
        for(int j = 0; j < nums.Length; j++) {
            if(nums[j] != val) {
                nums[i++] = nums[j];
            }
        }
        return i;
    }
}
// @lc code=end

