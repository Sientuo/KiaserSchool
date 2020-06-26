namespace KiaserDLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuCode = c.String(),
                        MenuName = c.String(),
                        PId = c.String(),
                        Remark = c.String(),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Menu");
        }
    }
}
