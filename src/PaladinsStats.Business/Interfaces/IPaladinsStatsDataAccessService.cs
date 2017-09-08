using System.Collections.Generic;
using PaladinsStats.Model.Models;

namespace PaladinsStats.Business.Interfaces
{
    public interface IPaladinsStatsDataAccessService
    {
        IEnumerable<PaladinsChampion> GetChampions();
        IEnumerable<PaladinsChampionSkin> GetChampionSkins(PaladinsChampion paladinsChampion);
        IEnumerable<PaladinsItem> GetItems();
        UserSettings GetUserSettings();

        void InsertChampion(PaladinsChampion paladinsChampion);
        void InsertChampionSkin(PaladinsChampionSkin paladinsChampionSkin, PaladinsChampion paladinsChampion);
        void InsertItem(PaladinsItem paladinsItem);
        void InsertUserSettings(UserSettings settings);

        void Update(object objectForUpdate);

        void DeleteChampion(PaladinsChampion paladinsChampion);
        void DeleteChampionSkins(IEnumerable<PaladinsChampionSkin> championSkins);
        void DeleteChampionSkin(PaladinsChampionSkin paladinsChampionSkin);
        void DeleteItem(PaladinsItem paladinsItem);
        void DeleteUserSettings(UserSettings settings);
    }
}
