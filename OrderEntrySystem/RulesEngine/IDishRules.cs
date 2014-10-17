using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderEntrySystem
{
    public interface IDishRules
    {
        void InitializeRules();
        bool VerifyMultipleServing(int dishTypeId, int timeOfDayId, int itemId);
        bool VerifyDesertServing(int dishTypeId, int timeOfDayId);
        int[] ApplySortRule(int[] inputData);
        bool SetMultipleServingRule();
        bool SetDesertServingRule();
    }
}
