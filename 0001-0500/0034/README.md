# [34. Find First and Last Position of Element in Sorted Array](https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/)

## Description

<p>Given an array of integers <code>nums</code> sorted in non-decreasing order, find the starting and ending position of a given <code>target</code> value.</p>

<p>If <code>target</code> is not found in the array, return <code>[-1, -1]</code>.</p>

<p>You must&nbsp;write an algorithm with&nbsp;<code>O(log n)</code> runtime complexity.</p>

<p><strong class="example">Example 1:</strong></p>
<pre><strong>Input:</strong> nums = [5,7,7,8,8,10], target = 8
<strong>Output:</strong> [3,4]
</pre><p><strong class="example">Example 2:</strong></p>
<pre><strong>Input:</strong> nums = [5,7,7,8,8,10], target = 6
<strong>Output:</strong> [-1,-1]
</pre><p><strong class="example">Example 3:</strong></p>
<pre><strong>Input:</strong> nums = [], target = 0
<strong>Output:</strong> [-1,-1]
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>0 &lt;= nums.length &lt;= 10<sup>5</sup></code></li>
	<li><code>-10<sup>9</sup>&nbsp;&lt;= nums[i]&nbsp;&lt;= 10<sup>9</sup></code></li>
	<li><code>nums</code> is a non-decreasing array.</li>
	<li><code>-10<sup>9</sup>&nbsp;&lt;= target&nbsp;&lt;= 10<sup>9</sup></code></li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var searchRange = function (nums, target) {
    let left = 0;
    let right = nums.length - 1;
    let result = [-1, -1];

    while (left <= right) {
        let mid = Math.floor((left + right) / 2);

        if (nums[mid] === target) {
            let i = mid;
            let j = mid;

            while (nums[i] === target && i >= 0) {
                i--;
            }
            while (nums[j] === target && j < nums.length) {
                j++;
            }

            result[0] = i + 1;
            result[1] = j - 1;
            break;
        }
        else if (nums[mid] < target) {
            left = mid + 1;
        }
        else {
            right = mid - 1;
        }
    }

    return result;
};
```

### **Python3**

```python
class Solution:
    def searchRange(self, nums: List[int], target: int) -> List[int]:
        left = self.searchLeft(nums, target)
        right = self.searchRight(nums, target)
        return [left, right]
    
    def searchLeft(self, nums, target):
        i, j = 0, len(nums) - 1
        while i <= j:
            mid = (i + j) // 2
            if nums[mid] < target:
                i = mid + 1
            else:
                j = mid - 1
        if i < len(nums) and nums[i] == target:
            return i
        return -1
    
    def searchRight(self, nums, target):
        i, j = 0, len(nums) - 1
        while i <= j:
            mid = (i + j) // 2
            if nums[mid] <= target:
                i = mid + 1
            else:
                j = mid - 1
        if j >= 0 and nums[j] == target:
            return j
        return -1
```

### **C++**

```cpp
class Solution
{
public:
    vector<int> searchRange(vector<int> &nums, int target)
    {
        int left = 0, right = nums.size();
        int mid = 0;
        vector<int> res(2, -1);
        while (left < right)
        {
            mid = (left + right) / 2;
            if (nums[mid] >= target)
                right = mid;
            else
                left = mid + 1;
        }
        if (left == nums.size() || nums[left] != target)
            return res;
        res[0] = left;
        right = nums.size();
        while (left < right)
        {
            mid = (left + right) / 2;
            if (nums[mid] > target)
                right = mid;
            else
                left = mid + 1;
        }
        res[1] = left - 1;
        return res;
    }
};
```

### **C#**

```csharp
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int[] result = new int[2];
        result[0] = -1;
        result[1] = -1;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == target) {
                if (result[0] == -1) {
                    result[0] = i;
                }
                result[1] = i;
            }
        }        
        return result;
    }
}
```