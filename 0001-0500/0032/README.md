# [32. Longest Valid Parentheses](https://leetcode.com/problems/longest-valid-parentheses/)

## Description

<p>Given a string containing just the characters <code>'('</code> and <code>')'</code>, return <em>the length of the longest valid (well-formed) parentheses </em><em>substring</em>.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> s = "(()"
<strong>Output:</strong> 2
<strong>Explanation:</strong> The longest valid parentheses substring is "()".
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> s = ")()())"
<strong>Output:</strong> 4
<strong>Explanation:</strong> The longest valid parentheses substring is "()()".
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> s = ""
<strong>Output:</strong> 0
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>0 &lt;= s.length &lt;= 3 * 10<sup>4</sup></code></li>
	<li><code>s[i]</code> is <code>'('</code>, or <code>')'</code>.</li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {string} s
 * @return {number}
 */
 var longestValidParentheses = function(s) {
    var stack = [];
    var max = 0;
    var start = 0;
    for (var i = 0; i < s.length; i++) {
        if (s[i] === '(') {
            stack.push(i);
        } else {
            if (stack.length === 0) {
                start = i + 1;
            } else {
                stack.pop();
                if (stack.length === 0) {
                    max = Math.max(max, i - start + 1);
                } else {
                    max = Math.max(max, i - stack[stack.length - 1]);
                }
            }
        }
    }
    return max;  
};
```

### **Python3**

```python
class Solution:
    def longestValidParentheses(self, s: str) -> int:
        stack = [-1]
        longest = 0
        for i, c in enumerate(s):
            if c == '(':
                stack.append(i)
            else:
                stack.pop()
                if not stack:
                    stack.append(i)
                else:
                    longest = max(longest, i - stack[-1])
        return longest
```

### **C++**

```cpp
class Solution
{
public:
    int longestValidParentheses(string s)
    {
        int n = s.size();
        vector<int> dp(n, 0);
        int res = 0;
        for (int i = 1; i < n; ++i)
        {
            if (s[i] == ')')
            {
                if (s[i - 1] == '(')
                {
                    dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                }
                else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
                {
                    dp[i] = dp[i - 1] + (i - dp[i - 1] >= 2 ? dp[i - dp[i - 1] - 2] : 0) + 2;
                }
                res = max(res, dp[i]);
            }
        }
        return res;
    }
};
```

### **C#**

```csharp
public class Solution {
    public int LongestValidParentheses(string s) {
        int max = 0;
        int[] dp = new int[s.Length];
        for(int i = 1; i < s.Length; i++) {
            if(s[i] == ')') {
                if(s[i - 1] == '(') {
                    dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                } else if(i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(') {
                    dp[i] = dp[i - 1] + ((i - dp[i - 1]) >= 2 ? dp[i - dp[i - 1] - 2] : 0) + 2;
                }
                max = Math.Max(max, dp[i]);
            }
        }
        return max;
    }
}
```