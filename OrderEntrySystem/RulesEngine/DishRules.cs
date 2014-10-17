using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OrderEntrySystem.BusinessLogic.BusinessRules;

namespace OrderEntrySystem
{
    public class DishRules : IDishRules
    {
        public DishRules(IOrderEntryRules iOrderEntryRules)
        {
            _iOrderEntryRules = iOrderEntryRules;
        }

        IOrderEntryRules _iOrderEntryRules;

        public void InitializeRules()
        {
            if (SetDesertServingRule())
            {
                Console.WriteLine("Desert Rules Initialized...");
            }

            if (SetMultipleServingRule())
            {
                Console.WriteLine("Mutiple Order Entry Rules Initialized...");
            }
        }

        public bool VerifyDesertServing(int dishTypeId, int timeOfDayId)
        {
            return _iOrderEntryRules.VerifyDesertServing(dishTypeId, timeOfDayId);
        }

        public bool VerifyMultipleServing(int dishTypeId, int timeOfDayId, int itemId)
        {
            return _iOrderEntryRules.VerifyMultipleServing(dishTypeId, timeOfDayId, itemId);
        }

        public int[] ApplySortRule(int[] inputData)
        {
           Array.Sort(inputData);
           return inputData;
        }

        public bool SetMultipleServingRule()
        {
            return _iOrderEntryRules.SetMultipleServingRules();
        }

        public bool SetDesertServingRule() //whatever the item can be, simply dessert not served in morning
        {
            return _iOrderEntryRules.SetDesertRules();          

        }


    }
}
