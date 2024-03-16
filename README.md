# Option Greeks Calculator

Option Greeks Calculator - это консольное приложение на языке C# (.NET Framework), предназначенный для расчета значений грек (дельта, гамма, вега, тета) по заданным данным опциона.

## Использование
Создайте экземпляр объекта Option с необходимыми данными опциона в качестве параметров, например:
```csharp
Option option = new Option(
	underlyingPrice: 100,       // цена базового актива
	strikePrice: 110,           // цена страйка
	timeToExpiration: 0.5,      // время до истечения (в годах)
	riskFreeRate: 0.05,         // безрисковая ставка
	dividendYield: 0.2,         // дивидендная доходность
	volatility: 0.2             // волатильность
	);
```
Затем создайте экземпляр класса GreeksService.
```csharp
GreeksService service = new GreeksService();
```
После вызовите методы для расчета грек и вывода данных на консоль:
```csharp
GreeksType greeks = service.CalculateOptionGreeks(option);
service.PrintOptionGreeks(greeks);
```

## Библиотеки
Помимо стандартной библиотеки Math, в проекте используется библиотека [MathNet.Numerics](https://github.com/mathnet/mathnet-numerics).
