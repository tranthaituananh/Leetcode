/*
 * @lc app=leetcode id=8 lang=javascript
 *
 * [8] String to Integer (atoi)
 */

// @lc code=start
/**
 * @param {string} s
 * @return {number}
 */
var myAtoi = function (s) {
    const num = Number(s.matchAll(/^\s*((-|\+)?[0-9]+)/gi).next().value?.[1]) || 0;
    return num <= -2147483648 ? -2147483648 : num >= 2147483647 ? 2147483647 : num;
};
// @lc code=end

