// https://www.codewars.com/kata/5270d0d18625160ada0000e4/train/csharp
// 5 kyu

internal static class GreedIsGood
{
    public static int Solve(int[] dice)
    {
        int[] ocurrences = [0, 0, 0, 0, 0, 0, 0];

        foreach (int die in dice)
        {
            ocurrences[die]++;
        }

        return
        (ocurrences[1] / 3 * 1000) + ((ocurrences[1] % 3) * 100) +
        (ocurrences[2] / 3 * 200) +
        (ocurrences[3] / 3 * 300) +
        (ocurrences[4] / 3 * 400) +
        (ocurrences[5] / 3 * 500) + ((ocurrences[5] % 3) * 50) +
        (ocurrences[6] / 3 * 600);
    }
}