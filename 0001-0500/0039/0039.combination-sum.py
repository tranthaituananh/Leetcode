#
# @lc app=leetcode id=39 lang=python3
#
# [39] Combination Sum
#

# @lc code=start
class Solution:
    def combinationSum(self, candidates: List[int], target: int) -> List[List[int]]:
        res = []
        candidates.sort()
        def dfs(i, target, path):
            if target == 0:
                res.append(path)
                return
            for j in range(i, len(candidates)):
                if candidates[j] > target:
                    break
                dfs(j, target - candidates[j], path + [candidates[j]])
        dfs(0, target, [])
        return res
# @lc code=end

