/*
 * @lc app=leetcode id=20 lang=javascript
 *
 * [20] Valid Parentheses
 */

// @lc code=start
/**
 * @param {string} s
 * @return {boolean}
 */
var isValid = function (s) {
    let stack = [];
    let map = new Map();
    map.set('(', ')');
    map.set('[', ']');
    map.set('{', '}');
    for (let i = 0; i < s.length; i++) {
        if (map.has(s[i])) {
            stack.push(s[i]);
        } else {
            if (map.get(stack.pop()) !== s[i]) {
                return false;
            }
        }
    }
    return stack.length === 0;
};
// @lc code=end

