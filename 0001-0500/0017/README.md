# [17. Letter Combinations of a Phone Number](https://leetcode.com/problems/letter-combinations-of-a-phone-number/)

## Description

<p>Given a string containing digits from <code>2-9</code> inclusive, return all possible letter combinations that the number could represent. Return the answer in <strong>any order</strong>.</p>

<p>A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.</p>
<img alt="" src="https://assets.leetcode.com/uploads/2022/03/15/1200px-telephone-keypad2svg.png" style="width: 300px; height: 243px;">
<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> digits = "23"
<strong>Output:</strong> ["ad","ae","af","bd","be","bf","cd","ce","cf"]
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> digits = ""
<strong>Output:</strong> []
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> digits = "2"
<strong>Output:</strong> ["a","b","c"]
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>0 &lt;= digits.length &lt;= 4</code></li>
	<li><code>digits[i]</code> is a digit in the range <code>['2', '9']</code>.</li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {string} digits
 * @return {string[]}
 */
var letterCombinations = function (digits) {
    if (digits.length === 0) {
        return [];
    }
    const map = {
        "2": "abc",
        "3": "def",
        "4": "ghi",
        "5": "jkl",
        "6": "mno",
        "7": "pqrs",
        "8": "tuv",
        "9": "wxyz"
    };
    const result = [];
    const dfs = (index, str) => {
        if (index === digits.length) {
            result.push(str);
            return;
        }
        const letters = map[digits[index]];
        for (let i = 0; i < letters.length; i++) {
            dfs(index + 1, str + letters[i]);
        }
    };
    dfs(0, "");
    return result;
};
```

### **Python3**

```python
class Solution:
    def letterCombinations(self, digits: str) -> List[str]:
        if not digits:
            return []
        d = {
            '2': 'abc',
            '3': 'def',
            '4': 'ghi',
            '5': 'jkl',
            '6': 'mno',
            '7': 'pqrs',
            '8': 'tuv',
            '9': 'wxyz'
        }
        res = ['']
        for c in digits:
            res = [pre + suf for pre in res for suf in d[c]]
        return res       
```

### **C++**

```cpp
class Solution
{
public:
    vector<string> letterCombinations(string digits)
    {
        vector<string> res;
        if (digits.empty())
            return res;

        vector<string> dict = {"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};

        res.push_back("");
        for (int i = 0; i < digits.size(); i++)
        {
            vector<string> tmp;
            string str = dict[digits[i] - '2'];
            for (int j = 0; j < str.size(); j++)
            {
                for (int k = 0; k < res.size(); k++)
                {
                    tmp.push_back(res[k] + str[j]);
                }
            }
            res = tmp;
        }
        return res;
    }
};
```

### **C#**

```csharp
public class Solution {
    Dictionary<char, char[]> keypad = new Dictionary<char, char[]> {{'2', new char[]{'a', 'b', 'c'}}, 
    {'3', new char[]{'d', 'e', 'f'}}, {'4', new char[] {'g', 'h', 'i'}}, 
    {'5', new char[] {'j', 'k', 'l'}}, {'6', new char[] {'m', 'n', 'o'}}, 
    {'7', new char[] {'p', 'q', 'r', 's'}}, {'8', new char[] {'t', 'u', 'v'}}, 
    {'9', new char[] {'w', 'x', 'y', 'z'}}};

    public void AddCombination(string curr, string digits, int index, IList<string> list)
    {
        if(index >= digits.Length) list.Add(curr);
        else
        {
            char[] map = keypad[digits[index]];

            for(int i = 0; i < map.Length; i++)
            {
                string newCurr = curr + map[i];

                AddCombination(newCurr, digits, index + 1, list);
            }
        }
    }

    public IList<string> LetterCombinations(string digits) 
    {
        IList<string> combinations = new List<string>();

        if(digits.Length > 0) AddCombination("", digits, 0, combinations);

        return combinations;
    }
}
```