# [38. Count and Say](https://leetcode.com/problems/count-and-say/)

## Description

<p>The <strong>count-and-say</strong> sequence is a sequence of digit strings defined by the recursive formula:</p>

<ul>
	<li><code>countAndSay(1) = "1"</code></li>
	<li><code>countAndSay(n)</code> is the way you would "say" the digit string from <code>countAndSay(n-1)</code>, which is then converted into a different digit string.</li>
</ul>

<p>To determine how you "say" a digit string, split it into the <strong>minimal</strong> number of substrings such that each substring contains exactly <strong>one</strong> unique digit. Then for each substring, say the number of digits, then say the digit. Finally, concatenate every said digit.</p>

<p>For example, the saying and conversion for digit string <code>"3322251"</code>:</p>
<img alt="" src="https://assets.leetcode.com/uploads/2020/10/23/countandsay.jpg" style="width: 581px; height: 172px;">
<p>Given a positive integer <code>n</code>, return <em>the </em><code>n<sup>th</sup></code><em> term of the <strong>count-and-say</strong> sequence</em>.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> n = 1
<strong>Output:</strong> "1"
<strong>Explanation:</strong> This is the base case.
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> n = 4
<strong>Output:</strong> "1211"
<strong>Explanation:</strong>
countAndSay(1) = "1"
countAndSay(2) = say "1" = one 1 = "11"
countAndSay(3) = say "11" = two 1's = "21"
countAndSay(4) = say "21" = one 2 + one 1 = "12" + "11" = "1211"
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= n &lt;= 30</code></li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {number} n
 * @return {string}
 */
var countAndSay = function (n) {
    let result = '1';
    for (let i = 1; i < n; i++) {
        result = say(result);
    }
    return result;
};

var say = function (str) {
    let result = '';
    let count = 1;
    let current = str[0];
    for (let i = 1; i < str.length; i++) {
        if (str[i] === current) {
            count++;
        } else {
            result += count + current;
            count = 1;
            current = str[i];
        }
    }
    result += count + current;
    return result;
}
```

### **Python3**

```python
class Solution:
    def countAndSay(self, n: int) -> str:
        if n == 1:
            return '1'
        else:
            return self.count(self.countAndSay(n - 1))
    def count(self, s):
        res = ''
        i = 0
        while i < len(s):
            j = i
            while j < len(s) and s[j] == s[i]:
                j += 1
            res += str(j - i) + s[i]
            i = j
        return res
```

### **C++**

```cpp
class Solution
{
public:
    string countAndSay(int n)
    {
        if (n == 1)
            return "1";
        string s = countAndSay(n - 1);
        string res = "";
        int count = 1;
        for (int i = 0; i < s.size(); i++)
        {
            if (i + 1 < s.size() && s[i] == s[i + 1])
            {
                count++;
            }
            else
            {
                res += to_string(count) + s[i];
                count = 1;
            }
        }
        return res;
    }
};
```

### **C#**

```csharp
public class Solution {
    public string CountAndSay(int n) {
        if (n == 1) {
            return "1";
        }
        string prev = CountAndSay(n - 1);
        StringBuilder sb = new StringBuilder();
        int count = 1;
        for (int i = 0; i < prev.Length; i++) {
            if (i + 1 < prev.Length && prev[i] == prev[i + 1]) {
                count++;
            } else {
                sb.Append(count);
                sb.Append(prev[i]);
                count = 1;
            }
        }
        return sb.ToString();   
    }
}
```