# [7. Reverse Integer](https://leetcode.com/problems/reverse-integer/)

## Description

<p>Given a signed 32-bit integer <code>x</code>, return <code>x</code><em> with its digits reversed</em>. If reversing <code>x</code> causes the value to go outside the signed 32-bit integer range <code>[-2<sup>31</sup>, 2<sup>31</sup> - 1]</code>, then return <code>0</code>.</p>

<p><strong>Assume the environment does not allow you to store 64-bit integers (signed or unsigned).</strong></p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> x = 123
<strong>Output:</strong> 321
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> x = -123
<strong>Output:</strong> -321
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> x = 120
<strong>Output:</strong> 21
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>-2<sup>31</sup> &lt;= x &lt;= 2<sup>31</sup> - 1</code></li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {number} x
 * @return {number}
 */
var reverse = function (x) {
  let result = 0;
  while (x !== 0) {
    result = result * 10 + (x % 10);
    x = (x / 10) | 0;
  }
  return (result | 0) === result ? result : 0;
};
```

### **Python3**

```python
class Solution:
    def reverse(self, x: int) -> int:
        res = 0
        if x >= 0:
            res= int(str(x)[::-1])
        else:
            res = int(str(x)[::-1][:-1])*-1
        return res if (-2**31 <= res and res <= 2**31 - 1) else 0
```

### **C++**

```cpp
class Solution
{
public:
    int reverse(int x)
    {
        int rev = 0;
        while (x != 0)
        {
            int pop = x % 10;
            x /= 10;

            if (rev > INT_MAX / 10 || (rev == INT_MAX / 10 && pop > 7))
                return 0;
            if (rev < INT_MIN / 10 || (rev == INT_MIN / 10 && pop < -8))
                return 0;

            rev = rev * 10 + pop;
        }
        return rev;
    }
};
```

### **C#**

```csharp
public class Solution {
    public int Reverse(int x) {
        int rev = 0;
        while (x != 0) {
            int pop = x % 10;
            x /= 10;
            if (rev > int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop > 7)) return 0;
            if (rev < int.MinValue / 10 || (rev == int.MinValue / 10 && pop < -8)) return 0;
            rev = rev * 10 + pop;
        }
        return rev;
    }
}
```
