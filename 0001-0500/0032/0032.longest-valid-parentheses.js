/*
 * @lc app=leetcode id=32 lang=javascript
 *
 * [32] Longest Valid Parentheses
 */

// @lc code=start
/**
 * @param {string} s
 * @return {number}
 */
var longestValidParentheses = function (s) {
    var stack = [];
    var max = 0;
    var start = 0;
    for (var i = 0; i < s.length; i++) {
        if (s[i] === '(') {
            stack.push(i);
        } else {
            if (stack.length === 0) {
                start = i + 1;
            } else {
                stack.pop();
                if (stack.length === 0) {
                    max = Math.max(max, i - start + 1);
                } else {
                    max = Math.max(max, i - stack[stack.length - 1]);
                }
            }
        }
    }
    return max;
};
// @lc code=end

