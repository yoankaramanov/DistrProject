namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        ActorName = c.String(nullable: false, maxLength: 100),
                        ImageURL = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        NetWorth = c.Double(nullable: false),
                        Nationality = c.String(maxLength: 100),
                        Height = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.ActorId })
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieTitle = c.String(nullable: false, maxLength: 100),
                        ImageURL = c.String(),
                        DirectorId = c.Int(nullable: false),
                        Runtime = c.Int(nullable: false),
                        Genre = c.String(maxLength: 50),
                        Budget = c.Double(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        CinemaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Cinemas", t => t.CinemaId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Directors", t => t.DirectorId, cascadeDelete: true)
                .Index(t => t.DirectorId)
                .Index(t => t.CompanyId)
                .Index(t => t.CinemaId);
            
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        CinemaId = c.Int(nullable: false, identity: true),
                        CinemaName = c.String(nullable: false, maxLength: 100),
                        ImageURL = c.String(),
                        FoundingDate = c.DateTime(nullable: false),
                        NetWorth = c.Double(nullable: false),
                        CEO = c.String(maxLength: 100),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CinemaId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        ImageURL = c.String(),
                        NetWorth = c.Double(nullable: false),
                        FoundingDate = c.DateTime(nullable: false),
                        Country = c.String(maxLength: 100),
                        AnnualIncome = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(nullable: false, maxLength: 100),
                        ImageURL = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        NetWorth = c.Double(nullable: false),
                        Nationality = c.String(maxLength: 100),
                        Education = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.DirectorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieActors", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movies", "DirectorId", "dbo.Directors");
            DropForeignKey("dbo.Movies", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Movies", "CinemaId", "dbo.Cinemas");
            DropForeignKey("dbo.MovieActors", "ActorId", "dbo.Actors");
            DropIndex("dbo.Movies", new[] { "CinemaId" });
            DropIndex("dbo.Movies", new[] { "CompanyId" });
            DropIndex("dbo.Movies", new[] { "DirectorId" });
            DropIndex("dbo.MovieActors", new[] { "ActorId" });
            DropIndex("dbo.MovieActors", new[] { "MovieId" });
            DropTable("dbo.Directors");
            DropTable("dbo.Companies");
            DropTable("dbo.Cinemas");
            DropTable("dbo.Movies");
            DropTable("dbo.MovieActors");
            DropTable("dbo.Actors");
        }
    }
}
