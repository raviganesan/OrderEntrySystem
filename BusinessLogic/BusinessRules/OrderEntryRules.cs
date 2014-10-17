using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntrySystem.BusinessLogic.BusinessRules
{
    public class  OrderEntryRules : IOrderEntryRules 
    {
        //let it to survive until Garbage Collection 2
        static Dictionary<int, int> desertRulesList = new Dictionary<int, int>(); //dishTypeId,timeOfDayId : it contains rules of items which is not allowed
        static List<MultipleEntryRules> multipleEntryRulesList = new List<MultipleEntryRules>();

        public bool SetDesertRules() ////the dishtypeid and time of day off id to set rules are predetermined, for dynamic setting it can be passed here as params
        {
            try
            {
                //These business settings private and not known to clients
                desertRulesList.Add(4, 1); //dishTypeId 4: refers dessert; timeofdayId 1: refers morning. To Do: the numbers can be made into Enums for easy reading
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: Unable to set Desert Rules!\n {0}", ex.Message);
                return false;
            }

        }

        public bool SetMultipleServingRules()//int dishTypeID, int timeOfDayId, int itemId)
        {
             try
            {
            //These business settings private and not known to clients
            multipleEntryRulesList.Add(new MultipleEntryRules { DishTypeId = 3, timeOfDayId = 1, itemId = 5 }); //dishTypeId 3 = drink, timeofdayid 1 = morning, itemid 5 = coffee
            multipleEntryRulesList.Add(new MultipleEntryRules { DishTypeId = 2, timeOfDayId = 2, itemId = 4 }); //dishTypeId 2 = side, timeofdayid 2 = night, itemid 4 = potato
            return true;
            }
             catch (Exception ex)
             {
                 Console.WriteLine("Error: Unable to set Multiple Order Entry Rules!\n {0}", ex.Message);
                 return false;
             }
        }

        public bool VerifyDesertServing(int dishTypeId, int timeOfDayId)
        { 
            int getValue = 0;
            bool isDesertAllowed;
            desertRulesList.TryGetValue(dishTypeId, out getValue); //if the values are found in the list, its not allowed

            return isDesertAllowed = ((timeOfDayId == getValue) && (timeOfDayId != 2)) ? false : true; //timeOfDayId 2: night

        }

        public bool VerifyMultipleServing(int dishTypeId, int timeOfDayId, int itemId)
        {
            bool isMultiplesAllowed;
            //if the values are found in the list, its allowed
            var result = (from rule in multipleEntryRulesList
                          where rule.DishTypeId == dishTypeId && rule.timeOfDayId == timeOfDayId && rule.itemId == itemId
                          select rule).SingleOrDefault();

            return isMultiplesAllowed = (result != null) ? true : false;
        }

    }

    class MultipleEntryRules
    {
        public int DishTypeId { get; set;}
        public int timeOfDayId {get; set;}
        public int itemId {get; set;}

    }

    public interface IOrderEntryRules
    {
         bool VerifyMultipleServing(int dishTypeId, int timeOfDayId, int itemId);
         bool VerifyDesertServing(int dishTypeId, int timeOfDayId);
         bool SetMultipleServingRules();
         bool SetDesertRules();
    }
}
