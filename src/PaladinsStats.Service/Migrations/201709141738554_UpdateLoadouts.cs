namespace PaladinsStats.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLoadouts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoadoutItemEntities", "DeckId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoadoutItemEntities", "DeckId");
        }
    }
}
