/*
 * @lc app=leetcode id=6 lang=javascript
 *
 * [6] Zigzag Conversion
 */

// @lc code=start
/**
 * @param {string} s
 * @param {number} numRows
 * @return {string}
 */
var convert = function (s, numRows) {
    if (numRows == 1) return s;
    let len = s.length;
    let res = '';
    for (let i = 0; i < numRows; i++) {
        let j = i;
        while (j < len) {
            res += s[j];
            if (i != 0 && i != numRows - 1) {
                let k = j + 2 * (numRows - i - 1);
                if (k < len) {
                    res += s[k];
                }
            }
            j += 2 * numRows - 2;
        }
    }
    return res;
};
// @lc code=end

