# [20. Valid Parentheses](https://leetcode.com/problems/valid-parentheses/)

## Description

<p>Given a string <code>s</code> containing just the characters <code>'('</code>, <code>')'</code>, <code>'{'</code>, <code>'}'</code>, <code>'['</code> and <code>']'</code>, determine if the input string is valid.</p>

<p>An input string is valid if:</p>

<ol>
	<li>Open brackets must be closed by the same type of brackets.</li>
	<li>Open brackets must be closed in the correct order.</li>
	<li>Every close bracket has a corresponding open bracket of the same type.</li>
</ol>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> s = "()"
<strong>Output:</strong> true
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> s = "()[]{}"
<strong>Output:</strong> true
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> s = "(]"
<strong>Output:</strong> false
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= s.length &lt;= 10<sup>4</sup></code></li>
	<li><code>s</code> consists of parentheses only <code>'()[]{}'</code>.</li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {string} s
 * @return {boolean}
 */
var isValid = function(s) {
    let stack = [];
    let map = new Map();
    map.set('(', ')');
    map.set('[', ']');
    map.set('{', '}');
    for (let i = 0; i < s.length; i++) {
        if (map.has(s[i])) {
            stack.push(s[i]);
        } else {
            if (map.get(stack.pop()) !== s[i]) {
                return false;
            }
        }
    }
    return stack.length === 0;      
};
```

### **Python3**

```python
class Solution:
    def isValid(self, s: str) -> bool:
        stack = []
        for c in s:
            if c in '([{':
                stack.append(c)
            else:
                if not stack:
                    return False
                if c == ')' and stack[-1] != '(':
                    return False
                if c == ']' and stack[-1] != '[':
                    return False
                if c == '}' and stack[-1] != '{':
                    return False
                stack.pop()
        return not stack
```

### **C++**

```cpp
class Solution
{
public:
    bool isValid(string s)
    {
        char c;
        stack<char> st;
        for (int i = 0; i < s.size(); i++)
        {

            switch (s[i])
            {
            case '(':
                st.push(s[i]);
                break;
            case '{':
                st.push(s[i]);
                break;
            case '[':
                st.push(s[i]);
                break;
            case ')':
                if (st.empty())
                {
                    return false;
                }
                if (st.top() != '(')
                {
                    return false;
                }
                st.pop();
                break;
            case '}':
                if (st.empty())
                {
                    return false;
                }
                if (st.top() != '{')
                {
                    return false;
                }
                st.pop();
                break;
            case ']':
                if (st.empty())
                {
                    return false;
                }
                if (st.top() != '[')
                {
                    return false;
                }
                st.pop();
                break;
            default:
                return false;
            }
        }
        return st.empty();
    }
};
```

### **C#**

```csharp
public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s) {
            if (c == '(' || c == '{' || c == '[') {
                stack.Push(c);
            } else if (stack.Count > 0 && ((c == ')' && stack.Peek() == '(') || (c == '}' && stack.Peek() == '{') || (c == ']' && stack.Peek() == '['))) {
                stack.Pop();
            } else {
                return false;
            }
        }
        return stack.Count == 0;
    }
}
```