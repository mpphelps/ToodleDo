namespace ToodleDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ToDoItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 2000),
                        Priority = c.Byte(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        DueDateTime = c.DateTime(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ToDoTags",
                c => new
                    {
                        ToDoId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ToDoId, t.TagId })
                .ForeignKey("dbo.ToDoItems", t => t.ToDoId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ToDoId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.ToDoTags", "ToDoId", "dbo.ToDoItems");
            DropForeignKey("dbo.ToDoItems", "OwnerId", "dbo.Owners");
            DropIndex("dbo.ToDoTags", new[] { "TagId" });
            DropIndex("dbo.ToDoTags", new[] { "ToDoId" });
            DropIndex("dbo.ToDoItems", new[] { "OwnerId" });
            DropTable("dbo.ToDoTags");
            DropTable("dbo.Tags");
            DropTable("dbo.ToDoItems");
            DropTable("dbo.Owners");
        }
    }
}
