/*
 * @lc app=leetcode id=30 lang=csharp
 *
 * [30] Substring with Concatenation of All Words
 */

// @lc code=start
public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        IList<int> res = new List<int>();
        if(s == null || s.Length == 0 || words == null || words.Length == 0) return res;
        int wordLen = words[0].Length;
        int wordCount = words.Length;
        int totalLen = wordLen * wordCount;
        if(s.Length < totalLen) return res;
        Dictionary<string, int> wordDict = new Dictionary<string, int>();
        foreach(string word in words) {
            if(wordDict.ContainsKey(word)) {
                wordDict[word]++;
            } else {
                wordDict.Add(word, 1);
            }
        }
        for(int i = 0; i <= s.Length - totalLen; i++) {
            Dictionary<string, int> tempDict = new Dictionary<string, int>(wordDict);
            for(int j = 0; j < wordCount; j++) {
                string word = s.Substring(i + j * wordLen, wordLen);
                if(tempDict.ContainsKey(word)) {
                    if(tempDict[word] == 1) {
                        tempDict.Remove(word);
                    } else {
                        tempDict[word]--;
                    }
                } else {
                    break;
                }
            }
            if(tempDict.Count == 0) {
                res.Add(i);
            }
        }
        return res;
    }
}
// @lc code=end

