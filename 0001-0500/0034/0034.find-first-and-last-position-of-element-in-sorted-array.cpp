/*
 * @lc app=leetcode id=34 lang=cpp
 *
 * [34] Find First and Last Position of Element in Sorted Array
 */

// @lc code=start
class Solution
{
public:
    vector<int> searchRange(vector<int> &nums, int target)
    {
        int left = 0, right = nums.size();
        int mid = 0;
        vector<int> res(2, -1);
        while (left < right)
        {
            mid = (left + right) / 2;
            if (nums[mid] >= target)
                right = mid;
            else
                left = mid + 1;
        }
        if (left == nums.size() || nums[left] != target)
            return res;
        res[0] = left;
        right = nums.size();
        while (left < right)
        {
            mid = (left + right) / 2;
            if (nums[mid] > target)
                right = mid;
            else
                left = mid + 1;
        }
        res[1] = left - 1;
        return res;
    }
};
// @lc code=end
