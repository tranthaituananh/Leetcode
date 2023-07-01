/*
 * @lc app=leetcode id=35 lang=javascript
 *
 * [35] Search Insert Position
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number}
 */
var searchInsert = function (nums, target) {
    let len = nums.length
    if (target > nums[len - 1]) {
        return len
    } if (target < nums[0]) {
        return 0
    }
    for (let i = 0; i < len; i++) {
        if (nums[i] == target) {
            return i
        } if (target > nums[i] && target < nums[i + 1]) {
            return i + 1
        }
    }
};
// @lc code=end

