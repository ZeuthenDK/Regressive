using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Regressive
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public class DataContainer
	{
		public DataContainer(float d1, float d2)
		{
			this.Data1 = d1;
			this.Data2 = d2;
		}
		public float Data1 { get; set; }
		public float Data2 { get; set; }
	}

	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();
		}

		//Event when clicking, or changing with the keyboard, the "Show Grid" Checkbox
		private void Show_Grid_Click(object sender, RoutedEventArgs e)
		{
			//IsChecked is the type 'bool?', which can be null. 'Show_Grid.IsChecked ?? true' returns 'true' if the value is null
			if (Show_Grid.IsChecked ?? true)
			{
				MessageBox.Show("You Clicked on \"Show Grid\". It is now showing the grid");
			}
			else
			{
				MessageBox.Show("You Clicked on \"Show Grid\". It is now hiding the grid");
			}
			
		}

		private void Graph_Area_MouseMove(object sender, MouseEventArgs e)
		{
			string x = Math.Round((e.GetPosition(Graph_Area).X - 0.2), 1).ToString();
			string y = Math.Round((e.GetPosition(Graph_Area).Y - 0.2), 1).ToString();
			Coordinates_Display.Text = x + ";" + y;
		}

		//When the TextBox in the Y column gets focus, it checks if it is the last one. If it is, it adds a new row
		private void TextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			int i = int.Parse((((TextBox)sender).Name).Substring(1));
			if (i == rows)
			{
				newCoordinateSet();
			}
		}

		//The rows variable is used to keep track of the number of rows in the coordinate input field
		int rows = 1;

		//Creates a new row with at text box for x and y coordinates
		public void newCoordinateSet()
		{
			//Creates a new row definition, sets its height and adds it to the grid
			RowDefinition row = new RowDefinition();
			row.Height = new GridLength(21);
			CoordinateGrid.RowDefinitions.Add(row);
			rows++;

			//Creates a TextBox for a x-coordinate, defines the row and collumn to put it in, and adds it to the coordinate grid
			TextBox CX = new TextBox();
			Grid.SetRow(CX, rows);
			Grid.SetColumn(CX, 0);
			CoordinateGrid.Children.Add(CX);

			//Same as above, but gives it a name to later tell if it is the bottom one. The name cannot be a number (I think)
			TextBox CY = new TextBox();
			CY.Name = "r" + rows.ToString();
			//Subscribes to the GotFocus event, and runs the apropriate method to handle it
			CY.GotFocus += new RoutedEventHandler(TextBox_GotFocus);
			Grid.SetRow(CY, rows);
			Grid.SetColumn(CY, 1);
			CoordinateGrid.Children.Add(CY);
		}


		private void PerformLinear_Click(object sender, RoutedEventArgs e)
		{
			getPointSeries();
		}
		
		//Returns (not yet returning, just shows the values of) a two dimensional array containing the coordinates for all points
		public void /*double[,]*/ getPointSeries()
		{
			double[,] points = new double[rows - 1, 2];
			int toTrim = 0;

			//For each child element, skipping the first two that are TextBlocks, not TextBoxes, and the last two that will always be empty
			//The variable i is for the numbers of child elements, whilst the variable s is where to store the coordinates in the arrays first dimension
			for (int i = 2, s = 0; i < CoordinateGrid.Children.Count - 2; i++, s++)
			{
				//If a set of coordinates is empty, it skips them, and tells that a set should be removed from the end of the array.
				if (((TextBox)CoordinateGrid.Children[i]).Text.Length < 1 && ((TextBox)CoordinateGrid.Children[i + 1]).Text.Length < 1)
				{
					i += 2;
					toTrim++;
				}
				else
				{
					//Parses the x-coordinate. Returns false if it fails to parse
					bool sucess = double.TryParse(((TextBox)CoordinateGrid.Children[i]).Text.Replace(" ", "").Replace('.', ','), out points[s, 0]);
					if (!sucess)
					{
						MessageBox.Show("The value of box X" + (s + 1) + ": " + ((TextBox)CoordinateGrid.Children[i]).Text + " is not a valid number");
						return;
					}

					i++;

					sucess = double.TryParse(((TextBox)CoordinateGrid.Children[i]).Text.Replace(" ", "").Replace('.', ','), out points[s, 1]);
					if (!sucess)
					{
						MessageBox.Show("The value of box Y" + (s + 1) + ": " + ((TextBox)CoordinateGrid.Children[i]).Text + " is not a valid number");
						return;
					}
				}

			}

			//Creates a new array to remove explicit empty rows
			//double is not nullable, so it would otherwise contain a point (0;0) for each empty row
			double[,] newPoints = new double[rows - 1 - toTrim, 2];
			newPoints = points;

			//Turns the coordinates into a string for debugging
			string coordinates = "";
			for (int i = 0; i < rows - 1 - toTrim; i++)
			{
				coordinates += "(" + newPoints[i, 0] + ";" + newPoints[i, 1] + ")";
			}
			
			//If there are not coordinates to any points
			if (newPoints.GetLength(0) < 1)
			{
				MessageBox.Show("No points :(");
				return;
			}
			//For debugging:
			MessageBox.Show(coordinates);
			
			/*return newPoints;*/
		}
	}
}
