namespace ExploreMidwest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        IsFinished = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryType = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagsId = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                        Blog_BlogId = c.Int(),
                    })
                .PrimaryKey(t => t.TagsId)
                .ForeignKey("dbo.Blogs", t => t.Blog_BlogId)
                .Index(t => t.Blog_BlogId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        Url = c.String(),
                        IsInNavigation = c.Boolean(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "Blog_BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Tags", new[] { "Blog_BlogId" });
            DropIndex("dbo.Blogs", new[] { "Category_CategoryId" });
            DropTable("dbo.Pages");
            DropTable("dbo.Tags");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
        }
    }
}
