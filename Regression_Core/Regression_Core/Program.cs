using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression_Core
{
	class Program
	{
		static string input = "";
		static void Main(string[] args)
		{
			Console.WriteLine("Enter L or P and points as ex (2;3,4)(3,56;0)");
			while (true)
			{
				input = Console.ReadLine();
				if (input.ToUpper() == "EXIT" || input.ToUpper() == "EX")
				{
					break;
				}
				if (input.Length < 1)
				{
					input = "_";
				}
				input = input.Replace(" ", "");

				switch (input[0])
				{
					case 'S':
						Console.WriteLine(Regression.SlopeRegression(input.Substring(1)));
						break;
					case '2':
						Console.WriteLine(Regression.SquareRegression(input.Substring(1)));
						break;
					case 'P':
						Console.WriteLine(Regression.PolynominalRegression(input.Substring(1)));
						break;
					case 'L':
						Console.WriteLine(Regression.LinearRegression(input.Substring(1)));
						break;
					case 'E':
						Console.WriteLine(Regression.ExponentialRegression(input.Substring(1)));
						break;
					default:
						Console.WriteLine("Err: Illigal function type " + input[0] + " not reconized");
						break;

				}
				

			}
		}
	}
}
