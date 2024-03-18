using OptionGreeksCalculator.Models;

namespace OptionGreeksCalculator.Services
{
	public static class OptionGreeksService
	{
		public static OptionGreeks CalculateOptionGreeks(Option option)
		{
			return GreeksCalculatorService.CalculateGreeks(option);
		}

		public static void PrintOptionGreeks(OptionGreeks greeksType)
		{
			GreeksConsolePrinterService.PrintGreeks(greeksType);
		}
	}
}