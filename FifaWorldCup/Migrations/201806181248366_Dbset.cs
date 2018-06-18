namespace FifaWorldCup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dbset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stadia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Capacity = c.String(),
                        StadiumName = c.String(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.StadiumCities",
                c => new
                    {
                        Stadium_Id = c.Int(nullable: false),
                        City_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stadium_Id, t.City_Id })
                .ForeignKey("dbo.Stadia", t => t.Stadium_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .Index(t => t.Stadium_Id)
                .Index(t => t.City_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Stadia", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.StadiumCities", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.StadiumCities", "Stadium_Id", "dbo.Stadia");
            DropIndex("dbo.StadiumCities", new[] { "City_Id" });
            DropIndex("dbo.StadiumCities", new[] { "Stadium_Id" });
            DropIndex("dbo.Teams", new[] { "Group_Id" });
            DropIndex("dbo.Stadia", new[] { "Team_Id" });
            DropTable("dbo.StadiumCities");
            DropTable("dbo.Teams");
            DropTable("dbo.Groups");
            DropTable("dbo.Stadia");
            DropTable("dbo.Cities");
        }
    }
}
