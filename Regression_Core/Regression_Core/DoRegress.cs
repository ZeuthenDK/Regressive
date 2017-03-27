using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression_Core
{
	static class Regression
	{
		public static string SlopeRegression(string points)
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


		public static string SquareRegression(string points)
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


		public static Coefficients PolynominalRegression(double[,] series)
		{
			
			double a = 0, b = 0, c = 0, d = 0, e = 0;
			for (int i = series.GetLength(0) - 1; i >= 0; i--)
			{
				a += Math.Pow(series[i, 0], 4);
				b += series[i, 0] * Math.Pow(series[i, 0], 2);
				c += Math.Pow(series[i, 0], 2);
				d += Math.Pow(series[i, 0], 2) * series[i, 1];
				e += series[i, 0] * series[i, 1];
			}
			/*Console.WriteLine(a);
			Console.WriteLine(b);
			Console.WriteLine(c);
			Console.WriteLine(d);
			Console.WriteLine(e);*/
			double coeff1 = ((-b) * e + c * d) / (a * c - Math.Pow(b, 2));
			double coeff2 = (a * e - b * d) / (a * c - Math.Pow(b, 2));

			return new Coefficients(coeff1, coeff2);
		}


		public static Coefficients LinearRegression(double[,] series)
		{
			double a = 0, b = 0, c = 0, d = 0, e = 0;
			for (int i = series.GetLength(0) - 1; i >= 0; i--)
			{
				a += Math.Pow(series[i, 0], 2);
				b += series[i, 0];
				c += 1;
				d += series[i, 0] * series[i, 1];
				e += series[i, 1];
			}
			Console.WriteLine(a);
			Console.WriteLine(b);
			Console.WriteLine(c);
			Console.WriteLine(d);
			Console.WriteLine(e);
			double coeff1 = (-b * e + c * d) / (a * c - Math.Pow(b, 2));
			double coeff2 = (a * e - b * d) / (a * c - Math.Pow(b, 2));
			return new Coefficients(coeff1, coeff2);
		}


		public static Coefficients ExponentialRegression(double[,] series)
		{ 
			double a = 0, b = 0, c = 0, d = 0, e = 0;
			for (int i = series.GetLength(0) - 1; i >= 0; i--)
			{
				a += Math.Pow(series[i, 0], 2);
				b += series[i, 0];
				c += 1;
				d += series[i, 0] * Math.Log(series[i, 1]);
				e += Math.Log(series[i, 1]);
			}
			/*Console.WriteLine(a);
			Console.WriteLine(b);
			Console.WriteLine(c);
			Console.WriteLine(d);
			Console.WriteLine(e);*/
			double coeff1 = Math.Pow(Math.E, (-b * e + c * d) / (a * c - Math.Pow(b, 2)));
			double coeff2 = Math.Pow(Math.E, (a * e - b * d) / (a * c - Math.Pow(b, 2)));
			return new Coefficients(coeff1, coeff2);
		}
	}

	public class Coefficients
	{
		double a, b;

		public Coefficients(double a, double b)
		{
			this.a = a;
			this.b = b;
		}
		
	}
}
