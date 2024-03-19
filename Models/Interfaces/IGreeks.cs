namespace OptionGreeksCalculator.Models.Interfaces
{
	public interface IGreeks
	{
		double Delta { get; }
		double Gamma { get; }
		double Vega { get; }
		double Theta { get; }
	}
}