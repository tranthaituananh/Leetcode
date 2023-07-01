#
# @lc app=leetcode id=36 lang=python3
#
# [36] Valid Sudoku
#

# @lc code=start
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
# @lc code=end

