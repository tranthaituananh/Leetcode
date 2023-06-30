/*
 * @lc app=leetcode id=30 lang=javascript
 *
 * [30] Substring with Concatenation of All Words
 */

// @lc code=start
/**
 * @param {string} s
 * @param {string[]} words
 * @return {number[]}
 */
var findSubstring = function (s, words) {
    let result = [];
    let wordLength = words[0].length;
    let wordCount = words.length;
    let wordMap = new Map();
    for (let i = 0; i < wordCount; i++) {
        let count = wordMap.get(words[i]) || 0;
        wordMap.set(words[i], count + 1);
    }
    for (let i = 0; i < s.length - wordLength * wordCount + 1; i++) {
        let seen = new Map();
        let j = 0;
        for (; j < wordCount; j++) {
            let word = s.substr(i + j * wordLength, wordLength);
            if (!wordMap.has(word)) {
                break;
            }
            let count = seen.get(word) || 0;
            seen.set(word, count + 1);
            if (seen.get(word) > wordMap.get(word)) {
                break;
            }
        }
        if (j === wordCount) {
            result.push(i);
        }
    }
    return result;
};
// @lc code=end

