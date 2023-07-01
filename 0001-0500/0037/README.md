# [37. Sudoku Solver](https://leetcode.com/problems/sudoku-solver/)

## Description

<p>Write a program to solve a Sudoku puzzle by filling the empty cells.</p>

<p>A sudoku solution must satisfy <strong>all of the following rules</strong>:</p>

<ol>
	<li>Each of the digits <code>1-9</code> must occur exactly once in each row.</li>
	<li>Each of the digits <code>1-9</code> must occur exactly once in each column.</li>
	<li>Each of the digits <code>1-9</code> must occur exactly once in each of the 9 <code>3x3</code> sub-boxes of the grid.</li>
</ol>

<p>The <code>'.'</code> character indicates empty cells.</p>

<p><strong class="example">Example 1:</strong></p>
<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Sudoku-by-L2G-20050714.svg/250px-Sudoku-by-L2G-20050714.svg.png" style="height: 250px; width: 250px;">
<pre><strong>Input:</strong> board = [["5","3",".",".","7",".",".",".","."],["6",".",".","1","9","5",".",".","."],[".","9","8",".",".",".",".","6","."],["8",".",".",".","6",".",".",".","3"],["4",".",".","8",".","3",".",".","1"],["7",".",".",".","2",".",".",".","6"],[".","6",".",".",".",".","2","8","."],[".",".",".","4","1","9",".",".","5"],[".",".",".",".","8",".",".","7","9"]]
<strong>Output:</strong> [["5","3","4","6","7","8","9","1","2"],["6","7","2","1","9","5","3","4","8"],["1","9","8","3","4","2","5","6","7"],["8","5","9","7","6","1","4","2","3"],["4","2","6","8","5","3","7","9","1"],["7","1","3","9","2","4","8","5","6"],["9","6","1","5","3","7","2","8","4"],["2","8","7","4","1","9","6","3","5"],["3","4","5","2","8","6","1","7","9"]]
<strong>Explanation:</strong>&nbsp;The input board is shown above and the only valid solution is shown below:

<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/3/31/Sudoku-by-L2G-20050714_solution.svg/250px-Sudoku-by-L2G-20050714_solution.svg.png" style="height: 250px; width: 250px;">
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>board.length == 9</code></li>
	<li><code>board[i].length == 9</code></li>
	<li><code>board[i][j]</code> is a digit or <code>'.'</code>.</li>
	<li>It is <strong>guaranteed</strong> that the input board has only one solution.</li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {character[][]} board
 * @return {void} Do not return anything, modify board in-place instead.
 */
var dfs = function (board, row, col, box, i, j) {
    if (i === 9) {
        return true;
    }
    if (j === 9) {
        return dfs(board, row, col, box, i + 1, 0);
    }
    if (board[i][j] !== '.') {
        return dfs(board, row, col, box, i, j + 1);
    }
    for (let k = 1; k <= 9; k++) {
        let num = 1 << k;
        let b = Math.floor(i / 3) * 3 + Math.floor(j / 3);
        if (row[i] & num || col[j] & num || box[b] & num) {
            continue;
        }
        row[i] |= num;
        col[j] |= num;
        box[b] |= num;
        board[i][j] = k.toString();
        if (dfs(board, row, col, box, i, j + 1)) {
            return true;
        }
        row[i] ^= num;
        col[j] ^= num;
        box[b] ^= num;
        board[i][j] = '.';
    }
    return false;
};

