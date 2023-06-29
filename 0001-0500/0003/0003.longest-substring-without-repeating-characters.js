/*
 * @lc app=leetcode id=3 lang=javascript
 *
 * [3] Longest Substring Without Repeating Characters
 */

// @lc code=start
/**
 * @param {string} s
 * @return {number}
 */
var lengthOfLongestSubstring = function (s) {
    let l = 0;
    let max = 0;
    let set = new Set();
    for (let r = 0; r < s.length; r++) {
        while (set.has(s.charAt(r))) {
            set.delete(s.charAt(l));
            l++;
        }
        set.add(s.charAt(r));
        if (set.size > max) max = set.size;
    }
    return max;
};
// @lc code=end

