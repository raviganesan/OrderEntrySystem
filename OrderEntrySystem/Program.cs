using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrderEntrySystem.Classes;
using OrderEntrySystem.Models;
using OrderEntrySystem.BusinessLogic.BusinessRules;

namespace OrderEntrySystem
{
     enum DishTypeIds
    {
        Entree = 1,
        Side = 2,
        Drink = 3,
        Dessert = 4
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IOrderEntryRules iOrderEntryRules = new OrderEntryRules();
                IDishRules dishRules = new DishRules(iOrderEntryRules);
                DishOrderController dishOrderController = new DishOrderController(dishRules);
                UserInputValidationManager userInputValidationManager = new UserInputValidationManager();
                do
                {
                    try
                    {
                        Console.Write("\n\nInput:");
                        string inputFeed = Console.ReadLine();

                        List<DishType> dishTypeList = dishOrderController.DishTypeList();

                        //parser 
                        string[] inputArray = inputFeed.Trim().Split(',');

                        //validation 1 : verify, if the time of day is the accepted field
                        string timeOfDay = string.Empty;
                        if (userInputValidationManager.ValidateTimeOfDay(inputFeed))
                        {
                            timeOfDay = inputArray[0].Trim();
                        }

                        //validate dish selection
                        bool isValidDish = userInputValidationManager.ValidateDishSelection(inputFeed);


                        Console.Write("\nOutput: ");

                        //skips the first index and converts the str array to int array for easy sorting
                        int[] sortDishTypeIds = inputArray.Skip(1).Select(n => Convert.ToInt32(n)).ToArray();
                        sortDishTypeIds = dishRules.ApplySortRule(sortDishTypeIds);

                        var queryTODId = (from tod in dishOrderController.TimeOfDayList()
                                          where tod.TimeOfDayName == timeOfDay
                                          select tod.TimeOfDayId).SingleOrDefault();

                        var queryDishTypIdsForMultiples = (from dtId in sortDishTypeIds
                                                          group dtId by dtId into dupList
                                                          let count = dupList.Count()
                                                          select new { dishTypeId = dupList.Key, Count = count }).ToList();

                        var dishList = dishOrderController.Dishes();

                        var lastItem = queryDishTypIdsForMultiples.Last();
                        foreach (var dishTypeItem in queryDishTypIdsForMultiples)
                        {
                            DishItem dishItem = GetDishItemName(dishTypeItem.dishTypeId, queryTODId, ref dishList);
                            bool isAlreadyPrinted = false;
                          
                                   //Validation for multiple entry
                                   if (dishTypeItem.Count > 1)
                                   {
                                       bool isMultipleServed = dishOrderController.VerifyMultipleServingForTimeOfDay(dishTypeItem.dishTypeId, queryTODId, dishItem.ItemId);

                                       if (isMultipleServed)
                                       {
                                           PrintDishItem(dishItem.ItemName + "(x" + dishTypeItem.Count + ')');
                                           isAlreadyPrinted = true;
                                       }
                                       else
                                       {
                                           PrintDishItem(dishItem.ItemName + ",");
                                           throw new Exception(" error");
                                       }
                                   }

                                   //validation for desserts
                                   if (dishTypeItem.dishTypeId == (int)DishTypeIds.Dessert)
                                   {
                                       bool isDessertServed = dishOrderController.VerifyDesertServingForTimeOfDay(dishTypeItem.dishTypeId, queryTODId);

                                       if (!isDessertServed)
                                       {
                                           throw new Exception(" error");
                                       }
                                       else
                                       {
                                           PrintDishItem(dishItem.ItemName);
                                       }

                                       isAlreadyPrinted = true;
                                   }

                                  //validation for invalid selection of dishtypes
                                   bool isValidDishTypeId = dishTypeList.Find(o => o.DishTypeId == dishTypeItem.dishTypeId) != null ? true : false;
                                    
                                   if (!isAlreadyPrinted && isValidDishTypeId)
                                   {
                                       PrintDishItem(dishItem.ItemName);
                                   }
                                   else if(!isAlreadyPrinted)
                                   {
                                       PrintDishItem("error");
                                   }

                            if (!dishTypeItem.dishTypeId.Equals(lastItem.dishTypeId)) Console.Write(", ");

                        }

                        Console.WriteLine("\n");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                } while (true); //(Console.ReadKey(true).Key != ConsoleKey.Escape)); // 

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

     
        private static void PrintDishItem(string dishItemName)
        {

            Console.Write("{0}", dishItemName);
        }

        private static DishItem GetDishItemName(int dishTypeId, int timeOfDayId, ref List<DishItem> dishList)
        {
            var getDishItem = (from di in dishList
                               where di.TimeOfDayId == timeOfDayId && di.DishTypeId == dishTypeId
                               select di).SingleOrDefault();
            return getDishItem;
        }

    }

}
