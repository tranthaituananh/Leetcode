# [35. Search Insert Position](https://leetcode.com/problems/search-insert-position/)

## Description

<p>Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.</p>

<p>You must&nbsp;write an algorithm with&nbsp;<code>O(log n)</code> runtime complexity.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> nums = [1,3,5,6], target = 5
<strong>Output:</strong> 2
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> nums = [1,3,5,6], target = 2
<strong>Output:</strong> 1
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> nums = [1,3,5,6], target = 7
<strong>Output:</strong> 4
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= nums.length &lt;= 10<sup>4</sup></code></li>
	<li><code>-10<sup>4</sup> &lt;= nums[i] &lt;= 10<sup>4</sup></code></li>
	<li><code>nums</code> contains <strong>distinct</strong> values sorted in <strong>ascending</strong> order.</li>
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
var searchInsert = function(nums, target) {
    let len = nums.length
    if (target > nums[len-1]) {
        return len
    } if (target < nums[0]) {
        return 0
    }
    for (let i = 0; i < len; i++) {
        if (nums[i] == target) {
            return i
        } if (target > nums[i] && target < nums[i+1]){
            return i + 1
        }
    }
};
```

### **Python3**

```python
class Solution:
    def searchInsert(self, nums: List[int], target: int) -> int:
        start = 0
        end = len(nums)-1
        while start <= end:
            mid = (start + end)//2
            if nums[mid] == target:
                return mid
            elif nums[mid] > target:
                end = mid - 1
            else:
                start = mid + 1
        return end+1
```

### **C++**

```cpp
class Solution
{
public:
    int searchInsert(vector<int> &nums, int target)
    {
        int l = nums.size() - 1;
        int pos = 0;
        while (l >= pos)
        {
            int mid = (l + pos) / 2;
            if (nums[mid] < target)
            {
                pos = mid + 1;
            }
            if (nums[mid] == target)
            {
                return mid;
            }
            if (nums[mid] > target)
            {
                l = mid - 1;
            }
        }
        return pos;
    }
};
```

### **C#**

```csharp
public class Solution {
    public int SearchInsert(int[] nums, int target) {
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] >= target) {
                return i;
            }
        }
        return nums.Length;
    }
}
```