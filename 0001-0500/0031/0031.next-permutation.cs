/*
 * @lc app=leetcode id=31 lang=csharp
 *
 * [31] Next Permutation
 */

// @lc code=start
public class Solution {
    public void NextPermutation(int[] nums) {
        if(nums == null || nums.Length == 0) return;
        int i = nums.Length - 2;
        while(i >= 0 && nums[i] >= nums[i + 1]) {
            i--;
        }
        if(i >= 0) {
            int j = nums.Length - 1;
            while(j >= 0 && nums[j] <= nums[i]) {
                j--;
            }
            Swap(nums, i, j);
        }
        Reverse(nums, i + 1);
    }

    private void Reverse(int[] nums, int start) {
        int i = start, j = nums.Length - 1;
        while(i < j) {
            Swap(nums, i++, j--);
        }
    }

    private void Swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i++] = nums[j];
        nums[j--] = temp;
    }
}
// @lc code=end

