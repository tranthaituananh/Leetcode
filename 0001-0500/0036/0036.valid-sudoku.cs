/*
 * @lc app=leetcode id=36 lang=csharp
 *
 * [36] Valid Sudoku
 */

// @lc code=start
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
// @lc code=end

