namespace DungeonMaker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Strength = c.String(nullable: false),
                        Dexterity = c.String(nullable: false),
                        Constitution = c.String(nullable: false),
                        Intelligence = c.String(nullable: false),
                        Wisdom = c.String(nullable: false),
                        Charisma = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Monster", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Monster",
                c => new
                    {
                        MonsterID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ArmorClass = c.Int(nullable: false),
                        HitPoints = c.Short(nullable: false),
                        Speed = c.String(nullable: false),
                        SKills = c.String(),
                        DamageResistances = c.String(),
                        DamageImmunities = c.String(),
                        ConditionImmunities = c.String(),
                        Senses = c.String(),
                        Languages = c.String(),
                        Challenge = c.String(nullable: false),
                        Traits = c.String(),
                        Actions = c.String(),
                    })
                .PrimaryKey(t => t.MonsterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Abilities", "ID", "dbo.Monster");
            DropIndex("dbo.Abilities", new[] { "ID" });
            DropTable("dbo.Monster");
            DropTable("dbo.Abilities");
        }
    }
}
