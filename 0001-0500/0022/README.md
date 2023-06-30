# [22. Generate Parentheses](https://leetcode.com/problems/generate-parentheses/)

## Description

<p>Given <code>n</code> pairs of parentheses, write a function to <em>generate all combinations of well-formed parentheses</em>.</p>

<p><strong class="example">Example 1:</strong></p>
<pre><strong>Input:</strong> n = 3
<strong>Output:</strong> ["((()))","(()())","(())()","()(())","()()()"]
</pre><p><strong class="example">Example 2:</strong></p>
<pre><strong>Input:</strong> n = 1
<strong>Output:</strong> ["()"]
</pre>
<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= n &lt;= 8</code></li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {number} n
 * @return {string[]}
 */
var generateParenthesis = function(n) {
    let result = [];
    let generate = (left, right, s) => {
        if (left === n && right === n) {
            result.push(s);
            return;
        }
        if (left < n) generate(left + 1, right, s + '(');
        if (right < left) generate(left, right + 1, s + ')');
    };
    generate(0, 0, '');
    return result;
};
```

### **Python3**

```python
class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        res = []
        def dfs(left, right, s):
            if right == n:
                res.append(s)
            else:
                if left < n:
                    dfs(left + 1, right, s + "(")
                if right < left:
                    dfs(left, right + 1, s + ")")
        dfs(0,0,"")
        return res
```

### **C++**

```cpp
class Solution
{
public:
    vector<string> generateParenthesis(int n)
    {
        vector<string> res;
        string s;
        dfs(res, s, n, n);
        return res;
    }

    void dfs(vector<string> &res, string &s, int left, int right)
    {
        if (left == 0 && right == 0)
        {
            res.push_back(s);
            return;
        }

        if (left > 0)
        {
            s.push_back('(');
            dfs(res, s, left - 1, right);
            s.pop_back();
        }

        if (right > left)
        {
            s.push_back(')');
            dfs(res, s, left, right - 1);
            s.pop_back();
        }
    }
};
```

### **C#**

```csharp
public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();
        GenerateParenthesisHelper(result, "", 0, 0, n);
        return result;
    }

    public void GenerateParenthesisHelper(List<string> result, string current, int open, int close, int max) {
        if(current.Length == max * 2) {
            result.Add(current);
            return;
        }
        if(open < max) {
            GenerateParenthesisHelper(result, current + "(", open + 1, close, max);
        }
        if(close < open) {
            GenerateParenthesisHelper(result, current + ")", open, close + 1, max);
        }
    }
}
```