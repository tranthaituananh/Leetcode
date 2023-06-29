/*
 * @lc app=leetcode id=7 lang=csharp
 *
 * [7] Reverse Integer
 */

// @lc code=start
public class Solution {
    public int Reverse(int x) {
        int rev = 0;
        while (x != 0) {
            int pop = x % 10;
            x /= 10;
            if (rev > int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop > 7)) return 0;
            if (rev < int.MinValue / 10 || (rev == int.MinValue / 10 && pop < -8)) return 0;
            rev = rev * 10 + pop;
        }
        return rev;
    }
}
// @lc code=end

