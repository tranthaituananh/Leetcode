/*
 * @lc app=leetcode id=40 lang=javascript
 *
 * [40] Combination Sum II
 */

// @lc code=start
/**
 * @param {number[]} candidates
 * @param {number} target
 * @return {number[][]}
 */
var combinationSum2 = function (candidates, target) {
    let result = [];
    let current = [];
    candidates.sort((a, b) => a - b);
    helper(candidates, target, 0, current, result);
    return result;
}

var helper = function (candidates, target, start, current, result) {
    if (target === 0) {
        result.push(current.slice());
        return;
    }
    for (let i = start; i < candidates.length; i++) {
        if (candidates[i] > target) {
            break;
        }
        if (i > start && candidates[i] === candidates[i - 1]) {
            continue;
        }
        current.push(candidates[i]);
        helper(candidates, target - candidates[i], i + 1, current, result);
        current.pop();
    }
};
// @lc code=end

