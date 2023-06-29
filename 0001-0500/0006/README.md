# [6. ZigZag Conversion](https://leetcode.com/problems/zigzag-conversion/)

## Description

<p>The string <code>"PAYPALISHIRING"</code> is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)</p>

<pre>P   A   H   N
A P L S I I G
Y   I   R
</pre>

<p>And then read line by line: <code>"PAHNAPLSIIGYIR"</code></p>

<p>Write the code that will take a string and make this conversion given a number of rows:</p>

<pre>string convert(string s, int numRows);
</pre>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> s = "PAYPALISHIRING", numRows = 3
<strong>Output:</strong> "PAHNAPLSIIGYIR"
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> s = "PAYPALISHIRING", numRows = 4
<strong>Output:</strong> "PINALSIGYAHRPI"
<strong>Explanation:</strong>
P     I    N
A   L S  I G
Y A   H R
P     I
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> s = "A", numRows = 1
<strong>Output:</strong> "A"
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= s.length &lt;= 1000</code></li>
	<li><code>s</code> consists of English letters (lower-case and upper-case), <code>','</code> and <code>'.'</code>.</li>
	<li><code>1 &lt;= numRows &lt;= 1000</code></li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {string} s
 * @param {number} numRows
 * @return {string}
 */
var convert = function(s, numRows) {
    if (numRows == 1) return s;
    let len = s.length;
    let res = '';
    for (let i = 0; i < numRows; i++) {
        let j = i;
        while (j < len) {
            res += s[j];
            if (i != 0 && i != numRows - 1) {
                let k = j + 2 * (numRows - i - 1);
                if (k < len) {
                    res += s[k];
                }
            }
            j += 2 * numRows - 2;
        }
    }
    return res;  
};
```

### **Python3**

```python
class Solution:
    def convert(self, s: str, numRows: int) -> str:
        if numRows == 1:
            return s
        res = [''] * numRows
        row = 0
        step = 1
        for c in s:
            res[row] += c
            if row == 0:
                step = 1
            elif row == numRows - 1:
                step = -1
            row += step
        return ''.join(res) 
```

### **C++**

```cpp
class Solution {
public:
    string convert(string s, int numRows) {

        if (numRows == 1) return s;

        string ret;
        int n = s.size();
        int cycleLen = 2 * numRows - 2;

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j + i < n; j += cycleLen) {
                ret += s[j + i];
                if (i != 0 && i != numRows - 1 && j + cycleLen - i < n)
                    ret += s[j + cycleLen - i];
            }
        }
        return ret;
    }
};
```

### **C#**

```csharp
public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1) return s;
        var rows = new List<StringBuilder>();
        for (int i = 0; i < Math.Min(numRows, s.Length); i++) {
            rows.Add(new StringBuilder());
        }
        int curRow = 0;
        bool goingDown = false;
        foreach (char c in s) {
            rows[curRow].Append(c);
            if (curRow == 0 || curRow == numRows - 1) goingDown = !goingDown;
            curRow += goingDown ? 1 : -1;
        }
        var ret = new StringBuilder();
        foreach (var row in rows) ret.Append(row);
        return ret.ToString();
    }
}
```