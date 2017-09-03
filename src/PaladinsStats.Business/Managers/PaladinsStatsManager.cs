using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaladinsAPI.Models;
using PaladinsStats.Business.Interfaces;
using PaladinsStats.Model.Models;
using PaladinsStats.Models;

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

        public IEnumerable<ChampionEntity> GetChampions()
        {
            return _dataAccess.GetChampions();
        }

        public void LoadChampionSkins(ChampionEntity champion)
        {
            var championSkins = _dataAccess.GetChampionSkins(champion);
            champion.ChampionSkins.Clear();
            foreach (var championSkin in championSkins)
            {
                champion.ChampionSkins.Add(championSkin);
            }
        }

        public IEnumerable<ItemEntity> GetItems()
        {
            return _dataAccess.GetItems();
        }

        public void InsertChampion(ChampionEntity champion)
        {
            _dataAccess.InsertChampion(champion);
        }

        public void InsertChampionSkin(ChampionSkinEntity championSkin, ChampionEntity champion)
        {
            championSkin.ParentChampion = champion;
            _dataAccess.InsertChampionSkin(championSkin, champion);
            champion.ChampionSkins.Add(championSkin);
        }

        public void InsertItem(ItemEntity item)
        {
            _dataAccess.InsertItem(item);
        }

        public void DeleteChampion(ChampionEntity champion)
        {
            var championSkins = champion.ChampionSkins;
            _dataAccess.DeleteChampionSkins(championSkins);
            _dataAccess.DeleteChampion(champion);
        }

        public void DeleteChampionSkin(ChampionSkinEntity championSkin, ChampionEntity parentChampion)
        {
            _dataAccess.DeleteChampionSkin(championSkin);
            parentChampion.ChampionSkins.Remove(championSkin);
        }

        public void DeleteItem(ItemEntity item)
        {
            _dataAccess.DeleteItem(item);
        }

        public Task<double> RetrievePatchNumber()
        {
            throw new NotImplementedException();
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

        public async Task<IEnumerable<ChampionEntity>> RetrieveChampionsFromRestServiceAsync()
        {
            var prevChampions = _dataAccess.GetChampions();
            foreach (var champion in prevChampions)
            {
                DeleteChampion(champion);
            }

            var champions = await _restService.RetrieveChampionsAsync();
            var championEntities = champions.Select(champion => new ChampionEntity(champion)).ToList();

            var allChampionSkins = await _restService.RetrieveChampionSkinsAsync();
            var allChampionSkinEntities = allChampionSkins.Select(skin => new ChampionSkinEntity(skin)).ToList();

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

        public async Task<IEnumerable<ItemEntity>> RetrieveItemsFromRestServiceAsync()
        {
            var prevItems = _dataAccess.GetItems();
            foreach (var item in prevItems)
            {
                DeleteItem(item);
            }

            var items = await _restService.RetrieveItemsAsync();
            var itemEntities = items.Select(item => new ItemEntity(item)).ToList();

            foreach (var item in itemEntities)
            {
                InsertItem(item);
            }
            return itemEntities;
        }
    }
}
