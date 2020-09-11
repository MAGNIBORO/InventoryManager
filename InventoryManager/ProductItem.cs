using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager
{
    public class ProductItem
    {
    private string name;
    private float price;
    private int quantity;

        public ProductItem()
        { 
        }
            public ProductItem(string name, float price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public void EditFields(string name, float price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public string GetName()
        {
            return this.name;
        }
        public float GetPrice()
        {
            return this.price;
        }
        public int GetQuantity()
        {
            return this.quantity;
        }
    }
}
