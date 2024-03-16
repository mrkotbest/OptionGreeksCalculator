namespace OptionGreeksCalculator.Models
{
	public class Greeks
	{
		public double Delta { get; private set; }
		public double Gamma { get; private set; }
		public double Vega { get; private set; }
		public double Theta { get; private set; }

		public Greeks(double delta, double gamma, double vega, double theta)
		{
			Delta = delta;
			Gamma = gamma;
			Vega = vega;
			Theta = theta;
		}
	}
}