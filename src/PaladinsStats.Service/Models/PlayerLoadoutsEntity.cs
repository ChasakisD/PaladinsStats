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
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public ICollection<LoadoutItemEntity> LoadoutItems { get; set; }

        public PlayerLoadoutsEntity() { }

        public PlayerLoadoutsEntity(PlayerLoadouts loadouts)
        {
            ChampionId = loadouts.ChampionId;
            ChampionName = loadouts.ChampionName;
            DeckId = loadouts.DeckId;
            DeckName = loadouts.DeckName;
            PlayerId = loadouts.playerId;
            PlayerName = loadouts.playerName;

            LoadoutItems = new List<LoadoutItemEntity>();
            foreach (var item in loadouts.LoadoutItems)
            {
                var entityItem = new LoadoutItemEntity(item)
                {
                    DeckId = DeckId
                };
                LoadoutItems.Add(entityItem);
            }
        }
    }
}