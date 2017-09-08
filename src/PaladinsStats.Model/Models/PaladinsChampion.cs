using System.Collections.ObjectModel;
using Newtonsoft.Json;
using PaladinsAPI.Models;
using Prism.Mvvm;
using SQLite.Net.Attributes;

namespace PaladinsStats.Model.Models
{
    public class PaladinsChampion : BindableBase
    {
        private int _championDbId;
        [JsonProperty("DbId"), PrimaryKey]
        public int ChampionDbId
        {
            get => _championDbId;
            set => SetProperty(ref _championDbId, value);
        }

        private int _championId;
        [JsonProperty("id")]
        public int ChampionId
        {
            get => _championId;
            set => SetProperty(ref _championId, value);
        }

        private string _ability1;
        public string Ability1
        {
            get => _ability1;
            set => SetProperty(ref _ability1, value);
        }

        private string _ability2;

        public string Ability2
        {
            get => _ability2;
            set => SetProperty(ref _ability2, value);
        }

        private string _ability3;

        public string Ability3
        {
            get => _ability3;
            set => SetProperty(ref _ability3, value);
        }

        private string _ability4;

        public string Ability4
        {
            get => _ability4;
            set => SetProperty(ref _ability4, value);
        }

        private string _ability5;

        public string Ability5
        {
            get => _ability5;
            set => SetProperty(ref _ability5, value);
        }

        private int _abilityId1;

        [JsonProperty("abilityId1")]
        public int AbilityId1
        {
            get => _abilityId1;
            set => SetProperty(ref _abilityId1, value);
        }

        private int _abilityId2;

        [JsonProperty("abilityId2")]
        public int AbilityId2
        {
            get => _abilityId2;
            set => SetProperty(ref _abilityId2, value);
        }

        private int _abilityId3;

        [JsonProperty("abilityId3")]
        public int AbilityId3
        {
            get => _abilityId3;
            set => SetProperty(ref _abilityId3, value);
        }

        private int _abilityId4;

        [JsonProperty("abilityId4")]
        public int AbilityId4
        {
            get => _abilityId4;
            set => SetProperty(ref _abilityId4, value);
        }

        private int _abilityId5;

        [JsonProperty("abilityId5")]
        public int AbilityId5
        {
            get => _abilityId5;
            set => SetProperty(ref _abilityId5, value);
        }

        private string _championAbility1Url;

        [JsonProperty("ChampionAbility1_URL")]
        public string ChampionAbility1Url
        {
            get => _championAbility1Url;
            set => SetProperty(ref _championAbility1Url, value);
        }

        private string _championAbility2Url;

        [JsonProperty("ChampionAbility2_URL")]
        public string ChampionAbility2Url
        {
            get => _championAbility2Url;
            set => SetProperty(ref _championAbility2Url, value);
        }

        private string _championAbility3Url;

        [JsonProperty("ChampionAbility3_URL")]
        public string ChampionAbility3Url
        {
            get => _championAbility3Url;
            set => SetProperty(ref _championAbility3Url, value);
        }

        private string _championAbility4Url;

        [JsonProperty("ChampionAbility4_URL")]
        public string ChampionAbility4Url
        {
            get => _championAbility4Url;
            set => SetProperty(ref _championAbility4Url, value);
        }

        private string _championAbility5Url;

        [JsonProperty("ChampionAbility5_URL")]
        public string ChampionAbility5Url
        {
            get => _championAbility5Url;
            set => SetProperty(ref _championAbility5Url, value);
        }

        private string _championCardUrl;

        [JsonProperty("ChampionCard_URL")]
        public string ChampionCardUrl
        {
            get => _championCardUrl;
            set => SetProperty(ref _championCardUrl, value);
        }

        private string _championIconUrl;

        [JsonProperty("ChampionIcon_URL")]
        public string ChampionIconUrl
        {
            get => _championIconUrl;
            set => SetProperty(ref _championIconUrl, value);
        }

        private string _cons;

