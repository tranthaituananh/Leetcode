/*
 * @lc app=leetcode id=40 lang=csharp
 *
 * [40] Combination Sum II
 */

// @lc code=start
public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        var result = new List<IList<int>>();
        Array.Sort(candidates);
        Backtrack(result, new List<int>(), candidates, target, 0);
        return result;
    }

    private void Backtrack(IList<IList<int>> result, List<int> tempList, int[] candidates, int remain, int start) {
        if (remain < 0) return;
        else if (remain == 0) result.Add(new List<int>(tempList));
        else {
            for (int i = start; i < candidates.Length; i++) {
                if (i > start && candidates[i] == candidates[i - 1]) continue;
                tempList.Add(candidates[i]);
                Backtrack(result, tempList, candidates, remain - candidates[i], i + 1);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
    }
}
// @lc code=end

