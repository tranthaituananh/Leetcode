/*
 * @lc app=leetcode id=12 lang=cpp
 *
 * [12] Integer to Roman
 */

// @lc code=start
class Solution
{
public:
    string intToRoman(int num)
    {
        string res;
        vector<int> nums = {1000, 900, 500, 400, 100,
                            90, 50, 40, 10, 9, 5, 4, 1};
        vector<string> romans = {"M", "CM", "D", "CD", "C",
                                 "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
        for (int i = 0; i < nums.size(); i++)
        {
            while (num >= nums[i])
            {
                num -= nums[i];
                res += romans[i];
            }
        }
        return res;
    }
};
// @lc code=end
