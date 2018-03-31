namespace HandIn21.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vejnavn = c.String(),
                        Husnummer = c.Int(nullable: false),
                        By_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bies", t => t.By_Id)
                .Index(t => t.By_Id);
            
            CreateTable(
                "dbo.Bies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Land = c.String(),
                        PostNr = c.String(),
                        Navn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ErTilknyttets",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 128),
                        Adresse_Id = c.Int(),
                        Kontakt_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Type)
                .ForeignKey("dbo.Adresses", t => t.Adresse_Id)
                .ForeignKey("dbo.Kontakts", t => t.Kontakt_Id)
                .Index(t => t.Adresse_Id)
                .Index(t => t.Kontakt_Id);
            
            CreateTable(
                "dbo.Kontakts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fornavn = c.String(),
                        Mellemnavn = c.String(),
                        Efternavn = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Telefonnummers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nummer = c.Int(nullable: false),
                        Brug = c.String(),
                        Teleselskab = c.String(),
                        Kontakt_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kontakts", t => t.Kontakt_Id)
                .Index(t => t.Kontakt_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ErTilknyttets", "Kontakt_Id", "dbo.Kontakts");
            DropForeignKey("dbo.Telefonnummers", "Kontakt_Id", "dbo.Kontakts");
            DropForeignKey("dbo.ErTilknyttets", "Adresse_Id", "dbo.Adresses");
            DropForeignKey("dbo.Adresses", "By_Id", "dbo.Bies");
            DropIndex("dbo.Telefonnummers", new[] { "Kontakt_Id" });
            DropIndex("dbo.ErTilknyttets", new[] { "Kontakt_Id" });
            DropIndex("dbo.ErTilknyttets", new[] { "Adresse_Id" });
            DropIndex("dbo.Adresses", new[] { "By_Id" });
            DropTable("dbo.Telefonnummers");
            DropTable("dbo.Kontakts");
            DropTable("dbo.ErTilknyttets");
            DropTable("dbo.Bies");
            DropTable("dbo.Adresses");
        }
    }
}
