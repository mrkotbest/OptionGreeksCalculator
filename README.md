# Option Greeks Calculator

Option Greeks Calculator - это консольное приложение на языке C# (.NET Framework 4.8.1), предназначенное для расчета грек (дельта, гамма, вега, тета) на основе заданных данных опциона.

## Использование
Создайте экземпляр объекта Option с необходимыми данными опциона в качестве параметров, например:
```csharp
IOption option = new Option(
	underlyingPrice: 100,       // цена базового актива
	strikePrice: 110,           // цена страйка
	timeToExpiration: 0.5,      // время до истечения (в годах)
	riskFreeRate: 0.05,         // безрисковая ставка
	dividendYield: 0.2,         // дивидендная доходность
	volatility: 0.2             // волатильность
	);
```
Далее вызовите статистический метод CalculateOptionGreeks класса OptionGreeksService, который возвращает рассчитанные греки.
```csharp
IOptionGreeks greeks = OptionGreeksService.CalculateOptionGreeks(option);
```
Затем вызовите статистический метод PrintOptionGreeks класса OptionGreeksService для вывода значений грек на консоль:
```csharp
OptionGreeksService.PrintOptionGreeks(greeks);
```

## Библиотеки
Помимо стандартной библиотеки System.Math, в проекте используется библиотека [MathNet.Numerics](https://github.com/mathnet/mathnet-numerics).
