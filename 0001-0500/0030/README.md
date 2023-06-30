# [30. Substring with Concatenation of All Words](https://leetcode.com/problems/substring-with-concatenation-of-all-words/)

## Description

<p>You are given a string <code>s</code> and an array of strings <code>words</code>. All the strings of <code>words</code> are of <strong>the same length</strong>.</p>

<p>A <strong>concatenated substring</strong> in <code>s</code> is a substring that contains all the strings of any permutation of <code>words</code> concatenated.</p>

<ul>
	<li>For example, if <code>words = ["ab","cd","ef"]</code>, then <code>"abcdef"</code>, <code>"abefcd"</code>, <code>"cdabef"</code>, <code>"cdefab"</code>, <code>"efabcd"</code>, and <code>"efcdab"</code> are all concatenated strings. <code>"acdbef"</code> is not a concatenated substring because it is not the concatenation of any permutation of <code>words</code>.</li>
</ul>

<p>Return <em>the starting indices of all the concatenated substrings in </em><code>s</code>. You can return the answer in <strong>any order</strong>.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> s = "barfoothefoobarman", words = ["foo","bar"]
<strong>Output:</strong> [0,9]
<strong>Explanation:</strong> Since words.length == 2 and words[i].length == 3, the concatenated substring has to be of length 6.
The substring starting at 0 is "barfoo". It is the concatenation of ["bar","foo"] which is a permutation of words.
The substring starting at 9 is "foobar". It is the concatenation of ["foo","bar"] which is a permutation of words.
The output order does not matter. Returning [9,0] is fine too.
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]
<strong>Output:</strong> []
<strong>Explanation:</strong> Since words.length == 4 and words[i].length == 4, the concatenated substring has to be of length 16.
There is no substring of length 16 is s that is equal to the concatenation of any permutation of words.
We return an empty array.
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]
<strong>Output:</strong> [6,9,12]
<strong>Explanation:</strong> Since words.length == 3 and words[i].length == 3, the concatenated substring has to be of length 9.
The substring starting at 6 is "foobarthe". It is the concatenation of ["foo","bar","the"] which is a permutation of words.
The substring starting at 9 is "barthefoo". It is the concatenation of ["bar","the","foo"] which is a permutation of words.
The substring starting at 12 is "thefoobar". It is the concatenation of ["the","foo","bar"] which is a permutation of words.
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= s.length &lt;= 10<sup>4</sup></code></li>
	<li><code>1 &lt;= words.length &lt;= 5000</code></li>
	<li><code>1 &lt;= words[i].length &lt;= 30</code></li>
	<li><code>s</code> and <code>words[i]</code> consist of lowercase English letters.</li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {string} s
 * @param {string[]} words
 * @return {number[]}
 */
var findSubstring = function(s, words) {
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
```

### **Python3**

```python
class Solution:
    def findSubstring(self, S: str, W: List[str]) -> List[int]:
        if not W: return []
        LS, M, N, C = len(S), len(W), len(W[0]), collections.Counter(W)
        return [i for i in range(LS-M*N+1) if collections.Counter([S[a:a+N] for a in range(i,i+M*N,N)]) == C]
```

### **C++**

```cpp
class Solution
{
public:
    vector<int> findSubstring(string s, vector<string> &words)
    {
        vector<int> res;
        if (words.empty())
            return res;
        int n = s.size(), m = words.size(), len = words[0].size();
        unordered_map<string, int> m1;
        for (auto &a : words)
            ++m1[a];
        for (int i = 0; i < len; ++i)
        {
            unordered_map<string, int> m2;
            int cnt = 0, left = i;
            for (int j = i; j <= n - len; j += len)
            {
                string t = s.substr(j, len);
                if (m1.count(t))
                {
                    ++m2[t];
                    if (m2[t] <= m1[t])
                        ++cnt;
                    else
                    {
                        while (m2[t] > m1[t])
                        {
                            string t1 = s.substr(left, len);
                            --m2[t1];
                            if (m2[t1] < m1[t1])
                                --cnt;
                            left += len;
                        }
                    }
                    if (cnt == m)
                    {
                        res.push_back(left);
                        --m2[s.substr(left, len)];
                        --cnt;
                        left += len;
                    }
                }
                else
                {
                    m2.clear();
                    cnt = 0;
                    left = j + len;
                }
            }
        }
        return res;
    }
};
```

### **C#**

```csharp
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
```