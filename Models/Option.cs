namespace OptionGreeksCalculator.Models
{
	public class Option
	{
		public double UnderlyingPrice { get; private set; }
		public double StrikePrice { get; private set; }
		public double TimeToExpiration { get; private set; }
		public double RiskFreeRate { get; private set; }
		public double DividendYield { get; private set; }
		public double Volatility { get; private set; }

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