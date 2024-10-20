namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            CurrencyConverter converter = new CurrencyConverter(41.23m, 44.79m); // ініціалізація об'єкту класу CurrencyConverter з курсами валют

            Console.WriteLine("оберіть валюту, ЯКУ ви бажаєте конвертувати: ");
            Console.WriteLine("1 - гривня");
            Console.WriteLine("2 - євро");
            Console.WriteLine("3 - долар");

            int currencyFrom;
            int.TryParse(Console.ReadLine(), out currencyFrom); // перевірка чи правильно ввели дані 

            if (currencyFrom == 0 || currencyFrom > 3)
            {
                Console.WriteLine("немає такої опції, або ви ввели хибні дані!");
                return;
            }

            Console.WriteLine("оберіть валюту, В ЯКУ ви бажаєте конвертувати: ");
            Console.WriteLine("1 - гривня");
            Console.WriteLine("2 - євро");
            Console.WriteLine("3 - долар");

            int currencyTo;
            int.TryParse(Console.ReadLine(), out currencyTo); // перевірка чи правильно ввели дані 

            if (currencyTo == 0 || currencyTo > 3)
            {
                Console.WriteLine("немає такої опції, або ви ввели хибні дані!");
                return;
            }

            Console.WriteLine("введіть невід'ємну суму коштів, яку ви хочете конвертувати:");
            decimal money;
            if (decimal.TryParse(Console.ReadLine(), out money) == false) // перевірка на валідність даних
            {
                Console.WriteLine("ви ввели не число!");
                return;
            }
            else if (money < 0) // перевірка на невід'ємність введеної суми коштів
            {
                Console.WriteLine("ви ввели від'ємну суму коштів!");
                return;
            }
            else
            {
                switch (currencyTo)
                {
                    case 1: // конвертація в гривню
                        if (currencyFrom == currencyTo)
                            Console.WriteLine($"результат - {money}₴");
                        else if (currencyFrom == 2)
                            Console.WriteLine($"результат - {String.Format("{0:0.00}", converter.ConvertEurToUah(money))}₴");
                        else
                            Console.WriteLine($"результат - {String.Format("{0:0.00}", converter.ConvertUsdToUah(money))}₴");
                        break;
                    case 2: // конвертація в євро
                        if (currencyFrom == currencyTo)
                            Console.WriteLine($"результат - {money}€");
                        else if (currencyFrom == 1)
                            Console.WriteLine($"результат - {String.Format("{0:0.00}", converter.ConvertUahToEur(money))}€");
                        else
                            Console.WriteLine($"результат - {String.Format("{0:0.00}", converter.ConvertUsdToEur(money))}€");
                        break;
                    case 3: // конвертація в долар
                        if (currencyFrom == currencyTo)
                            Console.WriteLine($"результат - {money}$");
                        else if (currencyFrom == 1)
                            Console.WriteLine($"результат - {String.Format("{0:0.00}", converter.ConvertUahToUsd(money))}$");
                        else
                            Console.WriteLine($"результат - {String.Format("{0:0.00}", converter.ConvertEurToUsd(money))}$");
                        break;
                }
            }
        }
    }
}
