# [14. Longest Common Prefix](https://leetcode.com/problems/longest-common-prefix/)

## Description

<p>Write a function to find the longest common prefix string amongst an array of strings.</p>

<p>If there is no common prefix, return an empty string <code>""</code>.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> strs = ["flower","flow","flight"]
<strong>Output:</strong> "fl"
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> strs = ["dog","racecar","car"]
<strong>Output:</strong> ""
<strong>Explanation:</strong> There is no common prefix among the input strings.
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= strs.length &lt;= 200</code></li>
	<li><code>0 &lt;= strs[i].length &lt;= 200</code></li>
	<li><code>strs[i]</code> consists of only lowercase English letters.</li>
</ul>
</div>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {string[]} strs
 * @return {string}
 */
var longestCommonPrefix = function (strs) {
  if (strs === null || strs.length === 0) {
    return "";
  }
  for (let i = 0; i < strs[0].length; i++) {
    let c = strs[0].charAt(i);
    for (let j = 1; j < strs.length; j++) {
      if (i === strs[j].length || strs[j].charAt(i) !== c)
        return strs[0].substring(0, i);
    }
  }
  return strs[0];
};
```

### **Python3**

```python
import os

class Solution:
    def longestCommonPrefix(self, strs: List[str]) -> str: 
        return os.path.commonprefix(strs)
```

### **C++**

```cpp
class Solution
{
public:
    string longestCommonPrefix(vector<string> &strs)
    {
        int n = strs.size();
        if (n == 0)
        {
            return "";
        }

        string res = "";
        sort(begin(strs), end(strs));
        string a = strs[0];
        string b = strs[n - 1];

        for (int i = 0; i < a.size(); i++)
        {
            if (a[i] == b[i])
            {
                res += a[i];
            }
            else
            {
                break;
            }
        }

        return res;
    }
};
```

### **C#**

```csharp
public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if (strs.Length == 0) return "";
        var sb = new StringBuilder();
        var minLen = strs.Min(s => s.Length);
        for (int i = 0; i < minLen; i++) {
            var c = strs[0][i];
            if (strs.All(s => s[i] == c)) {
                sb.Append(c);
            } else {
                break;
            }
        }
        return sb.ToString();
    }
}
```
