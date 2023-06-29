# [9. Palindrome Number](https://leetcode.com/problems/palindrome-number/)

## Description

<p>Given an integer <code>x</code>, return <code>true</code><em> if </em><code>x</code><em> is a </em><em><strong>palindrome</strong></em><em>, and </em><code>false</code><em> otherwise</em>.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> x = 121
<strong>Output:</strong> true
<strong>Explanation:</strong> 121 reads as 121 from left to right and from right to left.
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> x = -121
<strong>Output:</strong> false
<strong>Explanation:</strong> From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> x = 10
<strong>Output:</strong> false
<strong>Explanation:</strong> Reads 01 from right to left. Therefore it is not a palindrome.
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>-2<sup>31</sup>&nbsp;&lt;= x &lt;= 2<sup>31</sup>&nbsp;- 1</code></li>
</ul>

<strong>Follow up:</strong> Could you solve it without converting the integer to a string?
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {number} x
 * @return {boolean}
 */
var isPalindrome = function (x) {
    if (x < 0 || (x !== 0 && x % 10 === 0)) {
        return false
    }
    else {
        var res = 0
        var temp = x
        while (temp > 0) {
            res = res * 10 + temp % 10
            temp = Math.floor(temp / 10)
        }
        if (res === x) {
            return true
        }
        return false
    }
};
```

### **Python3**

```python
class Solution:
    def isPalindrome(self, x: int) -> bool:
        return str(x)[::-1] == str(x)
```

### **C++**

```cpp
class Solution
{
public:
    bool isPalindrome(int x)
    {
        if (x < 0 || (x % 10 == 0 && x != 0))
            return false;
        int res = 0;
        while (res < x)
        {
            res = res * 10 + x % 10;
            x /= 10;
        }

        return x == res || x == res / 10;
    }
};
```

### **C#**

```csharp
public class Solution {
    public bool IsPalindrome(int x) {
        if (x < 0 || (x % 10 == 0 && x != 0)) return false;
        int rev = 0;
        while (x > rev) {
            rev = rev * 10 + x % 10;
            x /= 10;
        }
        return x == rev || x == rev / 10;
    }
}
```