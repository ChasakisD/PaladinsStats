using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PaladinsAPI.Models;

namespace PaladinsStats.Service.Models
{
    public class LoadoutItemEntity : LoadoutItem
    {
       [Key]
        public int DbId { get; set; }
    }
}