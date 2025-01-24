using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission_3_food_bank
{
    internal class FoodItem
    {
        public string Name { get; }
        public string Category { get; }
        public int Quantity { get; }
        public DateTime ExpirationDate { get; }


        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            Name = name;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            return ($"{Name}, {Category}, {Quantity}, Expires: {ExpirationDate}");
        }
    }
}
    