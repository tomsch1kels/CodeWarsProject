// https://www.codewars.com/kata/52742f58faf5485cae000b9a
// 4 kyu

internal static class HumanTimeFormat
{
    public static string FormatDuration(int numberOfSeconds)
    {
        // PSUEDO CODE
        // bepaal aantallen
        //  tel aantallen jaren met / operator
        //  haal seconden voor jaren eraf
        //  herhaal voor andere eenheden
        // bouw string op
        //  bepaal eerst onderdelen
        //   maak string voor aantal jaren, maanden etc.
        //  voeg dan interpunctie toe
        //   tussen de laatste twee komt een 'and'
        //   tussend de anderen komt een komma
        // years, days, hours, minutes and seconds.
        if (numberOfSeconds == 0)
        {
            return "now";
        }

        int nSeconds;
        int nMinutes;
        int nHours;
        int nDays;
        int nYears;

        DetermineAmounts();
        List<string> subStrings = BuildSubStrings()
            .Where(s => !string.IsNullOrEmpty(s))
            .ToList();

        return AddInterpunction();

        void DetermineAmounts()
        {
            int minuteLength = 60;
            int hourLength = 60 * minuteLength;
            int dayLength = 24 * hourLength;
            int yearLength = 365 * dayLength;

            nYears = numberOfSeconds / yearLength;
            numberOfSeconds -= nYears * yearLength;
            nDays = numberOfSeconds / dayLength;
            numberOfSeconds -= nDays * dayLength;
            nHours = numberOfSeconds / hourLength;
            numberOfSeconds -= nHours * hourLength;
            nMinutes = numberOfSeconds / 60;
            numberOfSeconds -= nMinutes * 60;
            nSeconds = numberOfSeconds;
        }

        List<string> BuildSubStrings() =>
        [
            GetStringFor("year", nYears),
            GetStringFor("day", nDays),
            GetStringFor("hour", nHours),
            GetStringFor("minute", nMinutes),
            GetStringFor("second", nSeconds),
        ];

        string AddInterpunction() => subStrings.Count switch
        {
            1 => subStrings.First(),
            2 => string.Join(" and ", subStrings),
            _ => AddComplicatedInterpunction(),
        };

        string AddComplicatedInterpunction()
        {
            string lastPart = string.Join(" and ", subStrings.TakeLast(2));

            return string.Join(", ", subStrings.Take(subStrings.Count - 2).Append(lastPart));
        }

        string GetStringFor(string singularUnitString, int countOfUnits)
        => countOfUnits switch
        {
            0 => string.Empty,
            1 => "1 " + singularUnitString,
            _ => countOfUnits + " " + singularUnitString + "s",
        };
    }
}