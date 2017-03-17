﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression_Core
{
	static class LinearRegression
	{
		public static string PerformRegression(string points)
		{
			if (!GetPoints.machParenthesies(points))
			{
				return "Err: Unmatched parenthesies";
			}
			double[,] three = GetPoints.StringToArray(points);
			double a = 0, b = 0;
			
			for (int i = three.GetLength(0) - 1; i >= 0; i--)
			{
				a += Math.Pow(three[i, 0], 2);
				b += 2 * three[i, 0] * three[i, 1];
			}
			
			a *= 2;
			a = b / a;

			return a + "x";
		}
	}

	static class PolyRegression
	{
		public static string PerformRegression(string points)
		{
			if (!GetPoints.machParenthesies(points))
			{
				return "Err: Unmatched parenthesies";
			}
			double[,] three = GetPoints.StringToArray(points);
			double a = 0, b = 0;

			for (int i = three.GetLength(0) - 1; i >= 0; i--)
			{
				a += Math.Pow(three[i, 0], 4);
				b += 2 * Math.Pow(three[i, 0], 2) * three[i, 1];
			}

			a *= 2;
			a = b / a;

			return a + "x²";
		}
	}


	static class LineRegression
	{
		public static string PerformRegression(string points)
		{
			if (!GetPoints.machParenthesies(points))
			{
				return "Err: Unmatched parenthesies";
			}
			return points;
		}
	}


	static class PolynominalRegression
	{
		public static string PerformRegression(string points)
		{
			if (!GetPoints.machParenthesies(points))
			{
				return "Err: Unmatched parenthesies";
			}
			double[,] series = GetPoints.StringToArray(points);
			double a = 0, b = 0, c = 0, d = 0, e = 0;
			for (int i = series.GetLength(0) - 1; i >= 0; i--)
			{
				a += Math.Pow(series[i, 0], 4);
				Console.WriteLine(a);
				b += series[i, 0] * Math.Pow(series[i, 0], 2);
				c += Math.Pow(series[i, 0], 2);
				d += Math.Pow(series[i, 0], 2) * series[i, 1];
				e += series[i, 0] * series[i, 1];
			}
			Console.WriteLine(a);
			Console.WriteLine(b);
			Console.WriteLine(c);
			Console.WriteLine(d);
			Console.WriteLine(e);
			double coeff1 = ((-b) * e + c * d) / (a * c - Math.Pow(b, 2));
			double coeff2 = (a * e - b * d) / (a * c - Math.Pow(b, 2));

			return coeff1 + "x² + " + coeff2 + "x";
		}
	}
}
