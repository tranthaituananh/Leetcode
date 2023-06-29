/*
 * @lc app=leetcode id=10 lang=cpp
 *
 * [10] Regular Expression Matching
 */

// @lc code=start
class Solution
{
public:
    bool isMatch(string s, string p)
    {
        int m = s.size(), n = p.size();
        // dp[i][j] means s[0..i-1] matches p[0..j-1]
        vector<vector<bool>> dp(m + 1, vector<bool>(n + 1, false));
        // empty string matches empty pattern
        dp[0][0] = true;
        // empty string matches pattern like a*b*c*
        for (int j = 2; j <= n; ++j)
        {
            dp[0][j] = p[j - 1] == '*' && dp[0][j - 2];
        }
        // dp[i][j] = dp[i-1][j-1] if s[i-1] == p[j-1] || p[j-1] == '.'
        // dp[i][j] = dp[i][j-2] if p[j-1] == '*' and matches empty
        // dp[i][j] = dp[i-1][j] if p[j-1] == '*' and matches multiple
        for (int i = 1; i <= m; ++i)
        {
            char sc = s[i - 1];
            for (int j = 1; j <= n; ++j)
            {
                char pc = p[j - 1];
                if (sc == pc || pc == '.')
                {
                    dp[i][j] = dp[i - 1][j - 1];
                }
                else if (pc == '*')
                {
                    if (dp[i][j - 2])
                    {
                        dp[i][j] = true;
                    }
                    else if (sc == p[j - 2] || p[j - 2] == '.')
                    {
                        dp[i][j] = dp[i - 1][j];
                    }
                }
            }
        }
        return dp[m][n];
    }
};
// @lc code=end
