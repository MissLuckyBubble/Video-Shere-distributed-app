namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maketheparentcomentnullable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "ParentCommentId" });
            AlterColumn("dbo.Comments", "ParentCommentId", c => c.Int());
            CreateIndex("dbo.Comments", "ParentCommentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "ParentCommentId" });
            AlterColumn("dbo.Comments", "ParentCommentId", c => c.Int(nullable: true));
            CreateIndex("dbo.Comments", "ParentCommentId");
        }
    }
}
