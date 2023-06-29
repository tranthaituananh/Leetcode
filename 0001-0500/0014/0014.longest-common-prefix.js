/*
 * @lc app=leetcode id=14 lang=javascript
 *
 * [14] Longest Common Prefix
 */

// @lc code=start
/**
 * @param {string[]} strs
 * @return {string}
 */
var longestCommonPrefix = function (strs) {
    if (strs === null || strs.length === 0) {
        return ""
    }
    for (let i = 0; i < strs[0].length; i++) {
        let c = strs[0].charAt(i)
        for (let j = 1; j < strs.length; j++) {
            if (i === strs[j].length || strs[j].charAt(i) !== c)
                return strs[0].substring(0, i)
        }
    }
    return strs[0];
};
// @lc code=end

