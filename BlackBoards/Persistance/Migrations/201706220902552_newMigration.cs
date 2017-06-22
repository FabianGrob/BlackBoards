namespace Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlackBoards", "teamBelongs_IDTeam", "dbo.Teams");
            DropForeignKey("dbo.ScoreUserInTeams", "theTeam_IDTeam", "dbo.Teams");
            AddForeignKey("dbo.BlackBoards", "teamBelongs_IDTeam", "dbo.Teams", "IDTeam", cascadeDelete: true);
            AddForeignKey("dbo.ScoreUserInTeams", "theTeam_IDTeam", "dbo.Teams", "IDTeam", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScoreUserInTeams", "theTeam_IDTeam", "dbo.Teams");
            DropForeignKey("dbo.BlackBoards", "teamBelongs_IDTeam", "dbo.Teams");
            AddForeignKey("dbo.ScoreUserInTeams", "theTeam_IDTeam", "dbo.Teams", "IDTeam");
            AddForeignKey("dbo.BlackBoards", "teamBelongs_IDTeam", "dbo.Teams", "IDTeam");
        }
    }
}
