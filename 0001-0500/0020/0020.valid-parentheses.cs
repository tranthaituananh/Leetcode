/*
 * @lc app=leetcode id=20 lang=csharp
 *
 * [20] Valid Parentheses
 */

// @lc code=start
public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s) {
            if (c == '(' || c == '{' || c == '[') {
                stack.Push(c);
            } else if (stack.Count > 0 && ((c == ')' && stack.Peek() == '(') || (c == '}' && stack.Peek() == '{') || (c == ']' && stack.Peek() == '['))) {
                stack.Pop();
            } else {
                return false;
            }
        }
        return stack.Count == 0;
    }
}
// @lc code=end

