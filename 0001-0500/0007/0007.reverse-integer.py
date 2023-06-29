#
# @lc app=leetcode id=7 lang=python3
#
# [7] Reverse Integer
#

# @lc code=start
class Solution:
    def reverse(self, x: int) -> int:
        res = 0
        if x >= 0:
            res= int(str(x)[::-1])
        else:
            res = int(str(x)[::-1][:-1])*-1
        return res if (-2**31 <= res and res <= 2**31 - 1) else 0
# @lc code=end

