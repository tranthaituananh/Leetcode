/*
 * @lc app=leetcode id=23 lang=csharp
 *
 * [23] Merge k Sorted Lists
 */

// @lc code=start
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
// @lc code=end

