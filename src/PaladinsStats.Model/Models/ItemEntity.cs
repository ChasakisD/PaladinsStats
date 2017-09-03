using Newtonsoft.Json;
using PaladinsAPI.Models;
using Prism.Mvvm;
using SQLite.Net.Attributes;

namespace PaladinsStats.Model.Models
{
    public class ItemEntity : BindableBase
    {
        private int _itemDbid;
        [JsonProperty("DbId"), PrimaryKey]
        public int ItemDbId
        {
            get => _itemDbid;
            set => SetProperty(ref _itemDbid, value);
        }

        private string _shortDesc;

        public string ShortDesc
        {
            get => _shortDesc;
            set => SetProperty(ref _shortDesc, value);
        }

        private string _description;

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private string _deviceName;

        public string DeviceName
        {
            get => _deviceName;
            set => SetProperty(ref _deviceName, value);
        }

        private int _iconId;

        public int IconId
        {
            get => _iconId;
            set => SetProperty(ref _iconId, value);
        }

        private int _itemId;

        public int ItemId
        {
            get => _itemId;
            set => SetProperty(ref _itemId, value);
        }

        private int _price;

        public int Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        public ItemEntity(Item item)
        {
            ShortDesc = item.ShortDesc;
            Description = item.Description;
            DeviceName = item.DeviceName;
            IconId = item.IconId;
            ItemId = item.ItemId;
            Price = item.Price;
        }
    }
}
