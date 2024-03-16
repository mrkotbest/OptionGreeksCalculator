using OptionGreeksCalculator.Models;

namespace OptionGreeksCalculator.Services
{
	public class GreeksService
	{
		private readonly GreeksCalculatorService _calculator = new GreeksCalculatorService();
		private readonly GreeksConsolePrinterService _printer = new GreeksConsolePrinterService();

		public GreeksType CalculateOptionGreeks(Option option)
		{
			return _calculator.CalculateGreeks(option);
		}

		public void PrintOptionGreeks(GreeksType greeksType)
		{
			_printer.PrintGreeks(greeksType);
		}
	}
}