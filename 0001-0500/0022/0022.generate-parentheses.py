#
# @lc app=leetcode id=22 lang=python3
#
# [22] Generate Parentheses
#

# @lc code=start
class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        res = []
        def dfs(left, right, s):
            if right == n:
                res.append(s)
            else:
                if left < n:
                    dfs(left + 1, right, s + "(")
                if right < left:
                    dfs(left, right + 1, s + ")")
        dfs(0,0,"")
        return res
# @lc code=end

