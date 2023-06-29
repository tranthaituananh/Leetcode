/*
 * @lc app=leetcode id=3 lang=csharp
 *
 * [3] Longest Substring Without Repeating Characters
 */

// @lc code=start
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var len=0;
        var n=s.Length;
        var i=0; 
        var dict=new Dictionary<char,int>();//char and indexes
        var start=0;// from where we start calculating maxLength
       
        while(i<n)
        {
            if(dict.ContainsKey(s[i]))
            {
                var lastIndexOfChar=dict[s[i]];
                //if the last occurence already out no need to change start
                start=lastIndexOfChar>=start?lastIndexOfChar+1:start;                
                dict[s[i]]=i; 
                            
            }
            else
            {
                dict.Add(s[i],i);
            }           
            i++;
            len=Math.Max(len,i-start);        
                             


        }
        
        return len;
    }
}
// @lc code=end

