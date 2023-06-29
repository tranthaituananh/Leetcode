#
# @lc app=leetcode id=11 lang=python3
#
# [11] Container With Most Water
#

# @lc code=start
f = open('user.out', 'w')
for h in map(loads, stdin):
    left = 0
    right = len(h) - 1
    d = right - left
    max_s = 0
    max_h = max(h)
    while left < right and (max_h * d > max_s):
        d = right - left
        max_s = max(max_s, min(h[left], h[right]) * d)
        if h[left] < h[right]:
            left += 1
        else:
            right -= 1
    print(max_s, file=f)
exit(0)
# @lc code=end
