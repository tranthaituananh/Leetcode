# [4. Median of Two Sorted Arrays](https://leetcode.com/problems/median-of-two-sorted-arrays/)

## Description

<p>Given two sorted arrays <code>nums1</code> and <code>nums2</code> of size <code>m</code> and <code>n</code> respectively, return <strong>the median</strong> of the two sorted arrays.</p>

<p>The overall run time complexity should be <code>O(log (m+n))</code>.</p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> nums1 = [1,3], nums2 = [2]
<strong>Output:</strong> 2.00000
<strong>Explanation:</strong> merged array = [1,2,3] and median is 2.
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> nums1 = [1,2], nums2 = [3,4]
<strong>Output:</strong> 2.50000
<strong>Explanation:</strong> merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>nums1.length == m</code></li>
	<li><code>nums2.length == n</code></li>
	<li><code>0 &lt;= m &lt;= 1000</code></li>
	<li><code>0 &lt;= n &lt;= 1000</code></li>
	<li><code>1 &lt;= m + n &lt;= 2000</code></li>
	<li><code>-10<sup>6</sup> &lt;= nums1[i], nums2[i] &lt;= 10<sup>6</sup></code></li>
</ul>
<p>&nbsp;</p>  

## Solutions

### **JavaScript**

```javascript
/**
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @return {number}
 */
var findMedianSortedArrays = function(nums1, nums2) {
    let nums = nums1.concat(nums2).sort((a, b) => a - b);
    let len = nums.length;
    if (len % 2 == 0) {
        return (nums[len / 2 - 1] + nums[len / 2]) / 2;
    } else {
        return nums[Math.floor(len / 2)];
    }  
};
```

### **Python3**

```python
class Solution:
    def findMedianSortedArrays(self, nums1: List[int], nums2: List[int]) -> float:
        nums = sorted(nums1 + nums2)
        if len(nums) % 2 == 0:
            return (nums[len(nums)//2] + nums[len(nums)//2-1]) / 2
        else:
            return nums[len(nums)//2]
```

### **C++**

```cpp
class Solution
{
public:
    double findMedianSortedArrays(vector<int> &nums1, vector<int> &nums2)
    {
        int total = nums1.size() + nums2.size(), mid = total / 2;
        int i = 0, j = 0, k = 0, prev = 0, curr = 0;
        while (k <= mid)
        {
            prev = curr;
            if (i < nums1.size() && j < nums2.size())
            {
                if (nums1[i] < nums2[j])
                    curr = nums1[i++];
                else
                    curr = nums2[j++];
            }
            else if (i < nums1.size())
            {
                curr = nums1[i++];
            }
            else
            {
                curr = nums2[j++];
            }
            k++;
        }
        if (total % 2 == 0)
            return (prev + curr) / 2.0;
        else
            return curr;
    }
};
```

### **C#**

```csharp
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] merged = new int[nums1.Length + nums2.Length];
        int i = 0, j = 0, k = 0;
        while(i < nums1.Length && j < nums2.Length) {
            if(nums1[i] < nums2[j]) {
                merged[k++] = nums1[i++];
            } else {
                merged[k++] = nums2[j++];
            }
        }
        while(i < nums1.Length) {
            merged[k++] = nums1[i++];
        }
        while(j < nums2.Length) {
            merged[k++] = nums2[j++];
        }
        if(merged.Length % 2 == 0) {
            return (merged[merged.Length / 2 - 1] + merged[merged.Length / 2]) / 2.0;
        } else {
            return merged[merged.Length / 2];
        }
    }
}
```