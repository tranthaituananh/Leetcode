/*
 * @lc app=leetcode id=39 lang=javascript
 *
 * [39] Combination Sum
 */

// @lc code=start
/**
 * @param {number[]} candidates
 * @param {number} target
 * @return {number[][]}
 */
var combinationSum = function (candidates, target) {
    let result = [];
    let current = [];
    candidates.sort((a, b) => a - b);
    helper(candidates, target, 0, current, result);
    return result;
};

var helper = function (candidates, target, start, current, result) {
    if (target === 0) {
        result.push(current.slice());
        return;
    }
    for (let i = start; i < candidates.length; i++) {
        if (candidates[i] > target) {
            break;
        }
        current.push(candidates[i]);
        helper(candidates, target - candidates[i], i, current, result);
        current.pop();
    }
};
// @lc code=end

