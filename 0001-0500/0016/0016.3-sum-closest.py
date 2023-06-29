#
# @lc app=leetcode id=16 lang=python3
#
# [16] 3Sum Closest
#

# @lc code=start
class Solution:
    def threeSumClosest(self, nums: List[int], target: int) -> int:
        nums.sort()
        closestSum,closestDiff = 0, float("inf")
        length = len(nums)
        endIdx = length-1
        for i in range(length-2):
            currentNum = nums[i]
            left, right = i + 1, endIdx
            while left < right:
                currentSum = currentNum + nums[left] + nums[right]
                currentDiff = abs(currentSum-target)
                if currentDiff == 0:
                    return currentSum
                elif currentDiff < closestDiff:
                    closestDiff = currentDiff
                    closestSum = currentSum
                if currentSum > target:
                    right -= 1
                else:
                    left += 1
                    
        return closestSum
# @lc code=end

