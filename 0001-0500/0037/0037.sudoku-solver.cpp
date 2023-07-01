/*
 * @lc app=leetcode id=37 lang=cpp
 *
 * [37] Sudoku Solver
 */

// @lc code=start
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
// @lc code=end
