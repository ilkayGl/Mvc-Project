namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "IsRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "IsImportant", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "Trash", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsImportant", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsSpam", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsSpam");
            DropColumn("dbo.Messages", "IsImportant");
            DropColumn("dbo.Messages", "IsRead");
            DropColumn("dbo.Messages", "Trash");
            DropColumn("dbo.Messages", "IsDraft");
            DropColumn("dbo.Contacts", "IsImportant");
            DropColumn("dbo.Contacts", "IsRead");
            DropColumn("dbo.Abouts", "Status");
        }
    }
}
