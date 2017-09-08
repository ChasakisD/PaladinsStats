using System.Collections.Generic;
using System.Linq;
using PaladinsStats.Business.Interfaces;
using PaladinsStats.Model.Models;
using SQLite.Net;

namespace PaladinsStats.Business.Services
{
    public class PaladinsStatsDataAccessService : IPaladinsStatsDataAccessService
    {
        private readonly SQLiteConnection _dbConnection;

        private static readonly object Locker = new object();

        public PaladinsStatsDataAccessService(ISqliteConnectionService sqliteConnectionService)
        {
            _dbConnection = sqliteConnectionService.GetConnection();

            _dbConnection.CreateTable<PaladinsChampion>();
            _dbConnection.CreateTable<PaladinsChampionSkin>();
            _dbConnection.CreateTable<PaladinsItem>();
            _dbConnection.CreateTable<UserSettings>();
        }

        #region Get Methods

        public IEnumerable<PaladinsChampion> GetChampions()
        {
            lock (Locker)
            {
                return _dbConnection.Table<PaladinsChampion>();
            }
        }

        public IEnumerable<PaladinsChampionSkin> GetChampionSkins(PaladinsChampion paladinsChampion)
        {
            lock (Locker)
            {
                var championSkins = _dbConnection.Table<PaladinsChampionSkin>().Where(skin => skin.ChampionId == paladinsChampion.ChampionId);
                foreach (var championSkin in championSkins)
                {
                    championSkin.ParentPaladinsChampion = paladinsChampion;
                }

                return championSkins;
            }
        }

        public IEnumerable<PaladinsItem> GetItems()
        {
            lock (Locker)
            {
                return _dbConnection.Table<PaladinsItem>();
            }
        }

        public UserSettings GetUserSettings()
        {
            lock (Locker)
            {
                return _dbConnection.Table<UserSettings>().ElementAt(0);
            }
        }

        #endregion

        #region Insert Methods

        public void InsertChampion(PaladinsChampion paladinsChampion)
        {
            lock (Locker)
            {
                _dbConnection.Insert(paladinsChampion);
            }
        }

        public void InsertChampionSkin(PaladinsChampionSkin paladinsChampionSkin, PaladinsChampion paladinsChampion)
        {
            lock (Locker)
            {
                paladinsChampionSkin.ParentPaladinsChampion = paladinsChampion;
                _dbConnection.Insert(paladinsChampionSkin);
            }
        }

        public void InsertItem(PaladinsItem paladinsItem)
        {
            lock (Locker)
            {
                _dbConnection.Insert(paladinsItem);
            }
        }

        public void InsertUserSettings(UserSettings settings)
        {
            lock (Locker)
            {
                if(_dbConnection.Table<UserSettings>().Any()) Update(settings);
                else _dbConnection.Insert(settings);
            }
        }

        #endregion

        #region  Update Methods
        public void Update(object objectForUpdate)
        {
            lock (Locker)
            {
                _dbConnection.Update(objectForUpdate);
            }
        }

        #endregion

        #region Delete Methods

        public void DeleteChampion(PaladinsChampion paladinsChampion)
        {
            lock (Locker)
            {
                _dbConnection.Delete(paladinsChampion);
            }
        }

        public void DeleteChampionSkins(IEnumerable<PaladinsChampionSkin> championSkins)
        {
            lock (Locker)
            {
                foreach (var championSkin in championSkins)
                {
                    _dbConnection.Delete(championSkin);
                }
            }
        }

        public void DeleteChampionSkin(PaladinsChampionSkin paladinsChampionSkin)
        {
            lock (Locker)
            {
                DeleteChampionSkins(new List<PaladinsChampionSkin>{paladinsChampionSkin});
            }
        }

        public void DeleteItem(PaladinsItem paladinsItem)
        {
            lock (Locker)
            {
                _dbConnection.Delete(paladinsItem);
            }
        }

        public void DeleteUserSettings(UserSettings settings)
        {
            lock (Locker)
            {
                _dbConnection.Delete(settings);
            }
        }

        #endregion
    }
}
