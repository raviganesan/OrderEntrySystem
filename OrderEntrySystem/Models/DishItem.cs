using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderEntrySystem.Models
{
    public class DishItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int TimeOfDayId { get; set; }
        public int DishTypeId { get; set; }
    }

    public class DishList
    {
        public DishList()
        {
            List<DishItem> dishItemList = new List<DishItem>();

            DishItem item1 = new DishItem { ItemId = 1, ItemName = "eggs", TimeOfDayId = 1, DishTypeId = 1 };
            DishItem item2 = new DishItem { ItemId = 2, ItemName = "steak", TimeOfDayId = 2, DishTypeId = 1 };
            DishItem item3 = new DishItem { ItemId = 3, ItemName = "toast", TimeOfDayId = 1, DishTypeId = 2 };
            DishItem item4 = new DishItem { ItemId = 4, ItemName = "potato", TimeOfDayId = 2, DishTypeId = 2 };
            DishItem item5 = new DishItem { ItemId = 5, ItemName = "coffee", TimeOfDayId = 1, DishTypeId = 3 };
            DishItem item6 = new DishItem { ItemId = 6, ItemName = "wine", TimeOfDayId = 2, DishTypeId = 3 };
            DishItem item7 = new DishItem { ItemId = 7, ItemName = "cake", TimeOfDayId = 2, DishTypeId = 4 };

            dishItemList.Add(item1);
            dishItemList.Add(item2);
            dishItemList.Add(item3);
            dishItemList.Add(item4);
            dishItemList.Add(item5);
            dishItemList.Add(item6);
            dishItemList.Add(item7);

            this.dishItemList = dishItemList;
        }


        List<DishItem> dishItemList = null;
        public List<DishItem> DishItemList
        {
            get { return dishItemList; }
            private set { dishItemList = this.dishItemList != null ? this.dishItemList : value; }
        }

    }
}
