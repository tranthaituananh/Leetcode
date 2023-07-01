#
# @lc app=leetcode id=38 lang=python3
#
# [38] Count and Say
#

# @lc code=start
class Solution:
    def countAndSay(self, n: int) -> str:
        if n == 1:
            return '1'
        else:
            return self.count(self.countAndSay(n - 1))
    def count(self, s):
        res = ''
        i = 0
        while i < len(s):
            j = i
            while j < len(s) and s[j] == s[i]:
                j += 1
            res += str(j - i) + s[i]
            i = j
        return res
# @lc code=end

