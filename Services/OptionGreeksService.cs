using OptionGreeksCalculator.Models;
using OptionGreeksCalculator.Models.Interfaces;

namespace OptionGreeksCalculator.Services
{
	public static class OptionGreeksService
	{
		public static OptionGreeks CalculateOptionGreeks(IOption option)
		{
			return GreeksCalculatorService.CalculateGreeks(option);
		}

		public static void PrintOptionGreeks(IOptionGreeks greeksType)
		{
			GreeksConsolePrinterService.PrintGreeks(greeksType);
		}
	}
}