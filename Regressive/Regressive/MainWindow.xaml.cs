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
			
			//var data = new DataContainer(1f, 2f);
			//Coordinates.Items.Add(data);
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

		private void TextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			int i = int.Parse((((TextBox)sender).Name).Substring(1));
			if (i == rows)
			{
				newCoordinateSet();
			}
		}

		int rows = 1;

		public void newCoordinateSet()
		{
			RowDefinition row = new RowDefinition();
			row.Height = new GridLength(21);
			CoordinateGrid.RowDefinitions.Add(row);

			TextBox CX = new TextBox();
			rows++;	
			Grid.SetRow(CX, rows);
			Grid.SetColumn(CX, 0);
			CoordinateGrid.Children.Add(CX);

			TextBox CY = new TextBox();
			CY.Name = "r" + rows.ToString();
			CY.GotFocus += new RoutedEventHandler(TextBox_GotFocus);
			Grid.SetRow(CY, rows);
			Grid.SetColumn(CY, 1);
			CoordinateGrid.Children.Add(CY);
		}
	}
}
