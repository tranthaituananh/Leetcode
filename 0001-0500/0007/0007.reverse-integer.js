/*
 * @lc app=leetcode id=7 lang=javascript
 *
 * [7] Reverse Integer
 */

// @lc code=start
/**
 * @param {number} x
 * @return {number}
 */
var reverse = function (x) {
    let result = 0;
    while (x !== 0) {
        result = result * 10 + x % 10;
        x = x / 10 | 0;
    }
    return (result | 0) === result ? result : 0;
};
// @lc code=end

