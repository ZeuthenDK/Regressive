using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression_Core
{
	static class GetPoints
	{
		public static double[,] StringToArray(string input)
		{
			int numOfCoordinates = 0;

			//Counts number of x-y coordinate pairs
			for (int i = input.Length - 1; i >= 0; i--)
			{
				if (input[i].Equals(';'))
				{
					numOfCoordinates++;
				}
			}

			//Creates a multidimentional array that can hold all coordinate pairs
			double[,] coordinates = new double[numOfCoordinates, 2];
			int coordinatePlace = 0;
			for (int i = 0; i < input.Length; i++)
			{
				if (isNumber(input[i]))
				{
					//Creates a temporary string, and adds characters as long as they are a number
					string temp = "";
					while (isNumber(input[i]))
					{
						temp += input[i];
						i++;
					}
					//Adds the x-coordinate to the array
					coordinates[coordinatePlace, 0] = double.Parse(temp);

					//It assumes that after each x-coordinate, there is a ';' character, and then the y-coordinate
					temp = "";
					i++;
					while (isNumber(input[i]))
					{
						temp += input[i];
						i++;
					}
					coordinates[coordinatePlace, 1] = double.Parse(temp);
					coordinatePlace++;
					
				}
				
			}
			
			return coordinates;
		}


		static bool isNumber(char toTest)
		{
			if (toTest == '0' ||
				toTest == '1' ||
				toTest == '2' ||
				toTest == '3' ||
				toTest == '4' ||
				toTest == '5' ||
				toTest == '6' ||
				toTest == '7' ||
				toTest == '8' ||
				toTest == '9' ||
				toTest == ',' ||
				toTest == '-')
			{
				return true;
			}
			return false;
		}
	}
}
