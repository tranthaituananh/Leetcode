# [42. Trapping Rain Water](https://leetcode.com/problems/trapping-rain-water/)

## Description

<p>Given <code>n</code> non-negative integers representing an elevation map where the width of each bar is <code>1</code>, compute how much water it can trap after raining.</p>

<p><strong class="example">Example 1:</strong></p>
<img src="https://assets.leetcode.com/uploads/2018/10/22/rainwatertrap.png" style="width: 412px; height: 161px;">
<pre><strong>Input:</strong> height = [0,1,0,2,1,0,1,3,2,1,2,1]
<strong>Output:</strong> 6
<strong>Explanation:</strong> The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> height = [4,2,0,3,2,5]
<strong>Output:</strong> 9
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>n == height.length</code></li>
	<li><code>1 &lt;= n &lt;= 2 * 10<sup>4</sup></code></li>
	<li><code>0 &lt;= height[i] &lt;= 10<sup>5</sup></code></li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * @param {number[]} height
 * @return {number}
 */
var trap = function (height) {
    let n = height.length;
    let left = new Array(n);
    let right = new Array(n);
    let ans = 0;
    left[0] = height[0];
    for (let i = 1; i < n; i++) {
        left[i] = Math.max(left[i - 1], height[i]);
    }
    right[n - 1] = height[n - 1];
    for (let i = n - 2; i >= 0; i--) {
        right[i] = Math.max(right[i + 1], height[i]);
    }
    for (let i = 0; i < n; i++) {
        ans += Math.min(left[i], right[i]) - height[i];
    }
    return ans;
};
```

### **Python3**

```python
class Solution:
    def trap(self, height: List[int]) -> int:
        if not height:
            return 0
        left, right = 0, len(height) - 1
        left_max, right_max = height[left], height[right]
        res = 0
        while left < right:
            left_max, right_max = max(height[left], left_max), max(height[right], right_max)
            if left_max < right_max:
                res += left_max - height[left]
                left += 1
            else:
                res += right_max - height[right]
                right -= 1
        return res
```

### **C++**

```cpp
class Solution
{
public:
    int trap(vector<int> &height)
    {
        int n = height.size();
        if (n == 0)
            return 0;

        int left = 0, right = n - 1;
        int leftMax = height[left], rightMax = height[right];
        int res = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] < leftMax)
                {
                    res += leftMax - height[left];
                }
                else
                {
                    leftMax = height[left];
                }
                left++;
            }
            else
            {
                if (height[right] < rightMax)
                {
                    res += rightMax - height[right];
                }
                else
                {
                    rightMax = height[right];
                }
                right--;
            }
        }
        return res;
    }
};
```

### **C#**

```csharp
public class Solution {
    public int Trap(int[] height) {
        int left = 0, right = height.Length - 1;
        int leftMax = 0, rightMax = 0;
        int res = 0;
        while (left < right) {
            if (height[left] < height[right]) {
                if (height[left] >= leftMax) {
                    leftMax = height[left];
                } else {
                    res += leftMax - height[left];
                }
                left++;
            } else {
                if (height[right] >= rightMax) {
                    rightMax = height[right];
                } else {
                    res += rightMax - height[right];
                }
                right--;
            }
        }
        return res;
    }
}
```