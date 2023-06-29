# [16. 3Sum Closest](https://leetcode.com/problems/3sum-closest/)

## Description

<p>Given an integer array <code>nums</code> of length <code>n</code> and an integer <code>target</code>, find three integers in <code>nums</code> such that the sum is closest to <code>target</code>.</p>

<p>Return <em>the sum of the three integers</em>.</p>

<p>You may assume that each input would have exactly one solution.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> nums = [-1,2,1,-4], target = 1
<strong>Output:</strong> 2
<strong>Explanation:</strong> The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> nums = [0,0,0], target = 1
<strong>Output:</strong> 0
<strong>Explanation:</strong> The sum that is closest to the target is 0. (0 + 0 + 0 = 0).
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>3 &lt;= nums.length &lt;= 500</code></li>
	<li><code>-1000 &lt;= nums[i] &lt;= 1000</code></li>
	<li><code>-10<sup>4</sup> &lt;= target &lt;= 10<sup>4</sup></code></li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number}
 */
var threeSumClosest = function (nums, target) {
    nums.sort((a, b) => a - b);
    let result = nums[0] + nums[1] + nums[2];
    for (let i = 0; i < nums.length; i++) {
        let left = i + 1;
        let right = nums.length - 1;
        while (left < right) {
            const sum = nums[i] + nums[left] + nums[right];
            if (Math.abs(sum - target) < Math.abs(result - target)) {
                result = sum;
            }
            if (sum < target) {
                left++;
            } else {
                right--;
            }
        }
    }
    return result;
};
```

### **Python3**

```python
class Solution:
    def threeSumClosest(self, nums: List[int], target: int) -> int:
        nums.sort()
        closestSum,closestDiff = 0, float("inf")
        length = len(nums)
        endIdx = length-1
        for i in range(length-2):
            currentNum = nums[i]
            left, right = i + 1, endIdx
            while left < right:
                currentSum = currentNum + nums[left] + nums[right]
                currentDiff = abs(currentSum-target)
                if currentDiff == 0:
                    return currentSum
                elif currentDiff < closestDiff:
                    closestDiff = currentDiff
                    closestSum = currentSum
                if currentSum > target:
                    right -= 1
                else:
                    left += 1
                    
        return closestSum
```

### **C++**

```cpp
class Solution
{
public:
    int twoSumCloset(vector<int> &nums, int target, int start)
    {
        int left = start, right = nums.size() - 1;
        int curMin = INT_MAX;
        int curVal = 0;
        while (left < right)
        {
            if (nums[left] >= target / 2)
            {
                int tmp = nums[left] + nums[left + 1] - target;
                return tmp < curMin ? tmp + target : curVal;
            }
            if (nums[right] <= target / 2)
            {
                int tmp = target - nums[right] - nums[right - 1];
                return tmp < curMin ? target - tmp : curVal;
            }
            int tmp = nums[left] + nums[right];
            if (tmp == target)
                return target;
            if (tmp < target)
            {
                left++;
                if (target - tmp < curMin)
                {
                    curMin = target - tmp;
                    curVal = tmp;
                }
            }
            else
            {
                right--;
                if (tmp - target < curMin)
                {
                    curMin = tmp - target;
                    curVal = tmp;
                }
            }
        }
        return curVal;
    }

    int threeSumClosest(vector<int> &nums, int target)
    {
        sort(nums.begin(), nums.end());
        int curMin = INT_MAX;
        int curVal = 0;
        for (int i = 0; i < nums.size() - 2; i++)
        {
            int tmp = twoSumCloset(nums, target - nums[i], i + 1) + nums[i];

            if (tmp == target)
                return target;
            if (abs(tmp - target) < curMin)
            {
                curVal = tmp;
                curMin = abs(tmp - target);
            }
        }
        return curVal;
    }
};
```

### **C#**

```csharp
public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);
        int result = nums[0] + nums[1] + nums[2];
        for (int i = 0; i < nums.Length; i++) {
            int left = i + 1;
            int right = nums.Length - 1;
            while (left < right) {
                int sum = nums[i] + nums[left] + nums[right];
                if (Math.Abs(sum - target) < Math.Abs(result - target)) {
                    result = sum;
                }
                if (sum < target) {
                    left++;
                } else {
                    right--;
                }
            }
        }
        return result;  
    }
}
```