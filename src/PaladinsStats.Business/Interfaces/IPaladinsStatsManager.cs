using System.Collections.Generic;
using System.Threading.Tasks;
using PaladinsAPI.Models;
using PaladinsStats.Model.Models;
using PaladinsStats.Models;

namespace PaladinsStats.Business.Interfaces
{
    public interface IPaladinsStatsManager
    {
        #region Local Data Access

        IEnumerable<ChampionEntity> GetChampions();
        void LoadChampionSkins(ChampionEntity champion);
        IEnumerable<ItemEntity> GetItems();

        void InsertChampion(ChampionEntity champion);
        void InsertChampionSkin(ChampionSkinEntity championSkin, ChampionEntity champion);
        void InsertItem(ItemEntity item);

        void Update(object objectForUpdate);

        void DeleteChampion(ChampionEntity champion);
        void DeleteChampionSkin(ChampionSkinEntity championSkin, ChampionEntity parentChampion);
        void DeleteItem(ItemEntity item);

        #endregion

        #region Rest Service Data Access

        Task<double> RetrievePatchNumber();
        Task<Player> RetrievePlayerByNameFromRestServiceAsync(string name);
        Task<PlayerStatus> RetrievePlayerStatusFromRestServiceAsync(Player player);
        Task<IEnumerable<MatchHistory>> RetrievePlayerMatchHistoryFromRestServiceAsync(Player player);
        Task<IEnumerable<Friend>> RetrievePlayerFriendsFromRestServiceAsync(Player player);
        Task<IEnumerable<ChampionRank>> RetrievePlayerChampionRanksFromRestServiceAsync(Player player);
        Task<IEnumerable<PlayerAchievements>> RetrievePlayerAchievementsFromRestServiceAsync(Player player);
        Task<IEnumerable<PlayerLoadouts>> RetrievePlayerLoadoutsFromRestServiceAsync(Player player);
        Task<IEnumerable<MatchDetails>> RetrieveMatchFromRestServiceAsync(string matchid);

        Task<IEnumerable<ChampionEntity>> RetrieveChampionsFromRestServiceAsync();
        Task<IEnumerable<ItemEntity>> RetrieveItemsFromRestServiceAsync();

        #endregion
    }
}
