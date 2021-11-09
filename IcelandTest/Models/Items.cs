using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iceland.Models
{
    public class Items
    {
        public Items()
        {
            InventoryItems = new List<Inventory>()
            {
                new Inventory { ItemName = "Aged Brie", SellIn = 0, Quality = 0 },
                new Inventory { ItemName="Christmas Crackers", SellIn = 0, Quality = 0 },
                new Inventory { ItemName = "Fresh Item", SellIn = 0, Quality = 0 },
                new Inventory { ItemName = "Frozen Item", SellIn = 0, Quality = 0 },
                new Inventory { ItemName = "Soap", SellIn = 0, Quality = 0 }
            };
        }

        public List<Inventory> InventoryItems { get; set; }
    }
}