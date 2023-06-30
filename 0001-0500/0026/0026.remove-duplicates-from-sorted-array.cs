/*
 * @lc app=leetcode id=26 lang=csharp
 *
 * [26] Remove Duplicates from Sorted Array
 */

// @lc code=start
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if(nums == null || nums.Length == 0) return 0;
        int i = 0;
        for(int j = 1; j < nums.Length; j++) {
            if(nums[j] != nums[i]) {
                nums[++i] = nums[j];
            }
        }
        return i + 1;
    }
}
// @lc code=end

