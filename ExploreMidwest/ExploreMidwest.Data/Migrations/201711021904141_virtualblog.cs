namespace ExploreMidwest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virtualblog : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Blog_BlogId", "dbo.Blogs");
            DropIndex("dbo.Tags", new[] { "Blog_BlogId" });
            CreateTable(
                "dbo.TagsBlogs",
                c => new
                    {
                        Tags_TagsId = c.Int(nullable: false),
                        Blog_BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tags_TagsId, t.Blog_BlogId })
                .ForeignKey("dbo.Tags", t => t.Tags_TagsId, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.Blog_BlogId, cascadeDelete: true)
                .Index(t => t.Tags_TagsId)
                .Index(t => t.Blog_BlogId);
            
            DropColumn("dbo.Tags", "Blog_BlogId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Blog_BlogId", c => c.Int());
            DropForeignKey("dbo.TagsBlogs", "Blog_BlogId", "dbo.Blogs");
            DropForeignKey("dbo.TagsBlogs", "Tags_TagsId", "dbo.Tags");
            DropIndex("dbo.TagsBlogs", new[] { "Blog_BlogId" });
            DropIndex("dbo.TagsBlogs", new[] { "Tags_TagsId" });
            DropTable("dbo.TagsBlogs");
            CreateIndex("dbo.Tags", "Blog_BlogId");
            AddForeignKey("dbo.Tags", "Blog_BlogId", "dbo.Blogs", "BlogId");
        }
    }
}
