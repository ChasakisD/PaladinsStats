using Newtonsoft.Json;
using PaladinsAPI.Models;
using Prism.Mvvm;
using SQLite.Net.Attributes;

namespace PaladinsStats.Model.Models
{
    public class PaladinsChampionSkin : BindableBase
    {
        private int _championSkinId;
        [JsonProperty("DbId"), PrimaryKey]
        public int ChampionSkinId
        {
            get => _championSkinId;
            set => SetProperty(ref _championSkinId, value);
        }

        private int _championId;
        [JsonProperty("champion_id")]
        public int ChampionId
        {
            get => _championId;
            set => SetProperty(ref _championId, value);
        }

        private string _championName;
        [JsonProperty("champion_name")]
        public string ChampionName
        {
            get => _championName;
            set => SetProperty(ref _championName, value);
        }

        private int _skinId1;
        [JsonProperty("skin_id1")]
        public int SkinId1
        {
            get => _skinId1;
            set => SetProperty(ref _skinId1, value);
        }

        private int _skinId2;
        [JsonProperty("skin_id2")]
        public int SkinId2
        {
            get => _skinId2;
            set => SetProperty(ref _skinId2, value);
        }

        private string _skinName;
        [JsonProperty("skin_name")]
        public string SkinName
        {
            get => _skinName;
            set => SetProperty(ref _skinName, value);
        }

        [Ignore]
        public PaladinsChampion ParentPaladinsChampion { get; set; }

        public PaladinsChampionSkin(ChampionSkin championSkin)
        {
            ChampionId = championSkin.champion_id;
            ChampionName = championSkin.champion_name;
            SkinId1 = championSkin.skin_id1;
            SkinId2 = championSkin.skin_id2;
            SkinName = championSkin.skin_name;
        }
    }
}
