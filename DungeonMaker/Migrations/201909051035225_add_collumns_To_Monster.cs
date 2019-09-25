namespace DungeonMaker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_collumns_To_Monster : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Monster", "SavingThrows", c => c.String());
            AddColumn("dbo.Monster", "DamageVulnerabilities", c => c.String());
            AlterColumn("dbo.Monster", "Languages", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Monster", "Languages", c => c.String());
            DropColumn("dbo.Monster", "DamageVulnerabilities");
            DropColumn("dbo.Monster", "SavingThrows");
        }
    }
}
