/*
 * @lc app=leetcode id=34 lang=javascript
 *
 * [34] Find First and Last Position of Element in Sorted Array
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var searchRange = function (nums, target) {
    let left = 0;
    let right = nums.length - 1;
    let result = [-1, -1];

    while (left <= right) {
        let mid = Math.floor((left + right) / 2);

        if (nums[mid] === target) {
            let i = mid;
            let j = mid;

            while (nums[i] === target && i >= 0) {
                i--;
            }
            while (nums[j] === target && j < nums.length) {
                j++;
            }

            result[0] = i + 1;
            result[1] = j - 1;
            break;
        }
        else if (nums[mid] < target) {
            left = mid + 1;
        }
        else {
            right = mid - 1;
        }
    }

    return result;
};
// @lc code=end

