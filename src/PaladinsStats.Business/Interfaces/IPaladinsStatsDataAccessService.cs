using System.Collections.Generic;
using PaladinsStats.Model.Models;
using PaladinsStats.Models;

namespace PaladinsStats.Business.Interfaces
{
    public interface IPaladinsStatsDataAccessService
    {
        IEnumerable<ChampionEntity> GetChampions();
        IEnumerable<ChampionSkinEntity> GetChampionSkins(ChampionEntity champion);
        IEnumerable<ItemEntity> GetItems();

        void InsertChampion(ChampionEntity champion);
        void InsertChampionSkin(ChampionSkinEntity championSkin, ChampionEntity champion);
        void InsertItem(ItemEntity item);

        void Update(object objectForUpdate);

        void DeleteChampion(ChampionEntity champion);
        void DeleteChampionSkins(IEnumerable<ChampionSkinEntity> championSkins);
        void DeleteChampionSkin(ChampionSkinEntity championSkin);
        void DeleteItem(ItemEntity item);
    }
}
