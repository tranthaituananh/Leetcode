/*
 * @lc app=leetcode id=18 lang=csharp
 *
 * [18] 4Sum
 */

// @lc code=start
public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        Array.Sort(nums);

        var originalK = 4;
        var matches = new List<IList<int>>();
        var backtrack = new int[originalK - 2];

        KSum(target, 0, originalK);

        return matches;

        void KSum(long target, int start, int k)
        {
            if (start > nums.Length - k)
            {
                return;
            }

            var avg = target / k;
            if (nums[start] > avg || avg > nums.Last())
            {
                return;
            }

            if (k == 2)
            {
                TwoSum(target, start);
                return;
            }

            for (var i = start; i < nums.Length; i++)
            {
                if (i == start || nums[i - 1] != nums[i])
                {
                    var depth = originalK - k;
                    backtrack[depth] = nums[i];

                    KSum(target - nums[i], i + 1, k - 1);
                }
            }
        }

        void TwoSum(long target, int start)
        {
            var (left, right) = (start, nums.Length - 1);

            while (left < right)
            {
                var sum = nums[left] + nums[right];

                if (sum < target)
                {
                    left++;
                    continue;
                }
                
                if (sum > target)
                {
                    --right;
                    continue;
                }

                matches.Add(new List<int>(backtrack) { nums[left], nums[right] });

                left++;
                right--;

                while (left < right && nums[left] == nums[left - 1])
                {
                    left++;
                }
            }
        }
    }
}
// @lc code=end

