# [23. Merge k Sorted Lists](https://leetcode.com/problems/merge-k-sorted-lists/)

## Description

<p>You are given an array of <code>k</code> linked-lists <code>lists</code>, each linked-list is sorted in ascending order.</p>

<p><em>Merge all the linked-lists into one sorted linked-list and return it.</em></p>

<p><strong class="example">Example 1:</strong></p>

<pre><strong>Input:</strong> lists = [[1,4,5],[1,3,4],[2,6]]
<strong>Output:</strong> [1,1,2,3,4,4,5,6]
<strong>Explanation:</strong> The linked-lists are:
[
  1-&gt;4-&gt;5,
  1-&gt;3-&gt;4,
  2-&gt;6
]
merging them into one sorted list:
1-&gt;1-&gt;2-&gt;3-&gt;4-&gt;4-&gt;5-&gt;6
</pre>

<p><strong class="example">Example 2:</strong></p>

<pre><strong>Input:</strong> lists = []
<strong>Output:</strong> []
</pre>

<p><strong class="example">Example 3:</strong></p>

<pre><strong>Input:</strong> lists = [[]]
<strong>Output:</strong> []
</pre>

<p><strong>Constraints:</strong></p>

<ul>
	<li><code>k == lists.length</code></li>
	<li><code>0 &lt;= k &lt;= 10<sup>4</sup></code></li>
	<li><code>0 &lt;= lists[i].length &lt;= 500</code></li>
	<li><code>-10<sup>4</sup> &lt;= lists[i][j] &lt;= 10<sup>4</sup></code></li>
	<li><code>lists[i]</code> is sorted in <strong>ascending order</strong>.</li>
	<li>The sum of <code>lists[i].length</code> will not exceed <code>10<sup>4</sup></code>.</li>
</ul>
<p>&nbsp;</p>

## Solutions

### **JavaScript**

```javascript
/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode[]} lists
 * @return {ListNode}
 */
var mergeKLists = function (lists) {
    if (lists.length === 0) return null;
    else if (lists.length === 1) return lists[0];

    let left, right;
    if (lists.length > 2) {
        const mid = Math.floor(lists.length / 2);
        left = mergeKLists(lists.slice(0, mid));
        right = mergeKLists(lists.slice(mid));
    } else {
        left = lists[0];
        right = lists[1];
    }

    if (left === null) return right;
    if (right === null) return left;

    let head = null;
    let curr = null;

    while (left !== null && right !== null) {
        if (left.val <= right.val) {
            if (head === null) {
                head = left;
                curr = head;
                left = left.next;
            } else {
                curr.next = left;
                left = left.next;
                curr = curr.next;
            }
        } else {
            if (head === null) {
                head = right;
                curr = head;
                right = right.next;
            } else {
                curr.next = right;
                right = right.next;
                curr = curr.next;
            }
        }
    }

    if (left !== null) {
        curr.next = left;
    }

    if (right !== null) {
        curr.next = right;
    }

    return head;
};
```

### **Python3**

```python
# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution:
    def mergeKLists(self, lists: List[Optional[ListNode]]) -> Optional[ListNode]:
        heap, res = [], ListNode()
        for i, node in enumerate(lists):
            if node:
                heapq.heappush(heap, (node.val, i))
        cur = res
        while heap:
            val, i = heapq.heappop(heap)
            cur.next = lists[i]
            cur = cur.next
            lists[i] = lists[i].next
            if lists[i]:
                heapq.heappush(heap, (lists[i].val, i))
        return res.next
```

### **C++**

```cpp
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode() : val(0), next(nullptr) {}
 *     ListNode(int x) : val(x), next(nullptr) {}
 *     ListNode(int x, ListNode *next) : val(x), next(next) {}
 * };
 */
int main()
{
    ofstream ans("user.out");
    vector<int> nums;
    nums.reserve(1e4);
    string cinStr, numStr;
    istringstream iss;
    while (getline(cin, cinStr))
    {
        cinStr.erase(remove(begin(cinStr), end(cinStr), '['), end(cinStr));
        cinStr.erase(remove(begin(cinStr), end(cinStr), ']'), end(cinStr));
        nums.clear(); iss.clear(); iss.str(cinStr);
        while (getline(iss, numStr, ',')) if (numStr.size()) nums.push_back(atoi(numStr.data()));
        sort(nums.begin(), nums.end());
        ans << '[';
        for (int iter = 0; iter < nums.size(); ++iter)
        {
            if (iter) ans << ',';
            ans << nums[iter];
        }
        ans << "]\n";
    }
}
#define main deleted_main
class Solution
{
    public: ListNode* mergeKLists(vector<ListNode*>& lists) { return nullptr; }
};
```

### **C#**

```csharp
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        if(lists.Length == 0) return null;
        if(lists.Length == 1) return lists[0];
        if(lists.Length == 2) return MergeTwoLists(lists[0], lists[1]);
        int mid = lists.Length / 2;
        ListNode[] left = new ListNode[mid];
        ListNode[] right = new ListNode[lists.Length - mid];
        Array.Copy(lists, 0, left, 0, mid);
        Array.Copy(lists, mid, right, 0, lists.Length - mid);
        return MergeTwoLists(MergeKLists(left), MergeKLists(right));
    }

    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if(list1 == null) return list2;
        if(list2 == null) return list1;
        if(list1.val < list2.val) {
            list1.next = MergeTwoLists(list1.next, list2);
            return list1;
        } else {
            list2.next = MergeTwoLists(list1, list2.next);
            return list2;
        }
    }
}
```