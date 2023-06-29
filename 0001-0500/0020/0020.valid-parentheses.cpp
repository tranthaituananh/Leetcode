/*
 * @lc app=leetcode id=20 lang=cpp
 *
 * [20] Valid Parentheses
 */

// @lc code=start
class Solution
{
public:
    bool isValid(string s)
    {
        char c;
        stack<char> st;
        for (int i = 0; i < s.size(); i++)
        {

            switch (s[i])
            {
            case '(':
                st.push(s[i]);
                break;
            case '{':
                st.push(s[i]);
                break;
            case '[':
                st.push(s[i]);
                break;
            case ')':
                if (st.empty())
                {
                    return false;
                }
                if (st.top() != '(')
                {
                    return false;
                }
                st.pop();
                break;
            case '}':
                if (st.empty())
                {
                    return false;
                }
                if (st.top() != '{')
                {
                    return false;
                }
                st.pop();
                break;
            case ']':
                if (st.empty())
                {
                    return false;
                }
                if (st.top() != '[')
                {
                    return false;
                }
                st.pop();
                break;
            default:
                return false;
            }
        }
        return st.empty();
    }
};
// @lc code=end
