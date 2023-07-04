# [40. Combination Sum II](https://leetcode.com/problems/combination-sum-ii/)

## Description

<p>Given a collection of candidate numbers (<code>candidates</code>) and a target number (<code>target</code>), find all unique combinations in <code>candidates</code>&nbsp;where the candidate numbers sum to <code>target</code>.</p>

<p>Each number in <code>candidates</code>&nbsp;may only be used <strong>once</strong> in the combination.</p>

<p><strong>Note:</strong>&nbsp;The solution set must not contain duplicate combinations.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> candidates = [10,1,2,7,6,1,5], target = 8
<strong>Output:</strong> 
[
[1,1,6],
[1,2,5],
[1,7],
[2,6]
]
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> candidates = [2,5,2,1,2], target = 5
<strong>Output:</strong> 
[
[1,2,2],
[5]
]
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;=&nbsp;candidates.length &lt;= 100</code></li>
	<li><code>1 &lt;=&nbsp;candidates[i] &lt;= 50</code></li>
	<li><code>1 &lt;= target &lt;= 30</code></li>
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
var combinationSum2 = function(candidates, target) {
    let result = [];
    let current = [];
    candidates.sort((a, b) => a - b);
    helper(candidates, target, 0, current, result);
    return result;  
}

var helper = function(candidates, target, start, current, result) {
    if (target === 0) {
        result.push(current.slice());
        return;
    }
    for (let i = start; i < candidates.length; i++) {
        if (candidates[i] > target) {
            break;
        }
        if (i > start && candidates[i] === candidates[i - 1]) {
            continue;
        }
        current.push(candidates[i]);
        helper(candidates, target - candidates[i], i + 1, current, result);
        current.pop();
    }
};
```

### **Python3**

```python
class Solution:
    def combinationSum2(self, candidates: List[int], target: int) -> List[List[int]]:
        res = []
        candidates.sort()
        def dfs(i, target, path):
            if target == 0:
                res.append(path)
                return
            for j in range(i, len(candidates)):
                if j > i and candidates[j] == candidates[j - 1]:
                    continue
                if candidates[j] > target:
                    break
                dfs(j + 1, target - candidates[j], path + [candidates[j]])
        dfs(0, target, [])
        return res  
```

### **C++**

```cpp
class Solution
{
public:
    vector<vector<int>> combinationSum2(vector<int> &candidates, int target)
    {
        vector<vector<int>> res;

        sort(candidates.begin(), candidates.end());
        vector<int> path;
        dfs(candidates, target, 0, path, res);
        return res;
    }

    void dfs(vector<int> &candidates, int target, int start, vector<int> &path, vector<vector<int>> &res)
    {
        if (target == 0)
        {
            res.push_back(path);
            return;
        }

        for (int i = start; i < candidates.size() && target >= candidates[i]; i++)
        {
            if (i > start && candidates[i] == candidates[i - 1])
                continue;
            path.push_back(candidates[i]);
            dfs(candidates, target - candidates[i], i + 1, path, res);
            path.pop_back();
        }
    }
};
```

### **C#**

```csharp
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
```