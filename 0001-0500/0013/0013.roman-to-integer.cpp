/*
 * @lc app=leetcode id=13 lang=cpp
 *
 * [13] Roman to Integer
 */

// @lc code=start
class Solution
{
public:
    int romanToInt(string s)
    {
        int res = 0;
        int len = s.length();
        for (int i = 0; i < len; i++)
        {
            if (i < len - 1 && valueInt(s[i]) < valueInt(s[i + 1]))
            {
                res -= valueInt(s[i]);
            }
            else
            {
                res += valueInt(s[i]);
            }
        }
        return res;
    }
    int valueInt(char c)
    {
        switch (c)
        {
        case 'I':
            return 1;
        case 'V':
            return 5;
        case 'X':
            return 10;
        case 'L':
            return 50;
        case 'C':
            return 100;
        case 'D':
            return 500;
        case 'M':
            return 1000;
        default:
            return 0;
        }
    }
};
// @lc code=end
