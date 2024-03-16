namespace OptionGreeksCalculator.Models
{
	public class GreeksType
	{
		public Greeks CallGreeks { get; private set; }
		public Greeks PutGreeks { get; private set; }

		public GreeksType(Greeks call, Greeks put)
		{
			CallGreeks = call;
			PutGreeks = put;
		}
	}
}