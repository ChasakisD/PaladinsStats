using System.Collections.Generic;
using System.Threading.Tasks;
using PaladinsAPI.Models;
using PaladinsStats.Model.Models;

namespace PaladinsStats.Business.Interfaces
{
    public interface IPaladinsStatsManager
    {
        #region Local Data Access

        IEnumerable<PaladinsChampion> GetChampions();
        void LoadChampionSkins(PaladinsChampion paladinsChampion);
        IEnumerable<PaladinsItem> GetItems();
        UserSettings GetUserSettings();

        void InsertChampion(PaladinsChampion paladinsChampion);
        void InsertChampionSkin(PaladinsChampionSkin paladinsChampionSkin, PaladinsChampion paladinsChampion);
        void InsertItem(PaladinsItem paladinsItem);
        void InsertUserSettings(UserSettings settings);

        void Update(object objectForUpdate);

        void DeleteChampion(PaladinsChampion paladinsChampion);
        void DeleteChampionSkin(PaladinsChampionSkin paladinsChampionSkin, PaladinsChampion parentPaladinsChampion);
        void DeleteItem(PaladinsItem paladinsItem);
        void DeleteUserSettings(UserSettings settings);

        #endregion

        #region Rest Service Data Access

        Task<PatchInfo> RetrievePatchNumber();
        Task<Player> RetrievePlayerByNameFromRestServiceAsync(string name);
        Task<PlayerStatus> RetrievePlayerStatusFromRestServiceAsync(Player player);
        Task<IEnumerable<MatchHistory>> RetrievePlayerMatchHistoryFromRestServiceAsync(Player player);
        Task<IEnumerable<Friend>> RetrievePlayerFriendsFromRestServiceAsync(Player player);
        Task<IEnumerable<ChampionRank>> RetrievePlayerChampionRanksFromRestServiceAsync(Player player);
        Task<IEnumerable<PlayerAchievements>> RetrievePlayerAchievementsFromRestServiceAsync(Player player);
        Task<IEnumerable<PlayerLoadouts>> RetrievePlayerLoadoutsFromRestServiceAsync(Player player);
        Task<IEnumerable<MatchDetails>> RetrieveMatchFromRestServiceAsync(string matchid);

        Task<IEnumerable<PaladinsChampion>> RetrieveChampionsFromRestServiceAsync();
        Task<IEnumerable<PaladinsItem>> RetrieveItemsFromRestServiceAsync();

        #endregion
    }
}
