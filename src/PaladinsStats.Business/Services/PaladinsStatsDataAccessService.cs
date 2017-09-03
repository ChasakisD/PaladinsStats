using System.Collections.Generic;
using PaladinsStats.Business.Interfaces;
using PaladinsStats.Model.Models;
using PaladinsStats.Models;
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

            _dbConnection.CreateTable<ChampionEntity>();
            _dbConnection.CreateTable<ChampionSkinEntity>();
            _dbConnection.CreateTable<ItemEntity>();
        }

        #region Get Methods

        public IEnumerable<ChampionEntity> GetChampions()
        {
            lock (Locker)
            {
                return _dbConnection.Table<ChampionEntity>();
            }
        }

        public IEnumerable<ChampionSkinEntity> GetChampionSkins(ChampionEntity champion)
        {
            lock (Locker)
            {
                var championSkins = _dbConnection.Table<ChampionSkinEntity>().Where(skin => skin.ChampionId == champion.ChampionId);
                foreach (var championSkin in championSkins)
                {
                    championSkin.ParentChampion = champion;
                }

                return championSkins;
            }
        }

        public IEnumerable<ItemEntity> GetItems()
        {
            lock (Locker)
            {
                return _dbConnection.Table<ItemEntity>();
            }
        }

        #endregion

        #region Insert Methods

        public void InsertChampion(ChampionEntity champion)
        {
            lock (Locker)
            {
                _dbConnection.Insert(champion);
            }
        }

        public void InsertChampionSkin(ChampionSkinEntity championSkin, ChampionEntity champion)
        {
            lock (Locker)
            {
                championSkin.ParentChampion = champion;
                _dbConnection.Insert(championSkin);
            }
        }

        public void InsertItem(ItemEntity item)
        {
            lock (Locker)
            {
                _dbConnection.Insert(item);
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

        public void DeleteChampion(ChampionEntity champion)
        {
            lock (Locker)
            {
                _dbConnection.Delete(champion);
            }
        }

        public void DeleteChampionSkins(IEnumerable<ChampionSkinEntity> championSkins)
        {
            lock (Locker)
            {
                foreach (var championSkin in championSkins)
                {
                    _dbConnection.Delete(championSkin);
                }
            }
        }

        public void DeleteChampionSkin(ChampionSkinEntity championSkin)
        {
            lock (Locker)
            {
                DeleteChampionSkins(new List<ChampionSkinEntity>{championSkin});
            }
        }

        public void DeleteItem(ItemEntity item)
        {
            lock (Locker)
            {
                _dbConnection.Delete(item);
            }
        }

        #endregion
    }
}
