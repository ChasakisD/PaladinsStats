using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;
using PaladinsAPI.Models;
using PaladinsStats.Business.Interfaces;
using PaladinsStats.Model;

namespace PaladinsStats.Business.Services
{
    public class PaladinsStatsRestService : IPaladinsStatsRestService
    {
        private readonly HttpClient _httpClient = new HttpClient(new NativeMessageHandler());

        public async Task<Player> GetPlayerByNameAsync(string name)
        {
            var response = await _httpClient.GetStringAsync(Constants.PaladinsApiUrl + "player/" + name);
            var player = JsonConvert.DeserializeObject<Player>(response);

            return player;
        }

        public async Task<PlayerStatus> GetPlayerStatusAsync(Player player)
        {
            var response = await _httpClient.GetStringAsync(Constants.PaladinsApiUrl + "status/" + player.Id);
            var status = JsonConvert.DeserializeObject<PlayerStatus>(response);

            return status;
        }

        public async Task<IEnumerable<MatchHistory>> GetPlayerMatchHistoryAsync(Player player)
        {
            var response = await _httpClient.GetStringAsync(Constants.PaladinsApiUrl + "history/" + player.Name);
            var history = JsonConvert.DeserializeObject<IEnumerable<MatchHistory>>(response);

            return history;
        }

        public async Task<IEnumerable<Friend>> GetPlayerFriendsAsync(Player player)
        {
            var response = await _httpClient.GetStringAsync(Constants.PaladinsApiUrl + "friends/" + player.Id);
            var friends = JsonConvert.DeserializeObject<IEnumerable<Friend>>(response);

            return friends;
        }

        public async Task<IEnumerable<ChampionRank>> GetPlayerChampionRanksAsync(Player player)
        {
            var response = await _httpClient.GetStringAsync(Constants.PaladinsApiUrl + "championranks/" + player.Id);
            var championRanks = JsonConvert.DeserializeObject<IEnumerable<ChampionRank>>(response);

            return championRanks;
        }

        public async Task<IEnumerable<PlayerAchievements>> GetPlayerAchievementsAsync(Player player)
        {
            var response = await _httpClient.GetStringAsync(Constants.PaladinsApiUrl + "PlayerAchievements/" + player.Id);
            var achievements = JsonConvert.DeserializeObject<IEnumerable<PlayerAchievements>>(response);

            return achievements;
        }

        public Task<IEnumerable<PlayerLoadouts>> GetPlayerLoadoutsAsync(Player player)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MatchDetails>> GetMatchAsync(string matchId)
        {
            var response = await _httpClient.GetStringAsync(Constants.PaladinsApiUrl + "PlayerAchievements/" + matchId);
            var matchDetails = JsonConvert.DeserializeObject<IEnumerable<MatchDetails>>(response);

            return matchDetails;
        }

        public async Task<IEnumerable<Champion>> RetrieveChampionsAsync()
        {
            var response = await _httpClient.GetStringAsync(Constants.PaladinsApiUrl + "Champions/");
            var champions = JsonConvert.DeserializeObject<IEnumerable<Champion>>(response);

            return champions;
        }

        public async Task<IEnumerable<ChampionSkin>> RetrieveChampionSkinsAsync()
        {
            var response = await _httpClient.GetStringAsync(Constants.PaladinsApiUrl + "ChampionSkins/");
            var championSkins = JsonConvert.DeserializeObject<IEnumerable<ChampionSkin>>(response);

            return championSkins;
        }

        public async Task<IEnumerable<Item>> RetrieveItemsAsync()
        {
            var response = await _httpClient.GetStringAsync(Constants.PaladinsApiUrl + "Items/");
            var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(response);

            return items;
        }
    }
}
