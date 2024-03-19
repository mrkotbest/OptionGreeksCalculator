namespace OptionGreeksCalculator.Models
{
	public interface IOption
	{
		double UnderlyingPrice { get; }
		double StrikePrice { get; }
		double TimeToExpiration { get; }
		double RiskFreeRate { get; }
		double DividendYield { get; }
		double Volatility { get; }
	}
}