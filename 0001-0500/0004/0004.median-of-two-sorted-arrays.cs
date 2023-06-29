/*
 * @lc app=leetcode id=4 lang=csharp
 *
 * [4] Median of Two Sorted Arrays
 */

// @lc code=start
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] merged = new int[nums1.Length + nums2.Length];
        int i = 0, j = 0, k = 0;
        while(i < nums1.Length && j < nums2.Length) {
            if(nums1[i] < nums2[j]) {
                merged[k++] = nums1[i++];
            } else {
                merged[k++] = nums2[j++];
            }
        }
        while(i < nums1.Length) {
            merged[k++] = nums1[i++];
        }
        while(j < nums2.Length) {
            merged[k++] = nums2[j++];
        }
        if(merged.Length % 2 == 0) {
            return (merged[merged.Length / 2 - 1] + merged[merged.Length / 2]) / 2.0;
        } else {
            return merged[merged.Length / 2];
        }
    }
}
// @lc code=end