var solveSudoku = function (board) {
    let row = new Array(9).fill(0);
    let col = new Array(9).fill(0);
    let box = new Array(9).fill(0);

    for (let i = 0; i < 9; i++) {
        for (let j = 0; j < 9; j++) {
            if (board[i][j] !== '.') {
                let num = board[i][j];
                let k = Math.floor(i / 3) * 3 + Math.floor(j / 3);

                row[i] |= (1 << num);
                col[j] |= (1 << num);
                box[k] |= (1 << num);
            }
        }
    }

    dfs(board, row, col, box, 0, 0);
};
```

### **Python3**

```python
class Solution:
    def solveSudoku(self, board: List[List[str]]) -> None:
        """
        Do not return anything, modify board in-place instead.
        """
        row_constrain, col_constrain, box_constrain = [[0] * 9 for i in range(9)], [[0] * 9 for i in range(9)], [[0] * 9 for i in range(9)]
        for i in range(9):
            for j in range(9):
                if board[i][j] != '.':
                    num = int(board[i][j]) - 1
                    row_constrain[i][num] = 1
                    col_constrain[j][num] = 1
                    box_constrain[(i // 3) * 3 + j // 3][num] = 1
                
        def dfs(i, j):
            if i == 9:
                return True
            if j == 9:
                return dfs(i + 1, 0)
            if board[i][j] != '.':
                return dfs(i, j + 1)
            for num in range(9):
                if row_constrain[i][num] == 0 and col_constrain[j][num] == 0 and box_constrain[(i // 3) * 3 + j // 3][num] == 0:
                    board[i][j] = str(num + 1)
                    row_constrain[i][num] = 1
                    col_constrain[j][num] = 1
                    box_constrain[(i // 3) * 3 + j // 3][num] = 1
                    if dfs(i, j + 1):
                        return True
                    board[i][j] = '.'
                    row_constrain[i][num] = 0
                    col_constrain[j][num] = 0
                    box_constrain[(i // 3) * 3 + j // 3][num] = 0
            return False

        dfs(0, 0)
```

### **C++**

```cpp
class Solution
{
public:
    void solveSudoku(vector<vector<char>> &board)
    {
        vector<vector<bool>> row(9, vector<bool>(9, false));
        vector<vector<bool>> col(9, vector<bool>(9, false));
        vector<vector<bool>> box(9, vector<bool>(9, false));
        vector<pair<int, int>> empty;
        for (int i = 0; i < 9; ++i)
        {
            for (int j = 0; j < 9; ++j)
            {
                if (board[i][j] == '.')
                {
                    empty.push_back({i, j});
                }
                else
                {
                    int num = board[i][j] - '1';
                    row[i][num] = true;
                    col[j][num] = true;
                    box[i / 3 * 3 + j / 3][num] = true;
                }
            }
        }
        dfs(board, empty, row, col, box, 0);
    }

    bool dfs(vector<vector<char>> &board, vector<pair<int, int>> &empty, vector<vector<bool>> &row, vector<vector<bool>> &col, vector<vector<bool>> &box, int index)
    {
        if (index == empty.size())
        {
            return true;
        }
        int i = empty[index].first;
        int j = empty[index].second;
        for (int num = 0; num < 9; ++num)
        {
            if (!row[i][num] && !col[j][num] && !box[i / 3 * 3 + j / 3][num])
            {
                board[i][j] = num + '1';
                row[i][num] = true;
                col[j][num] = true;
                box[i / 3 * 3 + j / 3][num] = true;
                if (dfs(board, empty, row, col, box, index + 1))
                {
                    return true;
                }
                board[i][j] = '.';
                row[i][num] = false;
                col[j][num] = false;
                box[i / 3 * 3 + j / 3][num] = false;
            }
        }
        return false;
    }
};
```

### **C#**

```csharp
public class Solution {
    public void SolveSudoku(char[][] board) {
        int[][] rows = new int[9][];
        int[][] cols = new int[9][];
        int[][] boxes = new int[9][];
        for (int i = 0; i < 9; i++) {
            rows[i] = new int[9];
            cols[i] = new int[9];
            boxes[i] = new int[9];
        }
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j ++) {
                if (board[i][j] != '.') {
                    int num = board[i][j] - '1';
                    rows[i][num] = 1;
                    cols[j][num] = 1;
                    boxes[i / 3 * 3 + j / 3][num] = 1;
                }
            }
        }
        Solve(board, rows, cols, boxes, 0, 0);
    }

    private bool Solve(char[][] board, int[][] rows, int[][] cols, int[][] boxes, int i, int j) {
        if (i == 9) {
            return true;
        }
        if (j == 9) {
            return Solve(board, rows, cols, boxes, i + 1, 0);
        }
        if (board[i][j] != '.') {
            return Solve(board, rows, cols, boxes, i, j + 1);
        }
        for (int num = 0; num < 9; num++) {
            if (rows[i][num] == 1 || cols[j][num] == 1 || boxes[i / 3 * 3 + j / 3][num] == 1) {
                continue;
            }
            board[i][j] = (char)(num + '1');
            rows[i][num] = 1;
            cols[j][num] = 1;
            boxes[i / 3 * 3 + j / 3][num] = 1;
            if (Solve(board, rows, cols, boxes, i, j + 1)) {
                return true;
            }
            board[i][j] = '.';
            rows[i][num] = 0;
            cols[j][num] = 0;
            boxes[i / 3 * 3 + j / 3][num] = 0;
        }
        return false;
    }
}
```