        public string Cons
        {
            get => _cons;
            set => SetProperty(ref _cons, value);
        }

        private int _health;

        public int Health
        {
            get => _health;
            set => SetProperty(ref _health, value);
        }

        private string _lore;

        public string Lore
        {
            get => _lore;
            set => SetProperty(ref _lore, value);
        }

        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _onFreeRotations;

        public string OnFreeRotation
        {
            get => _onFreeRotations;
            set => SetProperty(ref _onFreeRotations, value);
        }

        private string _pantheon;

        public string Pantheon
        {
            get => _pantheon;
            set => SetProperty(ref _pantheon, value);
        }

        private string _pros;

        public string Pros
        {
            get => _pros;
            set => SetProperty(ref _pros, value);
        }

        private string _roles;

        public string Roles
        {
            get => _roles;
            set => SetProperty(ref _roles, value);
        }

        private int _speed;

        public int Speed
        {
            get => _speed;
            set => SetProperty(ref _speed, value);
        }

        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _type;

        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        private string _abilityDesctiption1;

        [JsonProperty("abilityDescription1")]
        public string AbilityDescription1
        {
            get => _abilityDesctiption1;
            set => SetProperty(ref _abilityDesctiption1, value);
        }

        private string _abilityDesctiption2;

        [JsonProperty("abilityDescription2")]
        public string AbilityDescription2
        {
            get => _abilityDesctiption2;
            set => SetProperty(ref _abilityDesctiption2, value);
        }

        private string _abilityDesctiption3;

        [JsonProperty("abilityDescription3")]
        public string AbilityDescription3
        {
            get => _abilityDesctiption3;
            set => SetProperty(ref _abilityDesctiption3, value);
        }

        private string _abilityDesctiption4;

        [JsonProperty("abilityDescription4")]
        public string AbilityDescription4
        {
            get => _abilityDesctiption4;
            set => SetProperty(ref _abilityDesctiption4, value);
        }

        private string _abilityDesctiption5;

        [JsonProperty("abilityDescription5")]
        public string AbilityDescription5
        {
            get => _abilityDesctiption5;
            set => SetProperty(ref _abilityDesctiption5, value);
        }

        private string _latestChampion;

        [JsonProperty("latestChampion")]
        public string LatestChampion
        {
            get => _latestChampion;
            set => SetProperty(ref _latestChampion, value);
        }

        public ObservableCollection<PaladinsChampionSkin> ChampionSkins { get; } = new ObservableCollection<PaladinsChampionSkin>();

        public PaladinsChampion(Champion champion)
        {
            ChampionId = champion.id;
            Ability1 = champion.Ability1;
            Ability2 = champion.Ability2;
            Ability3 = champion.Ability3;
            Ability4 = champion.Ability4;
            Ability5 = champion.Ability5;
            AbilityDescription1 = champion.abilityDescription1;
            AbilityDescription2 = champion.abilityDescription2;
            AbilityDescription3 = champion.abilityDescription3;
            AbilityDescription4 = champion.abilityDescription4;
            AbilityDescription5 = champion.abilityDescription5;
            ChampionAbility1Url = champion.ChampionAbility1_URL;
            ChampionAbility2Url = champion.ChampionAbility2_URL;
            ChampionAbility3Url = champion.ChampionAbility3_URL;
            ChampionAbility4Url = champion.ChampionAbility4_URL;
            ChampionAbility5Url = champion.ChampionAbility5_URL;
            ChampionCardUrl = champion.ChampionCard_URL;
            ChampionIconUrl = champion.ChampionIcon_URL;
            Cons = champion.Cons;
            Pros = champion.Pros;
            Health = champion.Health;
            Lore = champion.Lore;
            Name = champion.Name;
            OnFreeRotation = champion.OnFreeRotation;
            Pantheon = champion.Pantheon;
            Roles = champion.Roles;
            Speed = champion.Speed;
            Title = champion.Title;
            Type = champion.Type;
        }
    }
}
