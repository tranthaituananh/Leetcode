#
# @lc app=leetcode id=34 lang=python3
#
# [34] Find First and Last Position of Element in Sorted Array
#

# @lc code=start
class Solution:
    def searchRange(self, nums: List[int], target: int) -> List[int]:
        left = self.searchLeft(nums, target)
        right = self.searchRight(nums, target)
        return [left, right]
    
    def searchLeft(self, nums, target):
        i, j = 0, len(nums) - 1
        while i <= j:
            mid = (i + j) // 2
            if nums[mid] < target:
                i = mid + 1
            else:
                j = mid - 1
        if i < len(nums) and nums[i] == target:
            return i
        return -1
    
    def searchRight(self, nums, target):
        i, j = 0, len(nums) - 1
        while i <= j:
            mid = (i + j) // 2
            if nums[mid] <= target:
                i = mid + 1
            else:
                j = mid - 1
        if j >= 0 and nums[j] == target:
            return j
        return -1
# @lc code=end

