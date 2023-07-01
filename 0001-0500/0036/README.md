# [36. Valid Sudoku](https://leetcode.com/problems/valid-sudoku/)

## Description

<p>Determine if a&nbsp;<code>9 x 9</code> Sudoku board&nbsp;is valid.&nbsp;Only the filled cells need to be validated&nbsp;<strong>according to the following rules</strong>:</p>

<ol>
	<li>Each row&nbsp;must contain the&nbsp;digits&nbsp;<code>1-9</code> without repetition.</li>
	<li>Each column must contain the digits&nbsp;<code>1-9</code>&nbsp;without repetition.</li>
	<li>Each of the nine&nbsp;<code>3 x 3</code> sub-boxes of the grid must contain the digits&nbsp;<code>1-9</code>&nbsp;without repetition.</li>
</ol>

<p><strong>Note:</strong></p>

<ul>
	<li>A Sudoku board (partially filled) could be valid but is not necessarily solvable.</li>
	<li>Only the filled cells need to be validated according to the mentioned&nbsp;rules.</li>
</ul>

<p><strong class="example">Example 1:</strong></p>
<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Sudoku-by-L2G-20050714.svg/250px-Sudoku-by-L2G-20050714.svg.png" style="height: 250px; width: 250px;">
<pre><strong>Input:</strong> board = 
[["5","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]
<strong>Output:</strong> true
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> board = 
[["8","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]
<strong>Output:</strong> false
<strong>Explanation:</strong> Same as Example 1, except with the <strong>5</strong> in the top left corner being modified to <strong>8</strong>. Since there are two 8's in the top left 3x3 sub-box, it is invalid.
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>board.length == 9</code></li>
	<li><code>board[i].length == 9</code></li>
	<li><code>board[i][j]</code> is a digit <code>1-9</code> or <code>'.'</code>.</li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {character[][]} board
 * @return {boolean}
 */
 var isValidSudoku = function(board) {
    let row = new Array(9).fill(0);
    let col = new Array(9).fill(0);
    let box = new Array(9).fill(0);
    
    for(let i = 0; i < 9; i++){
        for(let j = 0; j < 9; j++){
            if(board[i][j] !== '.'){
                let num = board[i][j];
                let k = Math.floor(i / 3) * 3 + Math.floor(j / 3);
                
                if(row[i] & (1 << num) || col[j] & (1 << num) || box[k] & (1 << num)){
                    return false;
                }
                
                row[i] |= (1 << num);
                col[j] |= (1 << num);
                box[k] |= (1 << num);
            }
        }
    }
    
    return true;  
};
```

### **Python3**

```python
class Solution:
    def isValidSudoku(self, board: List[List[str]]) -> bool:
        # check row
        for row in board:
            if not self.check(row):
                return False

        # check column
        for i in range(9):
            if not self.check([row[i] for row in board]):
                return False

        # check 3x3
        for i in range(0, 9, 3):
            for j in range(0, 9, 3):
                if not self.check([board[i + x][j + y] for x in range(3) for y in range(3)]):
                    return False

        return True

    def check(self, row):
        row = [x for x in row if x != '.']
        return len(set(row)) == len(row)
```

### **C++**

```cpp
class Solution
{
public:
    bool isValidSudoku(vector<vector<char>> &board)
    {
        int row[9][9] = {0}, col[9][9] = {0}, box[9][9] = {0};
        for (int i = 0; i < 9; ++i)
        {
            for (int j = 0; j < 9; ++j)
            {
                if (board[i][j] == '.')
                    continue;
                int num = board[i][j] - '1', k = i / 3 * 3 + j / 3;
                if (row[i][num] || col[j][num] || box[k][num])
                    return false;
                row[i][num] = col[j][num] = box[k][num] = 1;
            }
        }
        return true;
    }
};
```

### **C#**

```csharp
public class Solution {
    public bool IsValidSudoku(char[][] board) {
        // Check rows
        for (int i = 0; i < 9; i++) {
            if (!IsValid(board[i])) {
                return false;
            }
        }
        // Check columns
        for (int i = 0; i < 9; i++) {
            char[] column = new char[9];
            for (int j = 0; j < 9; j++) {
                column[j] = board[j][i];
            }
            if (!IsValid(column)) {
                return false;
            }
        }
        // Check 3x3 squares
        for (int i = 0; i < 9; i += 3) {
            for (int j = 0; j < 9; j += 3) {
                char[] square = new char[9];
                int k = 0;
                for (int x = i; x < i + 3; x++) {
                    for (int y = j; y < j + 3; y++) {
                        square[k++] = board[x][y];
                    }
                }
                if (!IsValid(square)) {
                    return false;
                }
            }
        }
        return true;
    }

    private bool IsValid(char[] chars) {
        HashSet<char> set = new HashSet<char>();
        foreach (char c in chars) {
            if (c == '.') {
                continue;
            }
            if (set.Contains(c)) {
                return false;
            }
            set.Add(c);
        }
        return true;
    }
}
```