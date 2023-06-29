# [18. 4Sum](https://leetcode.com/problems/4sum/)

## Description

<p>Given an array <code>nums</code> of <code>n</code> integers, return <em>an array of all the <strong>unique</strong> quadruplets</em> <code>[nums[a], nums[b], nums[c], nums[d]]</code> such that:</p>

<ul>
	<li><code>0 &lt;= a, b, c, d&nbsp;&lt; n</code></li>
	<li><code>a</code>, <code>b</code>, <code>c</code>, and <code>d</code> are <strong>distinct</strong>.</li>
	<li><code>nums[a] + nums[b] + nums[c] + nums[d] == target</code></li>
</ul>

<p>You may return the answer in <strong>any order</strong>.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> nums = [1,0,-1,0,-2,2], target = 0
<strong>Output:</strong> [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> nums = [2,2,2,2,2], target = 8
<strong>Output:</strong> [[2,2,2,2]]
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= nums.length &lt;= 200</code></li>
	<li><code>-10<sup>9</sup> &lt;= nums[i] &lt;= 10<sup>9</sup></code></li>
	<li><code>-10<sup>9</sup> &lt;= target &lt;= 10<sup>9</sup></code></li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[][]}
 */
var fourSum = function(nums, target) {
    nums.sort((a, b) => a - b);
    const result = [];
    for (let i = 0; i < nums.length; i++) {
        if (i > 0 && nums[i] === nums[i - 1]) {
            continue;
        }
        for (let j = i + 1; j < nums.length; j++) {
            if (j > i + 1 && nums[j] === nums[j - 1]) {
                continue;
            }
            let left = j + 1;
            let right = nums.length - 1;
            while (left < right) {
                const sum = nums[i] + nums[j] + nums[left] + nums[right];
                if (sum === target) {
                    result.push([nums[i], nums[j], nums[left], nums[right]]);
                    while (left < right && nums[left] === nums[left + 1]) {
                        left++;
                    }
                    while (left < right && nums[right] === nums[right - 1]) {
                        right--;
                    }
                    left++;
                    right--;
                } else if (sum < target) {
                    left++;
                } else {
                    right--;
                }
            }
        }
    }
    return result;    
};
```

### **Python3**

```python
class Solution:
    def fourSum(self, nums: List[int], target: int) -> List[List[int]]:
        nums.sort()
        i = 0
        L = len(nums)
        res = []
        while i < L-3:
            if target-nums[i] < 3*nums[i+1] or target-nums[i] > 3*nums[-1]:
                    while i < L-4 and nums[i] == nums[i+1]:
                        i+=1
                    i+=1
                    continue
            j = i+1
            while j < L-2:
                if target-nums[i]-nums[j] < 2*nums[j+1] or target-nums[i]-nums[j] > 2*nums[-1]:
                    while j < L-3 and nums[j] == nums[j+1]:
                        j+=1
                    j+=1
                    continue
                left = j+1
                right = L-1
                new_target = target-nums[i]-nums[j]
                while left<right:
                    if nums[left]+nums[right] > new_target:
                        right-=1
                    elif nums[left]+nums[right] < new_target:
                        left+=1
                    else:
                        res.append([nums[i],nums[j],nums[left],nums[right]])
                        temp_left = nums[left]
                        temp_right = nums[right]
                        while(left<right and nums[left]==temp_left):
                            left+=1
                        while(left<right and nums[right]==temp_right):
                            right-=1
                while j < L-3 and nums[j] == nums[j+1]:
                    j+=1
                j+=1
            while i < L-4 and nums[i] == nums[i+1]:
                i+=1
            i+=1
        return res
```

### **C++**

```cpp
class Solution
{
public:
    vector<vector<int>> fourSum(vector<int> &nums, long long target)
    {
        int n = nums.size();
        sort(nums.begin(), nums.end());
        vector<vector<int>> ans;
        for (int i = 0; i < n; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            for (int j = i + 1; j < n; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1])
                    continue;
                int k = j + 1, l = n - 1;
                while (k < l)
                {
                    long long int sum = nums[i] + nums[j];
                    sum += nums[k];
                    sum += nums[l];
                    if (sum < target)
                    {
                        k++;
                    }
                    else if (sum > target)
                    {
                        l--;
                    }
                    else
                    {
                        vector<int> temp = {nums[i], nums[j], nums[k], nums[l]};
                        ans.push_back(temp);
                        k++, l--;
                        while (k < l && nums[k] == nums[k - 1])
                            k++;
                        while (k < l && nums[l] == nums[l + 1])
                            l--;
                    }
                }
            }
        }
        return ans;
    }
};
```

### **C#**

```csharp
public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        Array.Sort(nums);

        var originalK = 4;
        var matches = new List<IList<int>>();
        var backtrack = new int[originalK - 2];

        KSum(target, 0, originalK);

        return matches;

        void KSum(long target, int start, int k)
        {
            if (start > nums.Length - k)
            {
                return;
            }

            var avg = target / k;
            if (nums[start] > avg || avg > nums.Last())
            {
                return;
            }

            if (k == 2)
            {
                TwoSum(target, start);
                return;
            }

            for (var i = start; i < nums.Length; i++)
            {
                if (i == start || nums[i - 1] != nums[i])
                {
                    var depth = originalK - k;
                    backtrack[depth] = nums[i];

                    KSum(target - nums[i], i + 1, k - 1);
                }
            }
        }

        void TwoSum(long target, int start)
        {
            var (left, right) = (start, nums.Length - 1);

            while (left < right)
            {
                var sum = nums[left] + nums[right];

                if (sum < target)
                {
                    left++;
                    continue;
                }
                
                if (sum > target)
                {
                    --right;
                    continue;
                }

                matches.Add(new List<int>(backtrack) { nums[left], nums[right] });

                left++;
                right--;

                while (left < right && nums[left] == nums[left - 1])
                {
                    left++;
                }
            }
        }
    }
}
```