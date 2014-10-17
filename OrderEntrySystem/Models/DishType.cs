using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderEntrySystem.Models
{

    public class DishTypeList
    {
        public DishTypeList()
        {
            List<DishType> dishTypeList= new List<DishType>();
            dishTypeList.Add(new DishType { DishTypeId = 1, DishTypeName = "entree" });
            dishTypeList.Add(new DishType { DishTypeId = 2, DishTypeName = "side" });
            dishTypeList.Add(new DishType { DishTypeId = 3, DishTypeName = "drink" });
            dishTypeList.Add(new DishType { DishTypeId = 4, DishTypeName = "dessert" });
            this.dishTypeList = dishTypeList;
        }

        List<DishType> dishTypeList = null;

        public List<DishType> GetDishTypes
        {
            get { return dishTypeList; }
            set { dishTypeList = value; }
        }
    }

    public class DishType
    {
        public int DishTypeId { get; set; }
        public string DishTypeName { get; set;}
    }
}
