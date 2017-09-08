using System.ComponentModel.DataAnnotations;
using PaladinsAPI.Models;

namespace PaladinsStats.Service.Models
{
    public class PlayerEntity : Player
    {
        public PlayerEntity(Player player)
        {
            Created_Datetime = player.Created_Datetime;
            Id = player.Id;
            Last_Login_Datetime = player.Last_Login_Datetime;
            Leaves = player.Leaves;
            Level = player.Level;
            Losses = player.Losses;
            MasteryLevel = player.MasteryLevel;
            Name = player.Name;
            Personal_Status_Message = player.Personal_Status_Message;
            Region = player.Region;
            TeamId = player.TeamId;
            Team_Name = player.Team_Name;
            Total_Achievements = player.Total_Achievements;
            Total_Worshippers = player.Total_Worshippers;
            Wins = player.Wins;
            lastUpdated = player.lastUpdated;
            Champions_Last_Updated = player.Champions_Last_Updated;
            History_Last_Updated = player.History_Last_Updated;
        }

        public PlayerEntity() { }

        [Key]
        public int DbId { get; set; }
    }
}