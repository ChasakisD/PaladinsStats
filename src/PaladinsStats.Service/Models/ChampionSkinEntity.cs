using System.ComponentModel.DataAnnotations;
using PaladinsAPI.Models;

namespace PaladinsStats.Service.Models
{
    public class ChampionSkinEntity : ChampionSkin
    {
        [Key] 
        public int DbId { get; set; }
    }
}