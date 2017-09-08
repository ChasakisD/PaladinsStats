using System.Data.Entity;
namespace PaladinsStats.Service.Models
{
    public class PaladinsStatsServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PaladinsStatsServiceContext() : base("PaladinsStatsServiceContext")
        {
        }
        
        public DbSet<ChampionEntity> ChampionEntities { get; set; }
        public DbSet<ChampionSkinEntity> ChampionSkinEntities { get; set; }
        public DbSet<ItemEntity> ItemEntities { get; set; }
        public DbSet<PlayerEntity> PlayerEntities { get; set; }
        public DbSet<PlayerStatusEntity> PlayerStatusEntities { get; set; }
        public DbSet<PlayerAchievementsEntity> PlayerAchievementsEntities { get; set; }
        public DbSet<PlayerChampionRankEntity> PlayerChampionRankEntities { get; set; }
        public DbSet<LoadoutItemEntity> LoadoutItemEntities { get; set; }
        public DbSet<PlayerLoadoutsEntity> PlayerLoadoutsEntities { get; set; }
    }
}
