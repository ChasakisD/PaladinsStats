using System.ComponentModel.DataAnnotations;
using PaladinsAPI.Models;

namespace PaladinsStats.Service.Models
{
    public class FriendEntity : Friend
    {
        [Key]
        public int DbId { get; set; }
    }
}