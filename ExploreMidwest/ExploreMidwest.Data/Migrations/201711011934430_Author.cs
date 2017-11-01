namespace ExploreMidwest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Author : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Author");
        }
    }
}
