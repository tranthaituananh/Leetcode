/*
 * @lc app=leetcode id=22 lang=cpp
 *
 * [22] Generate Parentheses
 */

// @lc code=start
class Solution
{
public:
    vector<string> generateParenthesis(int n)
    {
        vector<string> res;
        string s;
        dfs(res, s, n, n);
        return res;
    }

    void dfs(vector<string> &res, string &s, int left, int right)
    {
        if (left == 0 && right == 0)
        {
            res.push_back(s);
            return;
        }

        if (left > 0)
        {
            s.push_back('(');
            dfs(res, s, left - 1, right);
            s.pop_back();
        }

        if (right > left)
        {
            s.push_back(')');
            dfs(res, s, left, right - 1);
            s.pop_back();
        }
    }
};
// @lc code=end
