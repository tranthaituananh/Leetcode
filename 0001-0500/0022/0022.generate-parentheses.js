/*
 * @lc app=leetcode id=22 lang=javascript
 *
 * [22] Generate Parentheses
 */

// @lc code=start
/**
 * @param {number} n
 * @return {string[]}
 */
var generateParenthesis = function (n) {
    let result = [];
    let generate = (left, right, s) => {
        if (left === n && right === n) {
            result.push(s);
            return;
        }
        if (left < n) generate(left + 1, right, s + '(');
        if (right < left) generate(left, right + 1, s + ')');
    };
    generate(0, 0, '');
    return result;
};
// @lc code=end

