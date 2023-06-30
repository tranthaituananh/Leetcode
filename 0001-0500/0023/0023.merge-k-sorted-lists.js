/*
 * @lc app=leetcode id=23 lang=javascript
 *
 * [23] Merge k Sorted Lists
 */

// @lc code=start
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
// @lc code=end

