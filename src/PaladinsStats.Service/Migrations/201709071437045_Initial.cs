namespace PaladinsStats.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChampionEntities",
                c => new
                    {
                        DbId = c.Int(nullable: false, identity: true),
                        id = c.Int(nullable: false),
                        Ability1 = c.String(),
                        Ability2 = c.String(),
                        Ability3 = c.String(),
                        Ability4 = c.String(),
                        Ability5 = c.String(),
                        abilityId1 = c.Int(nullable: false),
                        abilityId2 = c.Int(nullable: false),
                        abilityId3 = c.Int(nullable: false),
                        abilityId4 = c.Int(nullable: false),
                        abilityId5 = c.Int(nullable: false),
                        ChampionAbility1_URL = c.String(),
                        ChampionAbility2_URL = c.String(),
                        ChampionAbility3_URL = c.String(),
                        ChampionAbility4_URL = c.String(),
                        ChampionAbility5_URL = c.String(),
                        ChampionCard_URL = c.String(),
                        ChampionIcon_URL = c.String(),
                        Cons = c.String(),
                        Health = c.Int(nullable: false),
                        Lore = c.String(),
                        Name = c.String(),
                        OnFreeRotation = c.String(),
                        Pantheon = c.String(),
                        Pros = c.String(),
                        Roles = c.String(),
                        Speed = c.Int(nullable: false),
                        Title = c.String(),
                        Type = c.String(),
                        abilityDescription1 = c.String(),
                        abilityDescription2 = c.String(),
                        abilityDescription3 = c.String(),
                        abilityDescription4 = c.String(),
                        abilityDescription5 = c.String(),
                        latestChampion = c.String(),
                        ret_msg = c.String(),
                    })
                .PrimaryKey(t => t.DbId);
            
            CreateTable(
                "dbo.ChampionSkinEntities",
                c => new
                    {
                        DbId = c.Int(nullable: false, identity: true),
                        champion_id = c.Int(nullable: false),
                        champion_name = c.String(),
                        skin_id1 = c.Int(nullable: false),
                        skin_id2 = c.Int(nullable: false),
                        skin_name = c.String(),
                        ret_msg = c.String(),
                    })
                .PrimaryKey(t => t.DbId);
            
            CreateTable(
                "dbo.ItemEntities",
                c => new
                    {
                        DbId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DeviceName = c.String(),
                        IconId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        ShortDesc = c.String(),
                        ret_msg = c.String(),
                    })
                .PrimaryKey(t => t.DbId);
            
            CreateTable(
                "dbo.LoadoutItemEntities",
                c => new
                    {
                        DbId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        ItemName = c.String(),
                        Points = c.Int(nullable: false),
                        PlayerLoadoutsEntity_DbId = c.Int(),
                    })
                .PrimaryKey(t => t.DbId)
                .ForeignKey("dbo.PlayerLoadoutsEntities", t => t.PlayerLoadoutsEntity_DbId)
                .Index(t => t.PlayerLoadoutsEntity_DbId);
            
            CreateTable(
                "dbo.PlayerAchievementsEntities",
                c => new
                    {
                        DbId = c.Int(nullable: false, identity: true),
                        AssistedKills = c.Int(nullable: false),
                        CampsCleared = c.Int(nullable: false),
                        DivineSpree = c.Int(nullable: false),
                        DoubleKills = c.Int(nullable: false),
                        FireGiantKills = c.Int(nullable: false),
                        FirstBloods = c.Int(nullable: false),
                        GodLikeSpree = c.Int(nullable: false),
                        GoldFuryKills = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        ImmortalSpree = c.Int(nullable: false),
                        KillingSpree = c.Int(nullable: false),
                        MinionKills = c.Int(nullable: false),
                        Name = c.String(),
                        PentaKills = c.Int(nullable: false),
                        PhoenixKills = c.Int(nullable: false),
                        PlayerKills = c.Int(nullable: false),
                        QuadraKills = c.Int(nullable: false),
                        RampageSpree = c.Int(nullable: false),
                        ShutdownSpree = c.Int(nullable: false),
                        SiegeJuggernautKills = c.Int(nullable: false),
                        TowerKills = c.Int(nullable: false),
                        TripleKills = c.Int(nullable: false),
                        UnstoppableSpree = c.Int(nullable: false),
                        WildJuggernautKills = c.Int(nullable: false),
                        ret_msg = c.String(),
                    })
                .PrimaryKey(t => t.DbId);
            
            CreateTable(
                "dbo.PlayerChampionRankEntities",
                c => new
                    {
                        DbId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Assists = c.Int(nullable: false),
                        Deaths = c.Int(nullable: false),
                        Kills = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                        MinionKills = c.Int(nullable: false),
                        Rank = c.Int(nullable: false),
                        Wins = c.Int(nullable: false),
                        Worshippers = c.Int(nullable: false),
                        champion = c.String(),
                        champion_id = c.String(),
                        player_id = c.String(),
                        ret_msg = c.String(),
                    })
                .PrimaryKey(t => t.DbId);
            
            CreateTable(
                "dbo.PlayerEntities",
                c => new
                    {
                        DbId = c.Int(nullable: false, identity: true),
                        Created_Datetime = c.String(),
                        Id = c.Int(nullable: false),
                        Last_Login_Datetime = c.String(),
                        Leaves = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                        MasteryLevel = c.Int(nullable: false),
                        Name = c.String(),
                        Personal_Status_Message = c.String(),
                        Region = c.String(),
                        TeamId = c.Int(nullable: false),
                        Team_Name = c.String(),
                        Total_Achievements = c.Int(nullable: false),
                        Total_Worshippers = c.Int(nullable: false),
                        Wins = c.Int(nullable: false),
                        lastUpdated = c.DateTime(nullable: false),
                        Champions_Last_Updated = c.DateTime(nullable: false),
                        History_Last_Updated = c.DateTime(nullable: false),
                        ret_msg = c.String(),
                    })
                .PrimaryKey(t => t.DbId);
            
            CreateTable(
                "dbo.PlayerLoadoutsEntities",
                c => new
                    {
                        DbId = c.Int(nullable: false, identity: true),
                        ChampionId = c.Int(nullable: false),
                        ChampionName = c.String(),
                        DeckId = c.Int(nullable: false),
                        DeckName = c.String(),
                        PlayerId = c.Int(nullable: false),
                        PlayerName = c.String(),
                    })
                .PrimaryKey(t => t.DbId);
            
            CreateTable(
                "dbo.PlayerStatusEntities",
                c => new
                    {
                        DbId = c.Int(nullable: false, identity: true),
                        Match = c.Int(nullable: false),
                        personal_status_message = c.String(),
                        status = c.Int(nullable: false),
                        status_string = c.String(),
                        playerId = c.Int(nullable: false),
                        ret_msg = c.String(),
                    })
                .PrimaryKey(t => t.DbId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoadoutItemEntities", "PlayerLoadoutsEntity_DbId", "dbo.PlayerLoadoutsEntities");
            DropIndex("dbo.LoadoutItemEntities", new[] { "PlayerLoadoutsEntity_DbId" });
            DropTable("dbo.PlayerStatusEntities");
            DropTable("dbo.PlayerLoadoutsEntities");
            DropTable("dbo.PlayerEntities");
            DropTable("dbo.PlayerChampionRankEntities");
            DropTable("dbo.PlayerAchievementsEntities");
            DropTable("dbo.LoadoutItemEntities");
            DropTable("dbo.ItemEntities");
            DropTable("dbo.ChampionSkinEntities");
            DropTable("dbo.ChampionEntities");
        }
    }
}
