/*
 * @lc app=leetcode id=13 lang=javascript
 *
 * [13] Roman to Integer
 */

// @lc code=start
/**
 * @param {string} s
 * @return {number}
 */
var romanToInt = function (s) {
    let romanTable = {
        "I": 1,
        "V": 5,
        "X": 10,
        "L": 50,
        "C": 100,
        "D": 500,
        "M": 1000
    }
    let start = s.length;
    let romanVal = romanTable[s[start - 1]];
    start--;
    while (start > 0) {
        romanVal += romanTable[s[start - 1]] < romanTable[s[start]] ? -romanTable[s[start - 1]] : romanTable[s[start - 1]];
        start--;
    }
    return romanVal;
};
// @lc code=end

