/*
 * @lc app=leetcode id=39 lang=cpp
 *
 * [39] Combination Sum
 */

// @lc code=start
class Solution
{
public:
    vector<vector<int>> combinationSum(vector<int> &candidates, int target)
    {
        vector<vector<int>> res;
        vector<int> temp;
        sort(candidates.begin(), candidates.end());
        dfs(candidates, target, 0, temp, res);
        return res;
    }

    void dfs(vector<int> &candidates, int target, int index, vector<int> &temp, vector<vector<int>> &res)
    {
        if (target == 0)
        {
            res.push_back(temp);
            return;
        }
        for (int i = index; i < candidates.size(); i++)
        {
            if (candidates[i] > target)
                break;
            temp.push_back(candidates[i]);
            dfs(candidates, target - candidates[i], i, temp, res);
            temp.pop_back();
        }
    }
};
// @lc code=end
