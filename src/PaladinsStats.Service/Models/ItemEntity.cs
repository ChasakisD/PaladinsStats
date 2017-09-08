using System.ComponentModel.DataAnnotations;
using PaladinsAPI.Models;

namespace PaladinsStats.Service.Models
{
    public class ItemEntity : Item
    {
        [Key]
        public int DbId { get; set; }
    }
}