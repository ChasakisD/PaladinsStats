using System.ComponentModel.DataAnnotations;
using PaladinsAPI.Models;

namespace PaladinsStats.Service.Models
{
    public class PlayerAchievementsEntity : PlayerAchievements
    {
        public PlayerAchievementsEntity(PlayerAchievements achievements)
        {
            AssistedKills = achievements.AssistedKills;
            CampsCleared = achievements.CampsCleared;
            DivineSpree = achievements.DivineSpree;
            DoubleKills = achievements.DoubleKills;
            FireGiantKills = achievements.FireGiantKills;
            FirstBloods = achievements.FirstBloods;
            GodLikeSpree = achievements.GodLikeSpree;
            GoldFuryKills = achievements.GoldFuryKills;
            Id = achievements.Id;
            ImmortalSpree = achievements.ImmortalSpree;
            KillingSpree = achievements.KillingSpree;
            MinionKills = achievements.MinionKills;
            Name = achievements.Name;
            PentaKills = achievements.PentaKills;
            PhoenixKills = achievements.PhoenixKills;
            PlayerKills = achievements.PlayerKills;
            QuadraKills = achievements.QuadraKills;
            RampageSpree = achievements.RampageSpree;
            ShutdownSpree = achievements.ShutdownSpree;
            SiegeJuggernautKills = achievements.SiegeJuggernautKills;
            TowerKills = achievements.TowerKills;
            TripleKills = achievements.TripleKills;
            UnstoppableSpree = achievements.UnstoppableSpree;
            WildJuggernautKills = achievements.WildJuggernautKills;
        }

        public PlayerAchievementsEntity() { }

        [Key]
        public int DbId { get; set; }
    }
}