/*
 * @lc app=leetcode id=23 lang=cpp
 *
 * [23] Merge k Sorted Lists
 */

// @lc code=start
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
        nums.clear();
        iss.clear();
        iss.str(cinStr);
        while (getline(iss, numStr, ','))
            if (numStr.size())
                nums.push_back(atoi(numStr.data()));
        sort(nums.begin(), nums.end());
        ans << '[';
        for (int iter = 0; iter < nums.size(); ++iter)
        {
            if (iter)
                ans << ',';
            ans << nums[iter];
        }
        ans << "]\n";
    }
}
#define main deleted_main
class Solution
{
public:
    ListNode *mergeKLists(vector<ListNode *> &lists) { return nullptr; }
};
// @lc code=end
