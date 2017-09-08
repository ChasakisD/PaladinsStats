using System.ComponentModel.DataAnnotations;
using PaladinsAPI.Models;

namespace PaladinsStats.Service.Models
{
    public class PlayerStatusEntity : PlayerStatus
    {
        public PlayerStatusEntity(PlayerStatus playerStatus)
        {
            Match = playerStatus.Match;
            personal_status_message = playerStatus.personal_status_message;
            status = playerStatus.status;
            status_string = playerStatus.status_string;
            playerId = playerStatus.playerId;
        }

        public PlayerStatusEntity() { }

        [Key]
        public int DbId { get; set; }
    }
}