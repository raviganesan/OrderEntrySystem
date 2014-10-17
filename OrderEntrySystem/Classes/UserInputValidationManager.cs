using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntrySystem.Classes
{
    public class UserInputValidationManager : IUserInputValidationManager
    {

        public bool ValidateTimeOfDay(string inputFeed)
        {

            string[] inputArray = inputFeed.Trim().Split(',');
            string timeOfDay = inputArray[0].Trim();

            if (((timeOfDay.Contains("morning") && string.Compare(timeOfDay, "morning", true) == 0)) ||
                ((timeOfDay.Contains("night") && string.Compare(timeOfDay, "night", true) == 0)))
            {
                return true;
            }
            else
            {
                    throw new ArgumentException("\n*** Enter valid time of day :(morning or night)!");
            }

        }

        public bool ValidateDishSelection(string inputFeed)
        {
            if (inputFeed.Contains(',')) //more regular expression can be added
            {
                return true;
            }
            else
            {
                throw new ArgumentException("\n*** You must enter a comma between dish types with at least one selection!");
            }
        }
    }

    public interface IUserInputValidationManager
    {
        bool ValidateTimeOfDay(string inputFeed);
        bool ValidateDishSelection(string inputFeed);
    }
}
