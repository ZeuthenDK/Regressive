using System;
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
}
