#
# @lc app=leetcode id=3 lang=python3
#
# [3] Longest Substring Without Repeating Characters
#

# @lc code=start
class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        if not s:
            return 0
        max_len = 1
        for i in range(len(s)):
            for j in range(i+1, len(s)):
                if s[j] in s[i:j]:
                    break
                max_len = max(max_len, j-i+1)
        return max_len
# @lc code=end

