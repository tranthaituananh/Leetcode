#
# @lc app=leetcode id=40 lang=python3
#
# [40] Combination Sum II
#

# @lc code=start
class Solution:
    def combinationSum2(self, candidates: List[int], target: int) -> List[List[int]]:
        res = []
        candidates.sort()
        def dfs(i, target, path):
            if target == 0:
                res.append(path)
                return
            for j in range(i, len(candidates)):
                if j > i and candidates[j] == candidates[j - 1]:
                    continue
                if candidates[j] > target:
                    break
                dfs(j + 1, target - candidates[j], path + [candidates[j]])
        dfs(0, target, [])
        return res  
# @lc code=end

