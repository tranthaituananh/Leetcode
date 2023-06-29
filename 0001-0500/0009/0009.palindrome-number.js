/*
 * @lc app=leetcode id=9 lang=javascript
 *
 * [9] Palindrome Number
 */

// @lc code=start
/**
 * @param {number} x
 * @return {boolean}
 */
var isPalindrome = function (x) {
    if (x < 0 || (x !== 0 && x % 10 === 0)) {
        return false
    }
    else {
        var res = 0
        var temp = x
        while (temp > 0) {
            res = res * 10 + temp % 10
            temp = Math.floor(temp / 10)
        }
        if (res === x) {
            return true
        }
        return false
    }
};
// @lc code=end

