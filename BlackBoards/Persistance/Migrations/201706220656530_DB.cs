namespace Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB : DbMigration
    {
        public override void Up()
        {
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
                        creatorUser_ID = c.Int(),
                        teamBelongs_IDTeam = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDBlackBoard)
                .ForeignKey("dbo.Users", t => t.creatorUser_ID)
                .ForeignKey("dbo.Teams", t => t.teamBelongs_IDTeam)
                .Index(t => t.creatorUser_ID)
                .Index(t => t.teamBelongs_IDTeam);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Password = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.EstablishedScoreTeams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        score_CreateBlackBoard = c.Int(nullable: false),
                        score_DeleteBlackBoard = c.Int(nullable: false),
                        score_AddItem = c.Int(nullable: false),
                        score_AddComment = c.Int(nullable: false),
                        score_SolveComment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teams", t => t.ID)
                .Index(t => t.ID);
            
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
                        theTeam_IDTeam = c.Int(nullable: false),
                        theUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.IDScoreUserInTeam)
                .ForeignKey("dbo.Teams", t => t.theTeam_IDTeam)
                .ForeignKey("dbo.Users", t => t.theUser_ID)
                .Index(t => t.theTeam_IDTeam)
                .Index(t => t.theUser_ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        IDComment = c.Int(nullable: false, identity: true),
                        CommentingDate = c.DateTime(nullable: false),
                        ResolvingDate = c.DateTime(nullable: false),
                        WrittenComment = c.String(),
                        commentingUser_ID = c.Int(),
                        itemBelong_IDItem = c.Int(),
                        resolvingUser_ID = c.Int(),
                        User_ID = c.Int(),
                        User_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.IDComment)
                .ForeignKey("dbo.Users", t => t.commentingUser_ID)
                .ForeignKey("dbo.Items", t => t.itemBelong_IDItem)
                .ForeignKey("dbo.Users", t => t.resolvingUser_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .ForeignKey("dbo.Users", t => t.User_ID1)
                .Index(t => t.commentingUser_ID)
                .Index(t => t.itemBelong_IDItem)
                .Index(t => t.resolvingUser_ID)
                .Index(t => t.User_ID)
                .Index(t => t.User_ID1);
            
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
                        blackBoardBelongs_IDBlackBoard = c.Int(),
                        connect_IDConnection = c.Int(),
                    })
                .PrimaryKey(t => t.IDItem)
                .ForeignKey("dbo.BlackBoards", t => t.blackBoardBelongs_IDBlackBoard)
                .ForeignKey("dbo.Connections", t => t.connect_IDConnection)
                .Index(t => t.blackBoardBelongs_IDBlackBoard)
                .Index(t => t.connect_IDConnection);
            
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        IDConnection = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        Direction = c.Int(nullable: false),
                        from_IDItem = c.Int(),
                        to_IDItem = c.Int(),
                    })
                .PrimaryKey(t => t.IDConnection)
                .ForeignKey("dbo.Items", t => t.from_IDItem)
                .ForeignKey("dbo.Items", t => t.to_IDItem)
                .Index(t => t.from_IDItem)
                .Index(t => t.to_IDItem);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlackBoards", "teamBelongs_IDTeam", "dbo.Teams");
            DropForeignKey("dbo.BlackBoards", "creatorUser_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_ID1", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "resolvingUser_ID", "dbo.Users");
            DropForeignKey("dbo.Items", "connect_IDConnection", "dbo.Connections");
            DropForeignKey("dbo.Connections", "to_IDItem", "dbo.Items");
            DropForeignKey("dbo.Connections", "from_IDItem", "dbo.Items");
            DropForeignKey("dbo.Comments", "itemBelong_IDItem", "dbo.Items");
            DropForeignKey("dbo.Items", "blackBoardBelongs_IDBlackBoard", "dbo.BlackBoards");
            DropForeignKey("dbo.Comments", "commentingUser_ID", "dbo.Users");
            DropForeignKey("dbo.Members", "IDTeam", "dbo.Teams");
            DropForeignKey("dbo.Members", "IDUser", "dbo.Users");
            DropForeignKey("dbo.ScoreUserInTeams", "theUser_ID", "dbo.Users");
            DropForeignKey("dbo.ScoreUserInTeams", "theTeam_IDTeam", "dbo.Teams");
            DropForeignKey("dbo.EstablishedScoreTeams", "ID", "dbo.Teams");
            DropIndex("dbo.Members", new[] { "IDTeam" });
            DropIndex("dbo.Members", new[] { "IDUser" });
            DropIndex("dbo.Connections", new[] { "to_IDItem" });
            DropIndex("dbo.Connections", new[] { "from_IDItem" });
            DropIndex("dbo.Items", new[] { "connect_IDConnection" });
            DropIndex("dbo.Items", new[] { "blackBoardBelongs_IDBlackBoard" });
            DropIndex("dbo.Comments", new[] { "User_ID1" });
            DropIndex("dbo.Comments", new[] { "User_ID" });
            DropIndex("dbo.Comments", new[] { "resolvingUser_ID" });
            DropIndex("dbo.Comments", new[] { "itemBelong_IDItem" });
            DropIndex("dbo.Comments", new[] { "commentingUser_ID" });
            DropIndex("dbo.ScoreUserInTeams", new[] { "theUser_ID" });
            DropIndex("dbo.ScoreUserInTeams", new[] { "theTeam_IDTeam" });
            DropIndex("dbo.EstablishedScoreTeams", new[] { "ID" });
            DropIndex("dbo.BlackBoards", new[] { "teamBelongs_IDTeam" });
            DropIndex("dbo.BlackBoards", new[] { "creatorUser_ID" });
            DropTable("dbo.Members");
            DropTable("dbo.Connections");
            DropTable("dbo.Items");
            DropTable("dbo.Comments");
            DropTable("dbo.ScoreUserInTeams");
            DropTable("dbo.EstablishedScoreTeams");
            DropTable("dbo.Teams");
            DropTable("dbo.Users");
            DropTable("dbo.BlackBoards");
        }
    }
}
