using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeCalculator.ConsoleApp
{
    class ChangeCalculator : IChangeCalculator
    {
        private Dictionary<double, int> ChangeCollector { get; set; } = new Dictionary<double, int>();

        public Dictionary<double, int> GetChange()
        {
            return ChangeCollector;
        }

        public void CalculateChange(double amount, double productPrice)
        {
            if (amount < productPrice) throw new ArgumentException($"{nameof(amount)}: {amount} must be greater than {nameof(productPrice)}: {productPrice}");

            if (amount <=0) throw new ArgumentException($"{nameof(amount)} should be greater than 0 ");

            if (productPrice <= 0) throw new ArgumentException($"{nameof(productPrice)} should be greater than 0 ");

            if (amount == productPrice)
                return;

            ChangeCollector = new Dictionary<double, int>();
            var change = amount - productPrice;
                
            ComputeChange(change);
        }

        private void ComputeChange(double remainingChange)
        {
            if (remainingChange == 0)
                return;

            var denomination = Denominations.UkDenominations.FirstOrDefault(x => x <= remainingChange);

            var numberOfDenomination = Math.Truncate(remainingChange / denomination);

            ChangeCollector.Add(denomination, Convert.ToInt32(numberOfDenomination));

            remainingChange = Math.Round(remainingChange % denomination, 2);
            ComputeChange(remainingChange);
        }
    }
}
