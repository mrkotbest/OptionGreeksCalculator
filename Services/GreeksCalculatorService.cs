using MathNet.Numerics.Distributions;
using OptionGreeksCalculator.Models;
using OptionGreeksCalculator.Models.Interfaces;
using System;
using static System.Math;

namespace OptionGreeksCalculator.Services
{
	public static class GreeksCalculatorService
	{
        public static OptionGreeks CalculateGreeks(IOption option)
		{
			try
			{
				ValidateOption(option);

				IGreeks callGreeks = GetCalculatedGreeksByOptionType(option, OptionType.Call);
				IGreeks putGreeks = GetCalculatedGreeksByOptionType(option, OptionType.Put);

				return new OptionGreeks(callGreeks, putGreeks);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		private static void ValidateOption(IOption option)
		{
			if (option == null)
				throw new ArgumentNullException(nameof(option), "Option cannot be null.");

			if (option.UnderlyingPrice <= 0 || option.StrikePrice <= 0 || option.TimeToExpiration <= 0 || option.Volatility <= 0)
				throw new ArgumentException("Invalid input parameters.");
		}

		private static IGreeks GetCalculatedGreeksByOptionType(IOption option, OptionType type)
		{
			// d1 и d2 это вспомогательные переменные для формул.
			double d1 = CalculateD1(option);
			double d2 = CalculateD2(option, d1);

			IGreeks calculatedGreeks = new Greeks(
				CalculateDelta(option, d1, type),
				CalculateGamma(option, d1),
				CalculateVega(option, d1),
				CalculateTheta(option, d1, d2, type));

			return calculatedGreeks;
		}

		private static double CalculateD1(IOption option)
		{
			// part1 и part2 это разделенная на части формула для расчета D1.
			double part1 = (Log(option.UnderlyingPrice / option.StrikePrice) + (option.RiskFreeRate - option.DividendYield +
							Pow(option.Volatility, 2) / 2) * option.TimeToExpiration);
			double part2 = option.Volatility * Sqrt(option.TimeToExpiration);

			return part1 / part2;
		}

		private static double CalculateD2(IOption option, double d1)
		{
			return d1 - option.Volatility * Sqrt(option.TimeToExpiration);
		}

		private static double CalculateDelta(IOption option, double d1, OptionType type)
		{
			// sign определяют знак (минус или плюс) для частей формулы в зависимости от типа опциона (call или put).
			int sign = (type == OptionType.Call) ? 1 : -1;
			return sign * (Exp(-option.DividendYield * option.TimeToExpiration) * Normal.CDF(0, 1, sign * d1));
		}

		private static double CalculateGamma(IOption option, double d1)
		{
			return Exp(-option.DividendYield * option.TimeToExpiration) * Normal.PDF(0, 1, d1) /
				(option.UnderlyingPrice * option.Volatility * Sqrt(option.TimeToExpiration));
		}

		private static double CalculateTheta(IOption option, double d1, double d2, OptionType type)
		{
			// sign1 и sign2 определяют знак (минус или плюс) для частей формулы в зависимости от типа опциона (call или put).
			int sign1 = (type == OptionType.Call) ? -1 : 1;
			int sign2 = (type == OptionType.Call) ? 1 : -1;

			// part1, part2, part3 это разделенные части формулы для расчета Theta.
			double part1 = -Exp(-option.DividendYield * option.TimeToExpiration) * option.UnderlyingPrice * Normal.PDF(0, 1, sign2 * d1) *
								option.Volatility / (2.0 * Sqrt(option.TimeToExpiration));
			double part2 = sign1 * (option.RiskFreeRate * option.StrikePrice *
								Exp(-option.RiskFreeRate * option.TimeToExpiration) * Normal.CDF(0, 1, sign2 * d2));
			double part3 = sign1 * option.DividendYield * option.UnderlyingPrice *
								Exp(-option.DividendYield * option.TimeToExpiration) * Normal.CDF(0, 1, sign2 * d1);

			return part1 + part2 - part3;
		}

		private static double CalculateVega(IOption option, double d1)
		{
			return Exp(-option.DividendYield * option.TimeToExpiration) *
				option.UnderlyingPrice * Sqrt(option.TimeToExpiration) * Normal.PDF(0, 1, d1);
		}
	}
}