using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class CurrencyConverter
    {
        public decimal UsdToUahRate { get; private set; }
        public decimal EurToUahRate { get; private set; }

        // конструктор для ініціалізації курсів валют
        public CurrencyConverter(decimal usdToUah, decimal eurToUah)
        {
            UsdToUahRate = usdToUah;
            EurToUahRate = eurToUah;
        }

        // грн в долар
        public decimal ConvertUahToUsd(decimal amountInUah)
        {
            return amountInUah / UsdToUahRate;
        }

        // долар в грн
        public decimal ConvertUsdToUah(decimal amountInUsd)
        {
            return amountInUsd * UsdToUahRate;
        }

        // грн в євро
        public decimal ConvertUahToEur(decimal amountInUah)
        {
            return amountInUah / EurToUahRate;
        }

        // євро в грн
        public decimal ConvertEurToUah(decimal amountInEur)
        {
            return amountInEur * EurToUahRate;
        }

        // євро в долар
        public decimal ConvertEurToUsd(decimal amountInEur)
        {
            return ConvertUahToUsd(ConvertEurToUah(amountInEur));
        }

        // долар в євро
        public decimal ConvertUsdToEur(decimal amountInUsd)
        {
            return ConvertUahToEur(ConvertUsdToUah(amountInUsd));
        }
    }

}
