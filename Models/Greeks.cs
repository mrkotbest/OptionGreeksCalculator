using OptionGreeksCalculator.Models.Interfaces;

namespace OptionGreeksCalculator.Models
{
	public class Greeks : IGreeks
	{
		public double Delta { get; }
		public double Gamma { get; }
		public double Vega { get; }
		public double Theta { get; }

		public Greeks(double delta, double gamma, double vega, double theta)
		{
			Delta = delta;
			Gamma = gamma;
			Vega = vega;
			Theta = theta;
		}
	}
}