/*
 * @lc app=leetcode id=29 lang=csharp
 *
 * [29] Divide Two Integers
 */

// @lc code=start
public class Solution {
    public int Divide(int dividend, int divisor) {
        if(dividend == int.MinValue && divisor == -1) return int.MaxValue;
        int sign = (dividend < 0) ^ (divisor < 0) ? -1 : 1;
        long dvd = Math.Abs((long)dividend);
        long dvs = Math.Abs((long)divisor);
        int res = 0;
        while(dvd >= dvs) {
            long temp = dvs, multiple = 1;
            while(dvd >= (temp << 1)) {
                temp <<= 1;
                multiple <<= 1;
            }
            dvd -= temp;
            res += (int)multiple;
        }
        return sign == 1 ? res : -res;
    }
}
// @lc code=end

