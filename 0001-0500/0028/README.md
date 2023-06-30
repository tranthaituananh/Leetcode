# [28. Find the Index of the First Occurrence in a String](https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/)

## Description

<p>Given two strings <code>needle</code> and <code>haystack</code>, return the index of the first occurrence of <code>needle</code> in <code>haystack</code>, or <code>-1</code> if <code>needle</code> is not part of <code>haystack</code>.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> haystack = "sadbutsad", needle = "sad"
<strong>Output:</strong> 0
<strong>Explanation:</strong> "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> haystack = "leetcode", needle = "leeto"
<strong>Output:</strong> -1
<strong>Explanation:</strong> "leeto" did not occur in "leetcode", so we return -1.
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= haystack.length, needle.length &lt;= 10<sup>4</sup></code></li>
	<li><code>haystack</code> and <code>needle</code> consist of only lowercase English characters.</li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
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
```

### **Python3**

```python
class Solution:
    def strStr(self, haystack: str, needle: str) -> int:
        if not needle:
            return 0
        if not haystack:
            return -1
        for i in range(len(haystack) - len(needle) + 1):
            if haystack[i:i+len(needle)] == needle:
                return i
        return -1
```

### **C++**

```cpp
class Solution
{
public:
    int strStr(string haystack, string needle)
    {
        if (needle.empty())
            return 0;
        int n = haystack.size(), m = needle.size();
        for (int i = 0; i < n - m + 1; ++i)
        {
            int j = 0;
            for (; j < m; ++j)
            {
                if (haystack[i + j] != needle[j])
                    break;
            }
            if (j == m)
                return i;
        }
        return -1;
    }
};
```

### **C#**

```csharp
public class Solution {
    public int StrStr(string haystack, string needle) {
        if (needle.Length == 0) {
            return 0;
        }

        int n = haystack.Length;
        int m = needle.Length;

        for (int i = 0; i <= n - m; i++) {
            int j;
            for (j = 0; j < m; j++) {
                if (haystack[i + j] != needle[j]) {
                    break;
                }
            }
            if (j == m) {
                return i;
            }
        }

        return -1;
    }
}
```