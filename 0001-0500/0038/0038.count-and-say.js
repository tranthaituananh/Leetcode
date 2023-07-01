/*
 * @lc app=leetcode id=38 lang=javascript
 *
 * [38] Count and Say
 */

// @lc code=start
/**
 * @param {number} n
 * @return {string}
 */
var countAndSay = function (n) {
    let result = '1';
    for (let i = 1; i < n; i++) {
        result = say(result);
    }
    return result;
};

var say = function (str) {
    let result = '';
    let count = 1;
    let current = str[0];
    for (let i = 1; i < str.length; i++) {
        if (str[i] === current) {
            count++;
        } else {
            result += count + current;
            count = 1;
            current = str[i];
        }
    }
    result += count + current;
    return result;
}
// @lc code=end

