// https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c
// 5 kyu

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

internal static class MaxSequence
{
    public static int Solve(int[] arr)
    {
        if (arr.Length == 0) return 0;

        int result = 0;

        //   0  1   2  3   4  5  6   7  8
        // {-2, 1, -3, 4, -1, 2, 1, -5, 4}

        for (int subsetLength = 1; subsetLength <= arr.Length; subsetLength++)
        {
            for (int startIndex = 0; startIndex <= arr.Length - subsetLength; startIndex++)
            {
                int localSum = 0;
                for (int currentIndex = startIndex; currentIndex < startIndex + subsetLength; currentIndex++)
                {
                    localSum += arr[currentIndex];
                }
                if (localSum > result) result = localSum;
            }
        }
        return result;
    }
}