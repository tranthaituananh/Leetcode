/*
 * @lc app=leetcode id=8 lang=cpp
 *
 * [8] String to Integer (atoi)
 */

// @lc code=start
class Solution
{
public:
    int myAtoi(string s)
    {
        int i = 0;
        int sign = 1;
        int res = 0;
        while (i < s.size() && s[i] == ' ')
            i++;
        if (i < s.size() && (s[i] == '+' || s[i] == '-'))
        {
            sign = s[i] == '+' ? 1 : -1;
            i++;
        }
        while (i < s.size() && isdigit(s[i]))
        {
            int digit = s[i] - '0';
            if (res > INT_MAX / 10 || (res == INT_MAX / 10 && digit > INT_MAX % 10))
            {
                return sign == 1 ? INT_MAX : INT_MIN;
            }
            res = res * 10 + digit;
            i++;
        }
        return res * sign;
    }
};
// @lc code=end
