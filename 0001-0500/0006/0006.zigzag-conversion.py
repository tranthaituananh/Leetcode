#
# @lc app=leetcode id=6 lang=python3
#
# [6] Zigzag Conversion
#

# @lc code=start
class Solution:
    def convert(self, s: str, numRows: int) -> str:
        if numRows == 1:
            return s
        res = [''] * numRows
        row = 0
        step = 1
        for c in s:
            res[row] += c
            if row == 0:
                step = 1
            elif row == numRows - 1:
                step = -1
            row += step
        return ''.join(res) 
# @lc code=end

