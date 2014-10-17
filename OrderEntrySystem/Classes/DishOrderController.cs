using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderEntrySystem.Models;
namespace OrderEntrySystem.Classes
{
    class DishOrderController
    {
        public DishOrderController(IDishRules dishRules)
        {
            _dishRules = dishRules;
            _dishRules.InitializeRules();
        }

        private IDishRules _dishRules;

        public List<TimeOfDay> TimeOfDayList()
        {
            TimeOfDayList timeOfDayList = new TimeOfDayList();

            return timeOfDayList.GetTimeOfDayList;
        }

        public List<DishItem> Dishes()
        {
            DishList dishList = new DishList();
            return dishList.DishItemList;
        }

        public List<DishType> DishTypeList()
        {
            DishTypeList dishTypeList = new DishTypeList();

            return dishTypeList.GetDishTypes;
        }

        public bool VerifyDesertServingForTimeOfDay(int dishTypeId, int timeOfDayId)
        {
            return _dishRules.VerifyDesertServing(dishTypeId, timeOfDayId);

        }

        public bool VerifyMultipleServingForTimeOfDay(int dishTypeId, int timeOfDayId, int itemId)
        {
            return _dishRules.VerifyMultipleServing(dishTypeId, timeOfDayId, itemId);
        }

    }
}
