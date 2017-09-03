using System.Collections.Generic;
using System.Threading.Tasks;
using PaladinsAPI.Models;

namespace PaladinsStats.Business.Interfaces
{
    public interface IPaladinsStatsRestService
    {
        Task<Player> GetPlayerByNameAsync(string name);
        Task<PlayerStatus> GetPlayerStatusAsync(Player player);
        Task<IEnumerable<MatchHistory>> GetPlayerMatchHistoryAsync(Player player);
        Task<IEnumerable<Friend>> GetPlayerFriendsAsync(Player player);
        Task<IEnumerable<ChampionRank>> GetPlayerChampionRanksAsync(Player player);
        Task<IEnumerable<PlayerAchievements>> GetPlayerAchievementsAsync(Player player);
        Task<IEnumerable<PlayerLoadouts>> GetPlayerLoadoutsAsync(Player player);
        Task<IEnumerable<MatchDetails>> GetMatchAsync(string matchid);


        Task<IEnumerable<Champion>> RetrieveChampionsAsync();
        Task<IEnumerable<ChampionSkin>> RetrieveChampionSkinsAsync();
        Task<IEnumerable<Item>> RetrieveItemsAsync();
        
    }
}
