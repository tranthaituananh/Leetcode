/*
 * @lc app=leetcode id=35 lang=cpp
 *
 * [35] Search Insert Position
 */

// @lc code=start
class Solution
{
public:
    int searchInsert(vector<int> &nums, int target)
    {
        int l = nums.size() - 1;
        int pos = 0;
        while (l >= pos)
        {
            int mid = (l + pos) / 2;
            if (nums[mid] < target)
            {
                pos = mid + 1;
            }
            if (nums[mid] == target)
            {
                return mid;
            }
            if (nums[mid] > target)
            {
                l = mid - 1;
            }
        }
        return pos;
    }
};
// @lc code=end
