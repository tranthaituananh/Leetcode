/*
 * @lc app=leetcode id=14 lang=csharp
 *
 * [14] Longest Common Prefix
 */

// @lc code=start
public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if (strs.Length == 0) return "";
        var sb = new StringBuilder();
        var minLen = strs.Min(s => s.Length);
        for (int i = 0; i < minLen; i++) {
            var c = strs[0][i];
            if (strs.All(s => s[i] == c)) {
                sb.Append(c);
            } else {
                break;
            }
        }
        return sb.ToString();
    }
}
// @lc code=end

