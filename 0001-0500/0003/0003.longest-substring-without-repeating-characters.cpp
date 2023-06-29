/*
 * @lc app=leetcode id=3 lang=cpp
 *
 * [3] Longest Substring Without Repeating Characters
 */

// @lc code=start
class Solution
{
public:
    int lengthOfLongestSubstring(string s)
    {
        int n = s.length();
        int ans = 0;
        int i = 0, j = 0;
        unordered_set<char> st;

        while (i < n && j < n)
        {
            if (st.find(s[j]) == st.end())
            {
                st.insert(s[j++]);
                ans = max(ans, j - i);
            }
            else
            {
                st.erase(s[i++]);
            }
        }

        return ans;
    }
};
// @lc code=end
