/*
 * @lc app=leetcode id=32 lang=csharp
 *
 * [32] Longest Valid Parentheses
 */

// @lc code=start
public class Solution {
    public int LongestValidParentheses(string s) {
        int max = 0;
        int[] dp = new int[s.Length];
        for(int i = 1; i < s.Length; i++) {
            if(s[i] == ')') {
                if(s[i - 1] == '(') {
                    dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                } else if(i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(') {
                    dp[i] = dp[i - 1] + ((i - dp[i - 1]) >= 2 ? dp[i - dp[i - 1] - 2] : 0) + 2;
                }
                max = Math.Max(max, dp[i]);
            }
        }
        return max;
    }
}
// @lc code=end

