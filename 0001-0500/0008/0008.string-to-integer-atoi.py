#
# @lc app=leetcode id=8 lang=python3
#
# [8] String to Integer (atoi)
#

# @lc code=start
class Solution:
    def myAtoi(self, s: str) -> int:
        s = s.strip()
        if not s:
            return 0
        sign = 1
        if s[0] == '-':
            sign = -1
            s = s[1:]
        elif s[0] == '+':
            s = s[1:]
        res = 0
        for c in s:
            if not c.isdigit():
                break
            res = res * 10 + int(c)
        return max(-2**31, min(sign * res, 2**31 - 1))
# @lc code=end

