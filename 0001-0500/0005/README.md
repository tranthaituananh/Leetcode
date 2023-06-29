# [5. Longest Palindromic Substring](https://leetcode.com/problems/longest-palindromic-substring/)

## Description

<p>Given a string <code>s</code>, return <em>the longest</em> <em>palindromic </em><em>substring</em></span> in <code>s</code>.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> s = "babad"
<strong>Output:</strong> "bab"
<strong>Explanation:</strong> "aba" is also a valid answer.
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> s = "cbbd"
<strong>Output:</strong> "bb"
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= s.length &lt;= 1000</code></li>
	<li><code>s</code> consist of only digits and English letters.</li>
</ul>
</div>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {string} s
 * @return {string}
 */
var longestPalindrome = function (s) {
  let len = s.length;
  let max = 0;
  let res = "";
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
```

### **Python3**

```python
class Solution:
    def longestPalindrome(self, s: str) -> str:
        if len(s) == 0:
            return 0
        max_len = 1
        start=0
        for i in range(len(s)):
        	if i-max_len >=1 and s[i-max_len-1:i+1]==s[i-max_len-1:i+1][::-1]:
        		start=i-max_len-1
        		max_len+=2
        		continue

        	if i-max_len >=0 and s[i-max_len:i+1]==s[i-max_len:i+1][::-1]:
        		start=i-max_len
        		max_len+=1
        return s[start:start+max_len]
```

### **C++**

```cpp
class Solution
{
public:
    string ans = "";
    void expand(string &s, int left, int right)
    {
        while (left >= 0 && right < s.size())
        {
            if (s[left] != s[right])
                break;
            left--, right++;
        }
        if (ans.size() < right - left)
            ans = s.substr(left + 1, right - left - 1);
    }
    string longestPalindrome(string s)
    {
        for (int i = 0; i < s.size(); i++)
        {
            expand(s, i, i);
            expand(s, i, i + 1);
        }
        return ans;
    }
};
```

### **C#**

```csharp
public class Solution {
    public string LongestPalindrome(string s) {
        int maxLength = 0, startIndex = 0;
        for (int i = 0; i < s.Length; i++) {
            int start = i, end = i;
            while(end < s.Length-1 && s[start] == s[end+1])
                end++;

            while(end < s.Length-1 && start > 0 && s[start-1] == s[end+1]) {
                start--;
                end++;
            }
            if(maxLength < end - start + 1) {
                maxLength = end - start + 1;
                startIndex = start;
            }
        }
        return s.Substring(startIndex, maxLength);
    }
}
```
