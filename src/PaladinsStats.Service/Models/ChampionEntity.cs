using System.ComponentModel.DataAnnotations;
using PaladinsAPI.Models;

namespace PaladinsStats.Service.Models
{
    public class ChampionEntity : Champion
    {
        [Key]
        public int DbId { get; set; }
    }
}