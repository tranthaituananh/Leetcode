#
# @lc app=leetcode id=14 lang=python3
#
# [14] Longest Common Prefix
#

# @lc code=start
import os

class Solution:
    def longestCommonPrefix(self, strs: List[str]) -> str: 
        return os.path.commonprefix(strs)
# @lc code=end

