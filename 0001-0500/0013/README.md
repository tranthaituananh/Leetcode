# [13. Roman to Integer](https://leetcode.com/problems/roman-to-integer/)

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

<p>For example,&nbsp;<code>2</code> is written as <code>II</code>&nbsp;in Roman numeral, just two ones added together. <code>12</code> is written as&nbsp;<code>XII</code>, which is simply <code>X + II</code>. The number <code>27</code> is written as <code>XXVII</code>, which is <code>XX + V + II</code>.</p>

<p>Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not <code>IIII</code>. Instead, the number four is written as <code>IV</code>. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as <code>IX</code>. There are six instances where subtraction is used:</p>

<ul>
	<li><code>I</code> can be placed before <code>V</code> (5) and <code>X</code> (10) to make 4 and 9.&nbsp;</li>
	<li><code>X</code> can be placed before <code>L</code> (50) and <code>C</code> (100) to make 40 and 90.&nbsp;</li>
	<li><code>C</code> can be placed before <code>D</code> (500) and <code>M</code> (1000) to make 400 and 900.</li>
</ul>

<p>Given a roman numeral, convert it to an integer.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> s = "III"
<strong>Output:</strong> 3
<strong>Explanation:</strong> III = 3.
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> s = "LVIII"
<strong>Output:</strong> 58
<strong>Explanation:</strong> L = 50, V= 5, III = 3.
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> s = "MCMXCIV"
<strong>Output:</strong> 1994
<strong>Explanation:</strong> M = 1000, CM = 900, XC = 90 and IV = 4.
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= s.length &lt;= 15</code></li>
	<li><code>s</code> contains only&nbsp;the characters <code>('I', 'V', 'X', 'L', 'C', 'D', 'M')</code>.</li>
	<li>It is <strong>guaranteed</strong>&nbsp;that <code>s</code> is a valid roman numeral in the range <code>[1, 3999]</code>.</li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {string} s
 * @return {number}
 */
var romanToInt = function(s) {
    let romanTable = {
        "I" : 1,
        "V" : 5,
        "X" : 10,
        "L" : 50,
        "C" : 100,
        "D" : 500,
        "M" : 1000
    }
    let start = s.length;
    let romanVal = romanTable[s[start - 1]];
    start--;
    while (start > 0) {
        romanVal += romanTable[s[start - 1]] < romanTable[s[start]] ? -romanTable[s[start - 1]] : romanTable[s[start - 1]];
        start--;
    }
    return romanVal;
};
```

### **Python3**

```python
class Solution:
    def romanToInt(self, s: str) -> int:
        Num = 0
        Roman = {
            'I': 1,
            'V': 5,
            'X': 10,
            'L': 50,
            'C': 100,
            'D': 500,
            'M': 1000,
        }
        Prev = 0
        for letter in s:
            Next = Roman[letter]
            if Prev >= Next:
                Num += Prev
            else:
                Num -= Prev
            Prev = Next
        Num += Next

        return Num
```

### **C++**

```cpp
class Solution
{
public:
    int romanToInt(string s)
    {
        int res = 0;
        int len = s.length();
        for (int i = 0; i < len; i++)
        {
            if (i < len - 1 && valueInt(s[i]) < valueInt(s[i + 1]))
            {
                res -= valueInt(s[i]);
            }
            else
            {
                res += valueInt(s[i]);
            }
        }
        return res;
    }
    int valueInt(char c)
    {
        switch (c)
        {
        case 'I':
            return 1;
        case 'V':
            return 5;
        case 'X':
            return 10;
        case 'L':
            return 50;
        case 'C':
            return 100;
        case 'D':
            return 500;
        case 'M':
            return 1000;
        default:
            return 0;
        }
    }
};
```

### **C#**

```csharp
public class Solution {
    public int RomanToInt(string s)
    {
        int total=0;
        for(int i=0; i<s.Length; i++){
            if(i+1>=s.Length || ToInt(s[i])>=ToInt(s[i+1]))
                total+=ToInt(s[i]);
            else
                total-=ToInt(s[i]);
        }
        return total;
    }
    
    public int ToInt(char c)
    {
        return c switch
        {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => 0,
        };
    }
}
```