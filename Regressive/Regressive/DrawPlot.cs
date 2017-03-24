using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Regressive
{
	using System;
	using OxyPlot;
	using OxyPlot.Axes;
	using OxyPlot.Series;

	public class DrawPlot
	{
		public DrawPlot()
		{
			this.Model = new PlotModel { Title = "Example 1" };
			this.Model.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
		}

		public PlotModel Model { get; private set; }


		/*public MainViewModel()
		{
			MyModel = CreatePlotModel();
		}

		public PlotModel CreatePlotModel()
		{

			var plotModel = new PlotModel { Title = "OxyPlot Demo" };

			plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
			plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = -10 });

			var series1 = new LineSeries
			{

				LineStyle = LineStyle.None,
				MarkerType = MarkerType.Circle,
				MarkerSize = 4,
				MarkerStroke = OxyColors.White
			};

			series1.Points.Add(new DataPoint(0.0, 6.0));
			series1.Points.Add(new DataPoint(1.4, 2.1));
			series1.Points.Add(new DataPoint(2.0, 4.2));
			series1.Points.Add(new DataPoint(3.3, 2.3));
			series1.Points.Add(new DataPoint(4.7, 7.4));
			series1.Points.Add(new DataPoint(6.0, 6.2));
			series1.Points.Add(new DataPoint(8.9, 8.9));

			plotModel.Series.Add(series1);

			series1.Points.Clear();



			int a = 10;
			int b = 5;
			float c = 0.1f;

			plotModel.Series.Add(new FunctionSeries(x => a * x * x + b * x + c, -10f, 10f, 0.1f, "anden græds funktion"));
			plotModel.Series.Add(new FunctionSeries(x => a * x + b, -10f, 10f, 0.1f, "lignær funktion"));



			return plotModel;
		}
		public PlotModel MyModel { get; private set; }*/
	}
}