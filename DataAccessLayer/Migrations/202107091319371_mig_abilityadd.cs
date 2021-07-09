namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_abilityadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        AbilityID = c.Int(nullable: false, identity: true),
                        AbilityName = c.String(maxLength: 100),
                        AbilityCount = c.Int(nullable: false),
                        AbilityStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AbilityID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Abilities");
        }
    }
}
