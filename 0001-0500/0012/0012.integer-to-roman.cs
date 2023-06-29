/*
 * @lc app=leetcode id=12 lang=csharp
 *
 * [12] Integer to Roman
 */

// @lc code=start
public class Solution {
    public string IntToRoman(int num) {
        var sb = new StringBuilder();
        var map = new Dictionary<int, string> {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };
        
        foreach (var pair in map) {
            while (num >= pair.Key) {
                sb.Append(pair.Value);
                num -= pair.Key;
            }
        }
        
        return sb.ToString();
    }
}
// @lc code=end

