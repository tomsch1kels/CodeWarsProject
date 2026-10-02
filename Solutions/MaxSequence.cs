// https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c
// 5 kyu

internal static class MaxSequence
{
    public static int Solve(int[] arr)
    {
        if (arr.Length == 0)
        {
            return 0;
        }

        int result = 0;
        for (int subsetLength = 1; subsetLength <= arr.Length; subsetLength++)
        {
            for (int startIndex = 0; startIndex <= arr.Length - subsetLength; startIndex++)
            {
                int localSum = 0;
                for (int currentIndex = startIndex; currentIndex < startIndex + subsetLength; currentIndex++)
                {
                    localSum += arr[currentIndex];
                }

                if (localSum > result)
                {
                    result = localSum;
                }
            }
        }

        return result;
    }
}