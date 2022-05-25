namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 500),
                        Likes = c.Int(nullable: true),
                        Dislikes = c.Int(nullable: true),
                        OwnerId = c.Int(nullable: true),
                        VideoId = c.Int(nullable: true),
                        ParentCommentId = c.Int(nullable: true),
                        CreateDate = c.DateTime(nullable: true),
                        UpdateDate = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: false)
                .ForeignKey("dbo.Comments", t => t.ParentCommentId)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: false)
                .Index(t => t.OwnerId)
                .Index(t => t.VideoId)
                .Index(t => t.ParentCommentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Country = c.String(maxLength: 56),
                        Description = c.String(maxLength: 500),
                        Age = c.Int(nullable: true),
                        DateOfBirth = c.DateTime(nullable: true),
                        Gender = c.String(maxLength: 10),
                        ProfilePictureLink = c.String(maxLength: 20),
                        CreateDate = c.DateTime(nullable: true),
                        UpdateDate = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        VideoLink = c.String(nullable: false, maxLength: 200),
                        Likes = c.Int(nullable: true),
                        Dislikes = c.Int(nullable: true),
                        Description = c.String(maxLength: 500),
                        OwnerId = c.Int(nullable: true),
                        CreateDate = c.DateTime(nullable: true),
                        UpdateDate = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: false)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Videos", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.Comments", "ParentCommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "OwnerId", "dbo.Users");
            DropIndex("dbo.Videos", new[] { "OwnerId" });
            DropIndex("dbo.Comments", new[] { "ParentCommentId" });
            DropIndex("dbo.Comments", new[] { "VideoId" });
            DropIndex("dbo.Comments", new[] { "OwnerId" });
            DropTable("dbo.Videos");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
        }
    }
}
