// https://www.codewars.com/kata/55c45be3b2079eccff00010f
// 6 kyu

internal static class Order
{
    public static string Solve(string words)
    {
        if (string.IsNullOrEmpty(words))
        {
            return string.Empty;
        }

        SortedDictionary<int, string> sDict = [];

        foreach (string word in words.Split())
        {
            sDict[word.Single(char.IsDigit)] = word;
        }

        return string.Join(" ", sDict.Values.ToArray());
    }
}
