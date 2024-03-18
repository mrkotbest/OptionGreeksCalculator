namespace OptionGreeksCalculator.Models
{
	public class OptionGreeks
	{
		public Greeks CallGreeks { get; private set; }
		public Greeks PutGreeks { get; private set; }

		public OptionGreeks(Greeks call, Greeks put)
		{
			CallGreeks = call;
			PutGreeks = put;
		}
	}
}