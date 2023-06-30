/*
 * @lc app=leetcode id=28 lang=cpp
 *
 * [28] Find the Index of the First Occurrence in a String
 */

// @lc code=start
class Solution
{
public:
    int strStr(string haystack, string needle)
    {
        if (needle.empty())
            return 0;
        int n = haystack.size(), m = needle.size();
        for (int i = 0; i < n - m + 1; ++i)
        {
            int j = 0;
            for (; j < m; ++j)
            {
                if (haystack[i + j] != needle[j])
                    break;
            }
            if (j == m)
                return i;
        }
        return -1;
    }
};
// @lc code=end
