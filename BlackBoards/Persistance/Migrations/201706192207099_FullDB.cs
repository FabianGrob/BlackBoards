namespace Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        IDTeam = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        MaxUsers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDTeam);
            
            CreateTable(
                "dbo.BlackBoards",
                c => new
                    {
                        IDBlackBoard = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Dimension_Width = c.Int(nullable: false),
                        Dimension_Height = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModificationDate = c.DateTime(nullable: false),
                        CreatorUser_ID = c.Int(),
                        teamBelongs_IDTeam = c.Int(nullable: false),
                        Team_IDTeam = c.Int(),
                    })
                .PrimaryKey(t => t.IDBlackBoard)
                .ForeignKey("dbo.Users", t => t.CreatorUser_ID)
                .ForeignKey("dbo.Teams", t => t.teamBelongs_IDTeam)
                .ForeignKey("dbo.Teams", t => t.Team_IDTeam)
                .Index(t => t.CreatorUser_ID)
                .Index(t => t.teamBelongs_IDTeam)
                .Index(t => t.Team_IDTeam);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        IDComment = c.Int(nullable: false, identity: true),
                        commentingUserID = c.Int(nullable: false),
                        resolvingUserID = c.Int(nullable: false),
                        CommentingDate = c.DateTime(nullable: false),
                        ResolvingDate = c.DateTime(nullable: false),
                        WrittenComment = c.String(),
                        Item_IDItem = c.Int(),
                        itemBelong_IDItem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDComment)
                .ForeignKey("dbo.Users", t => t.commentingUserID)
                .ForeignKey("dbo.Items", t => t.Item_IDItem)
                .ForeignKey("dbo.Items", t => t.itemBelong_IDItem)
                .ForeignKey("dbo.Users", t => t.resolvingUserID)
                .Index(t => t.commentingUserID)
                .Index(t => t.resolvingUserID)
                .Index(t => t.Item_IDItem)
                .Index(t => t.itemBelong_IDItem);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        IDItem = c.Int(nullable: false, identity: true),
                        Dimension_Width = c.Int(nullable: false),
                        Dimension_Height = c.Int(nullable: false),
                        Origin_XAxis = c.Int(nullable: false),
                        Origin_YAxis = c.Int(nullable: false),
                        ImgPath = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        Font = c.String(),
                        FontSize = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        blackBoardBelongs_IDBlackBoard = c.Int(nullable: false),
                        BlackBoard_IDBlackBoard = c.Int(),
                    })
                .PrimaryKey(t => t.IDItem)
                .ForeignKey("dbo.BlackBoards", t => t.blackBoardBelongs_IDBlackBoard)
                .ForeignKey("dbo.Connections", t => t.IDItem)
                .ForeignKey("dbo.BlackBoards", t => t.BlackBoard_IDBlackBoard)
                .Index(t => t.IDItem)
                .Index(t => t.blackBoardBelongs_IDBlackBoard)
                .Index(t => t.BlackBoard_IDBlackBoard);
            
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        IDConnection = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        Direction = c.Int(nullable: false),
                        From_IDItem = c.Int(),
                        To_IDItem = c.Int(),
                    })
                .PrimaryKey(t => t.IDConnection)
                .ForeignKey("dbo.Items", t => t.From_IDItem)
                .ForeignKey("dbo.Items", t => t.To_IDItem)
                .Index(t => t.From_IDItem)
                .Index(t => t.To_IDItem);
            
            CreateTable(
                "dbo.ScoreUserInTeams",
                c => new
                    {
                        IDScoreUserInTeam = c.Int(nullable: false, identity: true),
                        Score_CreateBlackBoard = c.Int(nullable: false),
                        Score_DeleteBlackBoard = c.Int(nullable: false),
                        Score_AddItem = c.Int(nullable: false),
                        Score_AddComment = c.Int(nullable: false),
                        Score_SolveComment = c.Int(nullable: false),
                        Team_IDTeam = c.Int(),
                        theTeam_IDTeam = c.Int(nullable: false),
                        theUser_ID = c.Int(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.IDScoreUserInTeam)
                .ForeignKey("dbo.Teams", t => t.Team_IDTeam)
                .ForeignKey("dbo.Teams", t => t.theTeam_IDTeam)
                .ForeignKey("dbo.Users", t => t.theUser_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Team_IDTeam)
                .Index(t => t.theTeam_IDTeam)
                .Index(t => t.theUser_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.EstablishedScoreTeams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Score_CreateBlackBoard = c.Int(nullable: false),
                        Score_DeleteBlackBoard = c.Int(nullable: false),
                        Score_AddItem = c.Int(nullable: false),
                        Score_AddComment = c.Int(nullable: false),
                        Score_SolveComment = c.Int(nullable: false),
                        Team_IDTeam = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.Team_IDTeam)
                .ForeignKey("dbo.Teams", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.Team_IDTeam);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        IDUser = c.Int(nullable: false),
                        IDTeam = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDUser, t.IDTeam })
                .ForeignKey("dbo.Users", t => t.IDUser, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.IDTeam, cascadeDelete: true)
                .Index(t => t.IDUser)
                .Index(t => t.IDTeam);
            
            AddColumn("dbo.Users", "Team_IDTeam", c => c.Int());
            CreateIndex("dbo.Users", "Team_IDTeam");
            AddForeignKey("dbo.Users", "Team_IDTeam", "dbo.Teams", "IDTeam");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Team_IDTeam", "dbo.Teams");
            DropForeignKey("dbo.EstablishedScoreTeams", "ID", "dbo.Teams");
            DropForeignKey("dbo.EstablishedScoreTeams", "Team_IDTeam", "dbo.Teams");
            DropForeignKey("dbo.BlackBoards", "Team_IDTeam", "dbo.Teams");
            DropForeignKey("dbo.BlackBoards", "teamBelongs_IDTeam", "dbo.Teams");
            DropForeignKey("dbo.Items", "BlackBoard_IDBlackBoard", "dbo.BlackBoards");
            DropForeignKey("dbo.BlackBoards", "CreatorUser_ID", "dbo.Users");
            DropForeignKey("dbo.ScoreUserInTeams", "User_ID", "dbo.Users");
            DropForeignKey("dbo.ScoreUserInTeams", "theUser_ID", "dbo.Users");
            DropForeignKey("dbo.ScoreUserInTeams", "theTeam_IDTeam", "dbo.Teams");
            DropForeignKey("dbo.ScoreUserInTeams", "Team_IDTeam", "dbo.Teams");
            DropForeignKey("dbo.Comments", "resolvingUserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "itemBelong_IDItem", "dbo.Items");
            DropForeignKey("dbo.Connections", "To_IDItem", "dbo.Items");
            DropForeignKey("dbo.Connections", "From_IDItem", "dbo.Items");
            DropForeignKey("dbo.Items", "IDItem", "dbo.Connections");
            DropForeignKey("dbo.Comments", "Item_IDItem", "dbo.Items");
            DropForeignKey("dbo.Items", "blackBoardBelongs_IDBlackBoard", "dbo.BlackBoards");
            DropForeignKey("dbo.Comments", "commentingUserID", "dbo.Users");
            DropForeignKey("dbo.Members", "IDTeam", "dbo.Teams");
            DropForeignKey("dbo.Members", "IDUser", "dbo.Users");
            DropIndex("dbo.Members", new[] { "IDTeam" });
            DropIndex("dbo.Members", new[] { "IDUser" });
            DropIndex("dbo.EstablishedScoreTeams", new[] { "Team_IDTeam" });
            DropIndex("dbo.EstablishedScoreTeams", new[] { "ID" });
            DropIndex("dbo.ScoreUserInTeams", new[] { "User_ID" });
            DropIndex("dbo.ScoreUserInTeams", new[] { "theUser_ID" });
            DropIndex("dbo.ScoreUserInTeams", new[] { "theTeam_IDTeam" });
            DropIndex("dbo.ScoreUserInTeams", new[] { "Team_IDTeam" });
            DropIndex("dbo.Connections", new[] { "To_IDItem" });
            DropIndex("dbo.Connections", new[] { "From_IDItem" });
            DropIndex("dbo.Items", new[] { "BlackBoard_IDBlackBoard" });
            DropIndex("dbo.Items", new[] { "blackBoardBelongs_IDBlackBoard" });
            DropIndex("dbo.Items", new[] { "IDItem" });
            DropIndex("dbo.Comments", new[] { "itemBelong_IDItem" });
            DropIndex("dbo.Comments", new[] { "Item_IDItem" });
            DropIndex("dbo.Comments", new[] { "resolvingUserID" });
            DropIndex("dbo.Comments", new[] { "commentingUserID" });
            DropIndex("dbo.BlackBoards", new[] { "Team_IDTeam" });
            DropIndex("dbo.BlackBoards", new[] { "teamBelongs_IDTeam" });
            DropIndex("dbo.BlackBoards", new[] { "CreatorUser_ID" });
            DropIndex("dbo.Users", new[] { "Team_IDTeam" });
            DropColumn("dbo.Users", "Team_IDTeam");
            DropTable("dbo.Members");
            DropTable("dbo.EstablishedScoreTeams");
            DropTable("dbo.ScoreUserInTeams");
            DropTable("dbo.Connections");
            DropTable("dbo.Items");
            DropTable("dbo.Comments");
            DropTable("dbo.BlackBoards");
            DropTable("dbo.Teams");
        }
    }
}
