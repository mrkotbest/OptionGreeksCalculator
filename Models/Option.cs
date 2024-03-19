namespace OptionGreeksCalculator.Models
{
	public class Option : IOption
	{
		public double UnderlyingPrice { get; }
		public double StrikePrice { get; }
		public double TimeToExpiration { get; }
		public double RiskFreeRate { get; }
		public double DividendYield { get; }
		public double Volatility { get; }

		public Option(double underlyingPrice, double strikePrice, double timeToExpiration,
			double riskFreeRate, double dividendYield, double volatility)
		{
			UnderlyingPrice = underlyingPrice;
			StrikePrice = strikePrice;
			TimeToExpiration = timeToExpiration;
			RiskFreeRate = riskFreeRate;
			DividendYield = dividendYield;
			Volatility = volatility;
		}
	}
}