namespace OptionGreeksCalculator.Models.Interfaces
{
	public interface IOptionGreeks
	{
		IGreeks CallGreeks { get; }
		IGreeks PutGreeks { get; }
	}
}