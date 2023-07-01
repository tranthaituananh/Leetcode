/*
 * @lc app=leetcode id=38 lang=csharp
 *
 * [38] Count and Say
 */

// @lc code=start
public class Solution {
    public string CountAndSay(int n) {
        if (n == 1) {
            return "1";
        }
        string prev = CountAndSay(n - 1);
        StringBuilder sb = new StringBuilder();
        int count = 1;
        for (int i = 0; i < prev.Length; i++) {
            if (i + 1 < prev.Length && prev[i] == prev[i + 1]) {
                count++;
            } else {
                sb.Append(count);
                sb.Append(prev[i]);
                count = 1;
            }
        }
        return sb.ToString();   
    }
}
// @lc code=end

