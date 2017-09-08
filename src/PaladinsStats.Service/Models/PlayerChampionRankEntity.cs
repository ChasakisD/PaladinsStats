using System.ComponentModel.DataAnnotations;
using PaladinsAPI.Models;

namespace PaladinsStats.Service.Models
{
    public class PlayerChampionRankEntity : ChampionRank
    {
        public PlayerChampionRankEntity(ChampionRank rank)
        {
            Id = rank.Id;
            Assists = rank.Assists;
            Deaths = rank.Deaths;
            Kills = rank.Kills;
            Losses = rank.Losses;
            MinionKills = rank.MinionKills;
            Rank = rank.Rank;
            Wins = rank.Wins;
            Worshippers = rank.Worshippers;
            champion = rank.champion;
            champion_id = rank.champion_id;
            player_id = rank.player_id;
        }

        public PlayerChampionRankEntity() { }

        [Key]
        public int DbId { get; set; }
    }
}