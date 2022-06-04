namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLinkLenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "ProfilePictureLink", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ProfilePictureLink", c => c.String(maxLength: 20));
        }
    }
}
