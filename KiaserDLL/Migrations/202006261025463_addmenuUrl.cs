namespace KiaserDLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmenuUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "MenuUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "MenuUrl");
        }
    }
}
