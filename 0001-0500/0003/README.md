# [3. Longest Substring Without Repeating Characters](https://leetcode.com/problems/longest-substring-without-repeating-characters/)

## Description

<strong>substring</strong></div></div></div></span> without repeating characters.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> s = "abcabcbb"
<strong>Output:</strong> 3
<strong>Explanation:</strong> The answer is "abc", with the length of 3.
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> s = "bbbbb"
<strong>Output:</strong> 1
<strong>Explanation:</strong> The answer is "b", with the length of 1.
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> s = "pwwkew"
<strong>Output:</strong> 3
<strong>Explanation:</strong> The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>0 &lt;= s.length &lt;= 5 * 10<sup>4</sup></code></li>
	<li><code>s</code> consists of English letters, digits, symbols and spaces.</li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
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
```

### **Python3**

```python
class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        if not s:
            return 0
        max_len = 1
        for i in range(len(s)):
            for j in range(i+1, len(s)):
                if s[j] in s[i:j]:
                    break
                max_len = max(max_len, j-i+1)
        return max_len
```

### **C++**

```cpp
class Solution
{
public:
    int lengthOfLongestSubstring(string s)
    {
        int n = s.length();
        int ans = 0;
        int i = 0, j = 0;
        unordered_set<char> st;

        while (i < n && j < n)
        {
            if (st.find(s[j]) == st.end())
            {
                st.insert(s[j++]);
                ans = max(ans, j - i);
            }
            else
            {
                st.erase(s[i++]);
            }
        }

        return ans;
    }
};
```

### **C#**

```csharp
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var len=0;
        var n=s.Length;
        var i=0; 
        var dict=new Dictionary<char,int>();//char and indexes
        var start=0;// from where we start calculating maxLength
       
        while(i<n)
        {
            if(dict.ContainsKey(s[i]))
            {
                var lastIndexOfChar=dict[s[i]];
                //if the last occurence already out no need to change start
                start=lastIndexOfChar>=start?lastIndexOfChar+1:start;                
                dict[s[i]]=i; 
                            
            }
            else
            {
                dict.Add(s[i],i);
            }           
            i++;
            len=Math.Max(len,i-start);        
                             


        }
        
        return len;
    }
}
```