/*
 * @lc app=leetcode id=4 lang=cpp
 *
 * [4] Median of Two Sorted Arrays
 */

// @lc code=start
class Solution
{
public:
    double findMedianSortedArrays(vector<int> &nums1, vector<int> &nums2)
    {
        int total = nums1.size() + nums2.size(), mid = total / 2;
        int i = 0, j = 0, k = 0, prev = 0, curr = 0;
        while (k <= mid)
        {
            prev = curr;
            if (i < nums1.size() && j < nums2.size())
            {
                if (nums1[i] < nums2[j])
                    curr = nums1[i++];
                else
                    curr = nums2[j++];
            }
            else if (i < nums1.size())
            {
                curr = nums1[i++];
            }
            else
            {
                curr = nums2[j++];
            }
            k++;
        }
        if (total % 2 == 0)
            return (prev + curr) / 2.0;
        else
            return curr;
    }
};
// @lc code=end
