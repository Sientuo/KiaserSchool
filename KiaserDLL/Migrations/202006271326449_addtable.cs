namespace KiaserDLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassData",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50, unicode: false),
                        ClassName = c.String(maxLength: 50),
                        TeacherId = c.String(maxLength: 50, unicode: false),
                        CreateBy = c.String(maxLength: 50),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50, unicode: false),
                        MenuCode = c.String(maxLength: 50, unicode: false),
                        MenuName = c.String(maxLength: 50),
                        PId = c.String(maxLength: 50, unicode: false),
                        MenuUrl = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 200),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 50),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50, unicode: false),
                        SUserCode = c.String(maxLength: 50, unicode: false),
                        SName = c.String(maxLength: 50),
                        ClassId = c.String(maxLength: 50),
                        Sex = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 50),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
            DropTable("dbo.Menu");
            DropTable("dbo.ClassData");
        }
    }
}
