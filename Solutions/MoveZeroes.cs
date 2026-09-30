// https://www.codewars.com/kata/52597aa56021e91c93000cb0
// 5 kyu

using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

internal static class MoveZeroes
{
    public static int[] Solve(int[] arr)
    {
        return arr.OrderBy(i => i == 0).ToArray();
        // int[] result = new int[arr.Length];
        // int c = 0;
        // for (int i = 0; i < arr.Length; i++)
        // {
        //     if (arr[i] != 0)
        //     {
        //         result[c] = arr[i];
        //         c++;
        //     }
        // }
        // return result;
    }
}
