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
	}
}
