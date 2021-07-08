namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_galleryadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageFiles", "ImageStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImageFiles", "ImageStatus");
        }
    }
}
