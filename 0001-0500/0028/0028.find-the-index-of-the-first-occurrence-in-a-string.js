/*
 * @lc app=leetcode id=28 lang=javascript
 *
 * [28] Find the Index of the First Occurrence in a String
 */

// @lc code=start
/**
 * @param {string} haystack
 * @param {string} needle
 * @return {number}
 */
var strStr = function (haystack, needle) {
    const l1 = haystack.length;
    const l2 = needle.length;

    if (l2 > l1) {
        return -1;
    }

    for (let i = 0; i <= l1 - l2; i++) {
        let j;
        for (j = 0; j < l2; j++) {
            if (haystack[i + j] !== needle[j]) {
                break;
            }
        }
        if (j === l2) {
            return i;
        }
    }

    return -1;
};
// @lc code=end

