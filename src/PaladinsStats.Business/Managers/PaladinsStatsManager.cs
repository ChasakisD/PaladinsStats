using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaladinsAPI.Models;
using PaladinsStats.Business.Interfaces;
using PaladinsStats.Model.Models;

namespace PaladinsStats.Business.Managers
{
    public class PaladinsStatsManager : IPaladinsStatsManager
    {
        private readonly IPaladinsStatsDataAccessService _dataAccess;
        private readonly IPaladinsStatsRestService _restService;

        public PaladinsStatsManager(IPaladinsStatsDataAccessService dataAccess, IPaladinsStatsRestService restService)
        {
            _dataAccess = dataAccess;
            _restService = restService;
        }

        public void Update(object objectForUpdate)
        {
            _dataAccess.Update(objectForUpdate);
        }

        public IEnumerable<PaladinsChampion> GetChampions()
        {
            return _dataAccess.GetChampions();
        }

        public void LoadChampionSkins(PaladinsChampion paladinsChampion)
        {
            var championSkins = _dataAccess.GetChampionSkins(paladinsChampion);
            paladinsChampion.ChampionSkins.Clear();
            foreach (var championSkin in championSkins)
            {
                paladinsChampion.ChampionSkins.Add(championSkin);
            }
        }

        public IEnumerable<PaladinsItem> GetItems()
        {
            return _dataAccess.GetItems();
        }

        public UserSettings GetUserSettings()
        {
            return _dataAccess.GetUserSettings();
        }

        public void InsertChampion(PaladinsChampion paladinsChampion)
        {
            _dataAccess.InsertChampion(paladinsChampion);
        }

        public void InsertChampionSkin(PaladinsChampionSkin paladinsChampionSkin, PaladinsChampion paladinsChampion)
        {
            paladinsChampionSkin.ParentPaladinsChampion = paladinsChampion;
            _dataAccess.InsertChampionSkin(paladinsChampionSkin, paladinsChampion);
            paladinsChampion.ChampionSkins.Add(paladinsChampionSkin);
        }

        public void InsertItem(PaladinsItem paladinsItem)
        {
            _dataAccess.InsertItem(paladinsItem);
        }

        public void InsertUserSettings(UserSettings settings)
        {
            _dataAccess.InsertUserSettings(settings);
        }

        public void DeleteChampion(PaladinsChampion paladinsChampion)
        {
            var championSkins = paladinsChampion.ChampionSkins;
            _dataAccess.DeleteChampionSkins(championSkins);
            _dataAccess.DeleteChampion(paladinsChampion);
        }

        public void DeleteChampionSkin(PaladinsChampionSkin paladinsChampionSkin, PaladinsChampion parentPaladinsChampion)
        {
            _dataAccess.DeleteChampionSkin(paladinsChampionSkin);
            parentPaladinsChampion.ChampionSkins.Remove(paladinsChampionSkin);
        }

        public void DeleteItem(PaladinsItem paladinsItem)
        {
            _dataAccess.DeleteItem(paladinsItem);
        }

        public void DeleteUserSettings(UserSettings settings)
        {
            _dataAccess.DeleteUserSettings(settings);
        }

        public async Task<PatchInfo> RetrievePatchNumber()
        {
            return await _restService.GetPatchInfoAsync();
        }

        public async Task<Player> RetrievePlayerByNameFromRestServiceAsync(string name)
        {
            return await _restService.GetPlayerByNameAsync(name);
        }

        public async Task<PlayerStatus> RetrievePlayerStatusFromRestServiceAsync(Player player)
        {
            return await _restService.GetPlayerStatusAsync(player);
        }

        public async Task<IEnumerable<MatchHistory>> RetrievePlayerMatchHistoryFromRestServiceAsync(Player player)
        {
            return await _restService.GetPlayerMatchHistoryAsync(player);
        }

        public async Task<IEnumerable<Friend>> RetrievePlayerFriendsFromRestServiceAsync(Player player)
        {
            return await _restService.GetPlayerFriendsAsync(player);
        }

        public async Task<IEnumerable<ChampionRank>> RetrievePlayerChampionRanksFromRestServiceAsync(Player player)
        {
            return await _restService.GetPlayerChampionRanksAsync(player);
        }

        public async Task<IEnumerable<PlayerAchievements>> RetrievePlayerAchievementsFromRestServiceAsync(Player player)
        {
            return await _restService.GetPlayerAchievementsAsync(player);
        }

        public async Task<IEnumerable<PlayerLoadouts>> RetrievePlayerLoadoutsFromRestServiceAsync(Player player)
        {
            return await _restService.GetPlayerLoadoutsAsync(player);
        }

        public async Task<IEnumerable<MatchDetails>> RetrieveMatchFromRestServiceAsync(string matchid)
        {
            return await _restService.GetMatchAsync(matchid);
        }

        public async Task<IEnumerable<PaladinsChampion>> RetrieveChampionsFromRestServiceAsync()
        {
            var prevChampions = _dataAccess.GetChampions();
            foreach (var champion in prevChampions)
            {
                DeleteChampion(champion);
            }

            var champions = await _restService.RetrieveChampionsAsync();
            var championEntities = champions.Select(champion => new PaladinsChampion(champion)).ToList();

            var allChampionSkins = await _restService.RetrieveChampionSkinsAsync();
            var allChampionSkinEntities = allChampionSkins.Select(skin => new PaladinsChampionSkin(skin)).ToList();

            foreach (var champion in championEntities)
            {
                InsertChampion(champion);
                var championSkins = allChampionSkinEntities
                    .Where(skin => skin.ChampionId == champion.ChampionId)
                    .ToList();

                foreach (var championSkin in championSkins)
                {
                    InsertChampionSkin(championSkin, champion);
                }
            }
            return championEntities;
        }

        public async Task<IEnumerable<PaladinsItem>> RetrieveItemsFromRestServiceAsync()
        {
            var prevItems = _dataAccess.GetItems();
            foreach (var item in prevItems)
            {
                DeleteItem(item);
            }

            var items = await _restService.RetrieveItemsAsync();
            var itemEntities = items.Select(item => new PaladinsItem(item)).ToList();

            foreach (var item in itemEntities)
            {
                InsertItem(item);
            }
            return itemEntities;
        }
    }
}
