using System;
using System.Collections.Generic;
using System.Linq;
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
            return await GetAsync<Player>("Player", name);
        }

        public async Task<PlayerStatus> GetPlayerStatusAsync(Player player)
        {
            return await GetAsync<PlayerStatus>("PlayerStatus", player.Id);
        }

        public async Task<IEnumerable<MatchHistory>> GetPlayerMatchHistoryAsync(Player player)
        {
            return await GetAsync<IEnumerable<MatchHistory>>("History", player.Name);
        }

        public async Task<IEnumerable<Friend>> GetPlayerFriendsAsync(Player player)
        {
            return await GetAsync<IEnumerable<Friend>>("Friends", player.Id);
        }

        public async Task<IEnumerable<ChampionRank>> GetPlayerChampionRanksAsync(Player player)
        {
            return await GetAsync<IEnumerable<ChampionRank>>("ChampionRanks", player.Id);
        }

        public async Task<IEnumerable<PlayerAchievements>> GetPlayerAchievementsAsync(Player player)
        {
            return await GetAsync<IEnumerable<PlayerAchievements>>("PlayerAchievements", player.Id);
        }

        public Task<IEnumerable<PlayerLoadouts>> GetPlayerLoadoutsAsync(Player player)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MatchDetails>> GetMatchAsync(string matchId)
        {
            return await GetAsync<IEnumerable<MatchDetails>>("Match", matchId);
        }

        public async Task<IEnumerable<Champion>> RetrieveChampionsAsync()
        {
            return await GetAsync<IEnumerable<Champion>>("Champions");
        }

        public async Task<IEnumerable<ChampionSkin>> RetrieveChampionSkinsAsync()
        {
            return await GetAsync<IEnumerable<ChampionSkin>>("ChampionSkins");
        }

        public async Task<IEnumerable<Item>> RetrieveItemsAsync()
        {
            return await GetAsync<IEnumerable<Item>>("Items");
        }

        public async Task<PatchInfo> GetPatchInfoAsync()
        {
            return await GetAsync<PatchInfo>("PatchInfo");
        }

        private async Task<T> GetAsync<T>(string methodName, params dynamic[] parameters)
        {
            /* Generating the url we going to HTTP GET */
            var url = Constants.PaladinsApiUrl + methodName;

            /* Add every parameter we pushed into the request */
            url = parameters.Aggregate(url, (current, param) => (string) (current + ("/" + param.ToString())));

            var response = await _httpClient.GetStringAsync(url);
            var items = JsonConvert.DeserializeObject<T>(response);

            return items;
        }
    }
}
