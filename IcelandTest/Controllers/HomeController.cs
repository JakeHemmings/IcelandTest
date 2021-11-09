using System;
using System.Linq;
using System.Web.Mvc;
using Iceland.Models;

namespace Iceland.Controllers
{
    public class HomeController : Controller
    {
        public Inventory inventory = new Inventory();

        public bool IsChristmasDay()
        {
            DateTime christmasDay = new DateTime(2021, 12, 25);
            DateTime today = DateTime.Today;
            if (today != christmasDay)
                return false;
            else
                return true;
        }

        public ActionResult Index()
        {
            Items model = new Items();
            return View(model);
        }

        public ActionResult UpdatedInventory(Items itemList)
        {
            int count = itemList.InventoryItems.Count();
            Items CalculatedInventory = new Items();
            string item_name;
            int
                sell_in,
                quality;
            bool sell_by_reached = false;

            for (int i = 0; i < count; i++)
            {
                item_name = itemList.InventoryItems[i].ItemName;
                if (item_name != "Soap")
                    sell_in = itemList.InventoryItems[i].SellIn - 1;
                else
                    sell_in = itemList.InventoryItems[i].SellIn;
                quality = itemList.InventoryItems[i].Quality;

                if (sell_in <= 0)
                {
                    sell_by_reached = true;
                }

                if (!sell_by_reached)
                {
                    switch (item_name)
                    {
                        case "Aged Brie":
                            quality =
                                CalculateBrieAndCrackers(sell_in, quality);
                            break;
                        case "Christmas Crackers":
                            quality =
                                CalculateBrieAndCrackers(sell_in, quality);
                            break;
                        case "Fresh Item":
                            quality -= 2;
                            break;
                        case "Frozen Item":
                            quality -= 1;
                            break;
                    }
                }
                else
                {
                    switch (item_name)
                    {
                        case "Aged Brie":
                            quality =
                                CalculateBrieAndCrackers(sell_in, quality);
                            break;
                        case "Christmas Crackers":
                            quality =
                                CalculateBrieAndCrackers(sell_in, quality);
                            break;
                        case "Fresh Item":
                            quality -= 4;
                            break;
                        case "Frozen Item":
                            quality -= 2;
                            break;
                    }
                }

                CalculatedInventory.InventoryItems[i].ItemName = item_name;
                CalculatedInventory.InventoryItems[i].SellIn = sell_in;
                CalculatedInventory.InventoryItems[i].Quality = quality;
            }
            ViewBag.TimeNow = DateTime.Now;
            return View(CalculatedInventory);
        }

        public int CalculateBrieAndCrackers(int sellby, int quality)
        {
            int Quality = 0;
            if (!IsChristmasDay())
            {
                if (sellby > 5 && sellby <= 10)
                    Quality = quality + 2;
                else if (sellby >= 0 && sellby <= 5) Quality = quality + 3;
            }
            return Quality;
        }
    }
}
