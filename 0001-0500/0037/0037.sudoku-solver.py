#
# @lc app=leetcode id=37 lang=python3
#
# [37] Sudoku Solver
#

# @lc code=start
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
# @lc code=end

