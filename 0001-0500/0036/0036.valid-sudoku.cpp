/*
 * @lc app=leetcode id=36 lang=cpp
 *
 * [36] Valid Sudoku
 */

// @lc code=start
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
// @lc code=end
