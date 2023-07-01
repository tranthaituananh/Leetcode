/*
 * @lc app=leetcode id=37 lang=csharp
 *
 * [37] Sudoku Solver
 */

// @lc code=start
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
// @lc code=end

