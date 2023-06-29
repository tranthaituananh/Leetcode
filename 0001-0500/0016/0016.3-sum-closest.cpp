/*
 * @lc app=leetcode id=16 lang=cpp
 *
 * [16] 3Sum Closest
 */

// @lc code=start
class Solution
{
public:
    int twoSumCloset(vector<int> &nums, int target, int start)
    {
        int left = start, right = nums.size() - 1;
        int curMin = INT_MAX;
        int curVal = 0;
        while (left < right)
        {
            if (nums[left] >= target / 2)
            {
                int tmp = nums[left] + nums[left + 1] - target;
                return tmp < curMin ? tmp + target : curVal;
            }
            if (nums[right] <= target / 2)
            {
                int tmp = target - nums[right] - nums[right - 1];
                return tmp < curMin ? target - tmp : curVal;
            }
            int tmp = nums[left] + nums[right];
            if (tmp == target)
                return target;
            if (tmp < target)
            {
                left++;
                if (target - tmp < curMin)
                {
                    curMin = target - tmp;
                    curVal = tmp;
                }
            }
            else
            {
                right--;
                if (tmp - target < curMin)
                {
                    curMin = tmp - target;
                    curVal = tmp;
                }
            }
        }
        return curVal;
    }

    int threeSumClosest(vector<int> &nums, int target)
    {
        sort(nums.begin(), nums.end());
        int curMin = INT_MAX;
        int curVal = 0;
        for (int i = 0; i < nums.size() - 2; i++)
        {
            int tmp = twoSumCloset(nums, target - nums[i], i + 1) + nums[i];

            if (tmp == target)
                return target;
            if (abs(tmp - target) < curMin)
            {
                curVal = tmp;
                curMin = abs(tmp - target);
            }
        }
        return curVal;
    }
};
// @lc code=end
