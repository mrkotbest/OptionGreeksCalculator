using OptionGreeksCalculator.Models.Interfaces;

namespace OptionGreeksCalculator.Models
{
	public class OptionGreeks : IOptionGreeks
	{
		public IGreeks CallGreeks { get; }
		public IGreeks PutGreeks { get; }

		public OptionGreeks(IGreeks call, IGreeks put)
		{
			CallGreeks = call;
			PutGreeks = put;
		}
	}
}