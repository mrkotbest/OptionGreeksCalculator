﻿using OptionGreeksCalculator.Models;
using System.Text;
using static System.Console;

namespace OptionGreeksCalculator.Services
{
	public class GreeksConsolePrinterService
	{
		public void PrintGreeks(GreeksType greeksType)
		{
			Write(CreateGreeksTableByType(greeksType.CallGreeks, "call"));
			WriteLine("\n" + new string('*', 23) + "\n");
			Write(CreateGreeksTableByType(greeksType.PutGreeks, "put"));
		}

		private string CreateGreeksTableByType(Greeks greeks, string type)
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