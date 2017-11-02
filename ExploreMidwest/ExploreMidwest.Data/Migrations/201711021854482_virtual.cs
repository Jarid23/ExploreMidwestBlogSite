namespace ExploreMidwest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _virtual : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagsBlogs", "Tags_TagsId", "dbo.Tags");
            DropForeignKey("dbo.TagsBlogs", "Blog_BlogId", "dbo.Blogs");
            DropIndex("dbo.TagsBlogs", new[] { "Tags_TagsId" });
            DropIndex("dbo.TagsBlogs", new[] { "Blog_BlogId" });
            AddColumn("dbo.Tags", "Blog_BlogId", c => c.Int());
            CreateIndex("dbo.Tags", "Blog_BlogId");
            AddForeignKey("dbo.Tags", "Blog_BlogId", "dbo.Blogs", "BlogId");
            DropTable("dbo.TagsBlogs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagsBlogs",
                c => new
                    {
                        Tags_TagsId = c.Int(nullable: false),
                        Blog_BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tags_TagsId, t.Blog_BlogId });
            
            DropForeignKey("dbo.Tags", "Blog_BlogId", "dbo.Blogs");
            DropIndex("dbo.Tags", new[] { "Blog_BlogId" });
            DropColumn("dbo.Tags", "Blog_BlogId");
            CreateIndex("dbo.TagsBlogs", "Blog_BlogId");
            CreateIndex("dbo.TagsBlogs", "Tags_TagsId");
            AddForeignKey("dbo.TagsBlogs", "Blog_BlogId", "dbo.Blogs", "BlogId", cascadeDelete: true);
            AddForeignKey("dbo.TagsBlogs", "Tags_TagsId", "dbo.Tags", "TagsId", cascadeDelete: true);
        }
    }
}
