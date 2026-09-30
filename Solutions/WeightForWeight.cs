// https://www.codewars.com/kata/55c6126177c9441a570000cc
// 5 kyu

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;



public class WeightForWeight
{
    public static string Solve(string strng)
    {
        if (!strng.Contains(' '))
        {
            return strng;
        }

        List<(double Weight, string Mass)> tupleList = [];

        foreach (var mass in strng.Split(' ').ToList())
        {
            tupleList.Add((Weight: CalcWeightFromMass(mass), Mass: mass));
        }

        static double CalcWeightFromMass(string mass)
        {
            return (double)mass.ToList().Sum(Char.GetNumericValue);
        }

        var sortedMasses = tupleList
            .OrderBy(item => item.Weight)
            .ThenBy(item => item.Mass, StringComparer.Ordinal);

        return string.Join(' ', sortedMasses.Select(item => item.Mass));
    }

}