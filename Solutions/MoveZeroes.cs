// https://www.codewars.com/kata/52597aa56021e91c93000cb0
// 5 kyu

internal static class MoveZeroes
{
    public static int[] Solve(int[] arr) => arr.OrderBy(i => i == 0).ToArray();
}
