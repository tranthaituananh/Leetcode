# [39. Combination Sum](https://leetcode.com/problems/combination-sum/)

## Description

<p>Given an array of <strong>distinct</strong> integers <code>candidates</code> and a target integer <code>target</code>, return <em>a list of all <strong>unique combinations</strong> of </em><code>candidates</code><em> where the chosen numbers sum to </em><code>target</code><em>.</em> You may return the combinations in <strong>any order</strong>.</p>

<p>The <strong>same</strong> number may be chosen from <code>candidates</code> an <strong>unlimited number of times</strong>. Two combinations are unique if the frequency of at least one of the chosen numbers is different.</p>

<p>The test cases are generated such that the number of unique combinations that sum up to <code>target</code> is less than <code>150</code> combinations for the given input.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> candidates = [2,3,6,7], target = 7
<strong>Output:</strong> [[2,2,3],[7]]
<strong>Explanation:</strong>
2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
7 is a candidate, and 7 = 7.
These are the only two combinations.
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> candidates = [2,3,5], target = 8
<strong>Output:</strong> [[2,2,2,2],[2,3,3],[3,5]]
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> candidates = [2], target = 1
<strong>Output:</strong> []
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= candidates.length &lt;= 30</code></li>
	<li><code>2 &lt;= candidates[i] &lt;= 40</code></li>
	<li>All elements of <code>candidates</code> are <strong>distinct</strong>.</li>
	<li><code>1 &lt;= target &lt;= 40</code></li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {number[]} candidates
 * @param {number} target
 * @return {number[][]}
 */
 var combinationSum = function(candidates, target) {
    let result = [];
    let current = [];
    candidates.sort((a, b) => a - b);
    helper(candidates, target, 0, current, result);
    return result;  
};

var helper = function(candidates, target, start, current, result) {
    if (target === 0) {
        result.push(current.slice());
        return;
    }
    for (let i = start; i < candidates.length; i++) {
        if (candidates[i] > target) {
            break;
        }
        current.push(candidates[i]);
        helper(candidates, target - candidates[i], i, current, result);
        current.pop();
    }
};
```

### **Python3**

```python
class Solution:
    def combinationSum(self, candidates: List[int], target: int) -> List[List[int]]:
        res = []
        candidates.sort()
        def dfs(i, target, path):
            if target == 0:
                res.append(path)
                return
            for j in range(i, len(candidates)):
                if candidates[j] > target:
                    break
                dfs(j, target - candidates[j], path + [candidates[j]])
        dfs(0, target, [])
        return res
```

### **C++**

```cpp
class Solution
{
public:
    vector<vector<int>> combinationSum(vector<int> &candidates, int target)
    {
        vector<vector<int>> res;
        vector<int> temp;
        sort(candidates.begin(), candidates.end());
        dfs(candidates, target, 0, temp, res);
        return res;
    }

    void dfs(vector<int> &candidates, int target, int index, vector<int> &temp, vector<vector<int>> &res)
    {
        if (target == 0)
        {
            res.push_back(temp);
            return;
        }
        for (int i = index; i < candidates.size(); i++)
        {
            if (candidates[i] > target)
                break;
            temp.push_back(candidates[i]);
            dfs(candidates, target - candidates[i], i, temp, res);
            temp.pop_back();
        }
    }
};
```

### **C#**

```csharp
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
```