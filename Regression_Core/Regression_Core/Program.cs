﻿using System;
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
				//input = Console.ReadLine();
				if (input.ToUpper() == "EXIT" || input.ToUpper() == "EX")
				{
					break;
				}
				Console.WriteLine(LinearRegression.PerformRegression("(200;0)(3;4)(2,34;3)"));
				Console.ReadLine();

			}
		}
	}
}
