/*
 * @lc app=leetcode id=9 lang=cpp
 *
 * [9] Palindrome Number
 */

// @lc code=start
class Solution
{
public:
    bool isPalindrome(int x)
    {
        if (x < 0 || (x % 10 == 0 && x != 0))
            return false;
        int res = 0;
        while (res < x)
        {
            res = res * 10 + x % 10;
            x /= 10;
        }

        return x == res || x == res / 10;
    }
};
// @lc code=end
