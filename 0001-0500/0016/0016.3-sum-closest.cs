/*
 * @lc app=leetcode id=16 lang=csharp
 *
 * [16] 3Sum Closest
 */

// @lc code=start
public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);
        int result = nums[0] + nums[1] + nums[2];
        for (int i = 0; i < nums.Length; i++) {
            int left = i + 1;
            int right = nums.Length - 1;
            while (left < right) {
                int sum = nums[i] + nums[left] + nums[right];
                if (Math.Abs(sum - target) < Math.Abs(result - target)) {
                    result = sum;
                }
                if (sum < target) {
                    left++;
                } else {
                    right--;
                }
            }
        }
        return result;  
    }
}
// @lc code=end

