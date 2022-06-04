namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteperentcommeentfromdatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ParentCommentId", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "ParentCommentId" });
            DropColumn("dbo.Comments", "ParentCommentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "ParentCommentId", c => c.Int());
            CreateIndex("dbo.Comments", "ParentCommentId");
            AddForeignKey("dbo.Comments", "ParentCommentId", "dbo.Comments", "Id");
        }
    }
}
