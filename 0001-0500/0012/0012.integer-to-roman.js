/*
 * @lc app=leetcode id=12 lang=javascript
 *
 * [12] Integer to Roman
 */

// @lc code=start
/**
 * @param {number} num
 * @return {string}
 */
const val = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1]
const rom = ["M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"]

var intToRoman = function (N) {
    let result = "";
    for (let i = 0; i < val.length; i++) {
        while (N >= val[i]) {
            result += rom[i];
            N -= val[i];
        }
    }

    return result;
};
// @lc code=end

