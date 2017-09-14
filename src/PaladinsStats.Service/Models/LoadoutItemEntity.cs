using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PaladinsAPI.Models;

namespace PaladinsStats.Service.Models
{
    public class LoadoutItemEntity
    {
        [Key]
        public int DbId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Points { get; set; }
        public int DeckId { get;set; }

        public LoadoutItemEntity() { }

        public LoadoutItemEntity(LoadoutItem item)
        {
            ItemId = item.ItemId;
            ItemName = item.ItemName;
            Points = item.Points;
        }
    }
}