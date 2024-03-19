using OptionGreeksCalculator.Models;
using OptionGreeksCalculator.Models.Interfaces;
using System.Text;
using static System.Console;

namespace OptionGreeksCalculator.Services
{
	public static class GreeksConsolePrinterService
	{
		public static void PrintGreeks(IOptionGreeks greeksType)
		{
			Write(CreateGreeksTableByType(greeksType.CallGreeks, OptionType.Call));
			WriteLine("\n" + new string('*', 23) + "\n");
			Write(CreateGreeksTableByType(greeksType.PutGreeks, OptionType.Put));
		}

		private static string CreateGreeksTableByType(IGreeks greeks, OptionType type)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{"Parameter",-10} | {"Value",10}");
			sb.AppendLine(new string('-', 23));
			sb.AppendLine($"{"Type",-10} | {type,10}");
			sb.AppendLine(new string('~', 23));
			sb.AppendLine($"{"Delta",-10} | {greeks.Delta,10:F5}");
			sb.AppendLine($"{"Gamma",-10} | {greeks.Gamma,10:F5}");
			sb.AppendLine($"{"Vega",-10} | {greeks.Vega,10:F5}");
			sb.AppendLine($"{"Theta",-10} | {greeks.Theta,10:F5}");

			return sb.ToString();
		}
	}
}