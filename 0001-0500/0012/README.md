# [12. Integer to Roman](https://leetcode.com/problems/integer-to-roman/)

## Description

<p>Roman numerals are represented by seven different symbols:&nbsp;<code>I</code>, <code>V</code>, <code>X</code>, <code>L</code>, <code>C</code>, <code>D</code> and <code>M</code>.</p>

<pre><strong>Symbol</strong>       <strong>Value</strong>
I             1
V             5
X             10
L             50
C             100
D             500
M             1000</pre>

<p>For example,&nbsp;<code>2</code> is written as <code>II</code>&nbsp;in Roman numeral, just two one's added together. <code>12</code> is written as&nbsp;<code>XII</code>, which is simply <code>X + II</code>. The number <code>27</code> is written as <code>XXVII</code>, which is <code>XX + V + II</code>.</p>

<p>Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not <code>IIII</code>. Instead, the number four is written as <code>IV</code>. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as <code>IX</code>. There are six instances where subtraction is used:</p>

<ul>
	<li><code>I</code> can be placed before <code>V</code> (5) and <code>X</code> (10) to make 4 and 9.&nbsp;</li>
	<li><code>X</code> can be placed before <code>L</code> (50) and <code>C</code> (100) to make 40 and 90.&nbsp;</li>
	<li><code>C</code> can be placed before <code>D</code> (500) and <code>M</code> (1000) to make 400 and 900.</li>
</ul>

<p>Given an integer, convert it to a roman numeral.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> num = 3
<strong>Output:</strong> "III"
<strong>Explanation:</strong> 3 is represented as 3 ones.
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> num = 58
<strong>Output:</strong> "LVIII"
<strong>Explanation:</strong> L = 50, V = 5, III = 3.
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> num = 1994
<strong>Output:</strong> "MCMXCIV"
<strong>Explanation:</strong> M = 1000, CM = 900, XC = 90 and IV = 4.
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= num &lt;= 3999</code></li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {number} num
 * @return {string}
 */
const val = [1000,900,500,400,100,90,50,40,10,9,5,4,1]
const rom = ["M","CM","D","CD","C","XC","L","XL","X","IX","V","IV","I"]

var intToRoman = function(N) {
    let result = "";
    for (let i = 0; i < val.length; i++) {
        while (N >= val[i]) {
            result += rom[i];
            N -= val[i];
        }
    }

    return result;
};
```

### **Python3**

```python
val = [1000,900,500,400,100,90,50,40,10,9,5,4,1]
rom = ["M","CM","D","CD","C","XC","L","XL","X","IX","V","IV","I"]
class Solution:
    def intToRoman(self, num: int) -> str:
        res = ''
        for i in range(len(val)):
            while num >= val[i]:
                num -= val[i]
                res += rom[i]
        return res
```

### **C++**

```cpp
class Solution
{
public:
    string intToRoman(int num)
    {
        string res;
        vector<int> nums = {1000, 900, 500, 400, 100,
                            90, 50, 40, 10, 9, 5, 4, 1};
        vector<string> romans = {"M", "CM", "D", "CD", "C",
                                 "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
        for (int i = 0; i < nums.size(); i++)
        {
            while (num >= nums[i])
            {
                num -= nums[i];
                res += romans[i];
            }
        }
        return res;
    }
};
```

### **C#**

```csharp
public class Solution {
    public string IntToRoman(int num) {
        var sb = new StringBuilder();
        var map = new Dictionary<int, string> {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };
        
        foreach (var pair in map) {
            while (num >= pair.Key) {
                sb.Append(pair.Value);
                num -= pair.Key;
            }
        }
        
        return sb.ToString();
    }
}
```