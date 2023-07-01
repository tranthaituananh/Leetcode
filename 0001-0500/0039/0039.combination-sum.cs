/*
 * @lc app=leetcode id=39 lang=csharp
 *
 * [39] Combination Sum
 */

// @lc code=start
public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        IList<IList<int>> result = new List<IList<int>>();
        List<int> combination = new List<int>();
        Array.Sort(candidates);
        Backtrack(candidates, target, result, combination, 0);
        return result;
    }
    
    private void Backtrack(int[] candidates, int target, IList<IList<int>> result, List<int> combination, int start) {
        if (target == 0) {
            result.Add(new List<int>(combination));
            return;
        }
        
        for (int i = start; i < candidates.Length; i++) {
            if (candidates[i] > target) break;
            combination.Add(candidates[i]);
            Backtrack(candidates, target - candidates[i], result, combination, i);
            combination.RemoveAt(combination.Count - 1);
        }
    }
}
// @lc code=end

