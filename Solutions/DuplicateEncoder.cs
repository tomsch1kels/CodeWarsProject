// https://www.codewars.com/kata/54b42f9314d9229fd6000d9c
// 6 kyu

internal static class DuplicateEncoder
{

    public static string DuplicateEncode(string word)
    {
        word = word.ToLowerInvariant();

        Dictionary<char, int> occurences = [];

        word.ToList().ForEach(
            c => occurences[c] = 1 + occurences.GetValueOrDefault(c));

        return string.Concat(word.ToList().Select(
            c => occurences[c] == 1 ? '(' : ')'));
    }
}
