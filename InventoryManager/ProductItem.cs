using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager
{
    public class ProductItem
    {
        public string name { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }

        public ProductItem()
        { 
        }
        public ProductItem(string Name, float Price, int Quantity)
        {
            name = Name;
            price = Price;
            quantity = Quantity;
        }

        public void EditFields(string Name, float Price, int Quantity)
        {
            name = Name;
            price = Price;
            quantity = Quantity;
        }

        public string GetName()
        {
            return name;
        }
        public float GetPrice()
        {
            return price;
        }
        public int GetQuantity()
        {
            return quantity;
        }
    }
}
