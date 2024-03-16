using MathNet.Numerics.Distributions;
using OptionGreeksCalculator.Models;
using System;

namespace OptionGreeksCalculator.Services
{
	public class GreeksCalculatorService
	{
        public GreeksType CalculateGreeks(Option option)
		{
			try
			{
				ValidateOption(option);

				double d1 = CalculateD1(option);
				double d2 = CalculateD2(option, d1);

				Greeks callGreeks = MoldGreeksByOptionType(option, d1, d2, "call");
				Greeks putGreeks = MoldGreeksByOptionType(option, d1, d2, "put");

				return new GreeksType(callGreeks, putGreeks);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}


		private void ValidateOption(Option option)
		{
			if (option.UnderlyingPrice <= 0 || option.StrikePrice <= 0 || option.TimeToExpiration <= 0 || option.Volatility <= 0)
				throw new ArgumentException("Invalid input parameters.");
		}

		private Greeks MoldGreeksByOptionType(Option option, double d1, double d2, string type)
		{
			return new Greeks(
				CalculateDelta(option, d1, type),
				CalculateGamma(option, d1),
				CalculateVega(option, d1),
				CalculateTheta(option, d1, d2, type));
		}

		private double CalculateD1(Option option)
		{
			// part1 и part2 это разделенная на части формула для расчета D1.
			double part1 = (Math.Log(option.UnderlyingPrice / option.StrikePrice) + (option.RiskFreeRate - option.DividendYield +
							Math.Pow(option.Volatility, 2) / 2) * option.TimeToExpiration);
			double part2 = option.Volatility * Math.Sqrt(option.TimeToExpiration);

			return part1 / part2;
		}

		private double CalculateD2(Option option, double d1)
		{
			return d1 - option.Volatility * Math.Sqrt(option.TimeToExpiration);
		}

		private double CalculateDelta(Option option, double d1, string type)
		{
			// sign определяют знак (минус или плюс) для частей формулы в зависимости от типа опциона (call или put).
			int sign = (type == "call") ? 1 : -1;
			return sign * (Math.Exp(-option.DividendYield * option.TimeToExpiration) * Normal.CDF(0, 1, sign * d1));
		}

		private double CalculateGamma(Option option, double d1)
		{
			return Math.Exp(-option.DividendYield * option.TimeToExpiration) * Normal.PDF(0, 1, d1) /
				(option.UnderlyingPrice * option.Volatility * Math.Sqrt(option.TimeToExpiration));
		}

		private double CalculateTheta(Option option, double d1, double d2, string type)
		{
			// sign1 и sign2 определяют знак (минус или плюс) для частей формулы в зависимости от типа опциона (call или put).
			int sign1 = (type == "call") ? -1 : 1;
			int sign2 = (type == "call") ? 1 : -1;

			// part1, part2, part3 это разделенные части формулы для расчета Theta.
			double part1 = -Math.Exp(-option.DividendYield * option.TimeToExpiration) * option.UnderlyingPrice * Normal.PDF(0, 1, sign2 * d1) *
								option.Volatility / (2.0 * Math.Sqrt(option.TimeToExpiration));
			double part2 = sign1 * (option.RiskFreeRate * option.StrikePrice *
								Math.Exp(-option.RiskFreeRate * option.TimeToExpiration) * Normal.CDF(0, 1, sign2 * d2));
			double part3 = sign1 * option.DividendYield * option.UnderlyingPrice *
								Math.Exp(-option.DividendYield * option.TimeToExpiration) * Normal.CDF(0, 1, sign2 * d1);

			return part1 + part2 - part3;
		}

		private double CalculateVega(Option option, double d1)
		{
			return Math.Exp(-option.DividendYield * option.TimeToExpiration) *
				option.UnderlyingPrice * Math.Sqrt(option.TimeToExpiration) * Normal.PDF(0, 1, d1);
		}
	}
}