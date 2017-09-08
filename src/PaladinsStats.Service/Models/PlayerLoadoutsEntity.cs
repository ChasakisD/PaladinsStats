using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using PaladinsAPI.Models;

namespace PaladinsStats.Service.Models
{
    public class PlayerLoadoutsEntity
    {
        [Key]
        public int DbId { get; set; }
        public int ChampionId { get; set; }
        public string ChampionName { get; set; }
        public int DeckId { get; set; }
        public string DeckName { get; set; }
        [JsonProperty("playerId")]
        public int PlayerId { get; set; }
        [JsonProperty("playerName")]
        public string PlayerName { get; set; }

        public ICollection<LoadoutItemEntity> LoadoutItems { get; set; }
    }
}