/*
 * @lc app=leetcode id=22 lang=csharp
 *
 * [22] Generate Parentheses
 */

// @lc code=start
public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();
        GenerateParenthesisHelper(result, "", 0, 0, n);
        return result;
    }

    public void GenerateParenthesisHelper(List<string> result, string current, int open, int close, int max) {
        if(current.Length == max * 2) {
            result.Add(current);
            return;
        }
        if(open < max) {
            GenerateParenthesisHelper(result, current + "(", open + 1, close, max);
        }
        if(close < open) {
            GenerateParenthesisHelper(result, current + ")", open, close + 1, max);
        }
    }
}
// @lc code=end

