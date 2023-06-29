/*
 * @lc app=leetcode id=8 lang=csharp
 *
 * [8] String to Integer (atoi)
 */

// @lc code=start
public class Solution {
    public int MyAtoi(string s) {
        int i = 0, sign = 1, res = 0;
        if (s.Length == 0) return 0;
        while (i < s.Length && s[i] == ' ') i++;
        if (i < s.Length && (s[i] == '+' || s[i] == '-')) {
            sign = s[i++] == '+' ? 1 : -1;
        }
        while (i < s.Length && s[i] >= '0' && s[i] <= '9') {
            if (res > int.MaxValue / 10 || (res == int.MaxValue / 10 && s[i] - '0' > 7)) {
                return sign == 1 ? int.MaxValue : int.MinValue;
            }
            res = res * 10 + (s[i++] - '0');
        }
        return res * sign;
    }
}
// @lc code=end

