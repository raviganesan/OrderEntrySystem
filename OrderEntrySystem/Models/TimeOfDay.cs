using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderEntrySystem.Models
{

    public class TimeOfDayList
    {
        public TimeOfDayList()
        {
            List<TimeOfDay> timeOfDayList = new List<TimeOfDay>();
            timeOfDayList.Add(new TimeOfDay{ TimeOfDayId = 1, TimeOfDayName = "morning"});
            timeOfDayList.Add(new TimeOfDay{ TimeOfDayId = 2, TimeOfDayName="night"});
            this.timeOfDayList = timeOfDayList;
        }

        List<TimeOfDay> timeOfDayList = null;
        public List<TimeOfDay> GetTimeOfDayList
        {
            get { return timeOfDayList; }
            private set { timeOfDayList = this.timeOfDayList != null ? this.timeOfDayList : value; }
        }
              
    }

    public class TimeOfDay
    {
        public int TimeOfDayId { get; set; }
        public string TimeOfDayName { get; set; }
        
    }
}
