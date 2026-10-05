// https://www.codewars.com/kata/5270d0d18625160ada0000e4/train/csharp
// 5 kyu

internal static class GreedIsGood
{
    public static int Solve(int[] dice)
    {
        int tripletNumber = WhichTriplet(dice);
        if (tripletNumber == 0)
        {
            return ScoreSinglesIn(dice);
        }
        else
        {
            return ScoreTriplet(tripletNumber) + ScoreSinglesIn(RemoveTripletFrom(dice, tripletNumber));
        }

        int[] RemoveTripletFrom(int[] dice, int tripletNumber)
        {
            List<int> newNumbers = [];

            int counter = 0;
            foreach (int die in dice)
            {
                if (die == tripletNumber && counter < 3)
                {
                    counter++;
                }
                else
                {
                    newNumbers.Add(die);
                }
            }

            return [.. newNumbers];
        }

        int ScoreTriplet(int number) => number switch
        {
            1 => 1000,
            6 => 600,
            5 => 500,
            4 => 400,
            3 => 300,
            2 => 200,
            _ => throw new ArgumentException("Impossible die!"),
        };

        int WhichTriplet(int[] dice)
        {
            int[] ocurrences = [0, 0, 0, 0, 0, 0, 0];

            foreach (int die in dice)
            {
                ocurrences[die]++;
                if (ocurrences[die] == 3)
                {
                    return die;
                }
            }

            return 0;
        }

        int ScoreSinglesIn(int[] dice)
        {
            int result = 0;

            foreach (int die in dice)
            {
                result += die switch {
                    1 => 100,
                    5 => 50,
                    _ => 0,
                    };
            }

            return result;
        }
    }
}