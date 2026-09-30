// https://www.codewars.com/kata/5541f58a944b85ce6d00006a
// 5 kyu

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public class ProductFib
{
    public static ulong[] Solve(ulong prod)
    {
        ulong a = 0, b = 1;

        while (true)
        {
            if (a * b == prod || a * b > prod)
            {
                ulong success = (a * b == prod) ? 1UL : 0;
                return [a, b, success];
            }

            ulong temp = a + b;
            a = b;
            b = temp;
        }
    }
}