using OptionGreeksCalculator.Models;
using OptionGreeksCalculator.Services;
using System;

namespace OptionGreeksCalculator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Option option = new Option(
				underlyingPrice: 100,
				strikePrice: 110,
				timeToExpiration: 0.5,
				riskFreeRate: 0.05,
				dividendYield: 0.2,
				volatility: 0.2
				);

			GreeksService service = new GreeksService();
			GreeksType greeks = service.CalculateOptionGreeks(option);
			service.PrintOptionGreeks(greeks);

			Console.ReadLine();
		}
	}
}