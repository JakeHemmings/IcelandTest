using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iceland.Models
{
    public class Inventory
    {
        public Inventory()
        {
        }

        public string ItemName { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}