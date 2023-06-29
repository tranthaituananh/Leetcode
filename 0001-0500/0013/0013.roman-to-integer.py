#
# @lc app=leetcode id=13 lang=python3
#
# [13] Roman to Integer
#

# @lc code=start
class Solution:
    def romanToInt(self, s: str) -> int:
        Num = 0
        Roman = {
            'I': 1,
            'V': 5,
            'X': 10,
            'L': 50,
            'C': 100,
            'D': 500,
            'M': 1000,
        }
        Prev = 0
        for letter in s:
            Next = Roman[letter]
            if Prev >= Next:
                Num += Prev
            else:
                Num -= Prev
            Prev = Next
        Num += Next

        return Num
# @lc code=end
