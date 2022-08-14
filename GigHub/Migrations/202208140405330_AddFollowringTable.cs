namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowringTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followings", "ArtistId", "dbo.AspNetUsers");
            RenameColumn(table: "dbo.Followings", name: "ArtistId", newName: "FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_ArtistId", newName: "IX_FolloweeId");
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FollowerId", "FolloweeId" });
            AddForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "ArtistId", "FollowerId" });
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "IX_ArtistId");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "ArtistId");
            AddForeignKey("dbo.Followings", "ArtistId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
