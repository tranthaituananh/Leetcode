#
# @lc app=leetcode id=5 lang=python3
#
# [5] Longest Palindromic Substring
#

# @lc code=start
class Solution:
    def longestPalindrome(self, s: str) -> str:
        if len(s) == 0:
            return 0
        max_len = 1
        start=0
        for i in range(len(s)):
        	if i-max_len >=1 and s[i-max_len-1:i+1]==s[i-max_len-1:i+1][::-1]:
        		start=i-max_len-1
        		max_len+=2
        		continue

        	if i-max_len >=0 and s[i-max_len:i+1]==s[i-max_len:i+1][::-1]:
        		start=i-max_len
        		max_len+=1
        return s[start:start+max_len]
# @lc code=end

