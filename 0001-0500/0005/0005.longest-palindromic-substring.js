/*
 * @lc app=leetcode id=5 lang=javascript
 *
 * [5] Longest Palindromic Substring
 */

// @lc code=start
/**
 * @param {string} s
 * @return {string}
 */
var longestPalindrome = function (s) {
    let len = s.length;
    let max = 0;
    let res = '';
    for (let i = 0; i < len; i++) {
        let left = i;
        let right = i;
        while (left >= 0 && right < len && s[left] == s[right]) {
            left--;
            right++;
        }
        if (right - left - 1 > max) {
            max = right - left - 1;
            res = s.substring(left + 1, right);
        }
        left = i;
        right = i + 1;
        while (left >= 0 && right < len && s[left] == s[right]) {
            left--;
            right++;
        }
        if (right - left - 1 > max) {
            max = right - left - 1;
            res = s.substring(left + 1, right);
        }
    }
    return res;
};
// @lc code=end

