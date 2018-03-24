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
                        Vejnavn = c.String(nullable: false, maxLength: 128),
                        Husnummer = c.Int(nullable: false),
                        By_Land = c.String(maxLength: 128),
                        By_PostNr = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Vejnavn, t.Husnummer })
                .ForeignKey("dbo.Bies", t => new { t.By_Land, t.By_PostNr })
                .Index(t => new { t.By_Land, t.By_PostNr });
            
            CreateTable(
                "dbo.Bies",
                c => new
                    {
                        Land = c.String(nullable: false, maxLength: 128),
                        PostNr = c.String(nullable: false, maxLength: 128),
                        Navn = c.String(),
                    })
                .PrimaryKey(t => new { t.Land, t.PostNr });
            
            CreateTable(
                "dbo.ErTilknyttets",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Type);
            
            CreateTable(
                "dbo.Kontakts",
                c => new
                    {
                        KontaktId = c.Int(nullable: false, identity: true),
                        Fornavn = c.String(),
                        Mellemnavn = c.String(),
                        Efternavn = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.KontaktId);
            
            CreateTable(
                "dbo.Telefonnummers",
                c => new
                    {
                        Nummer = c.Int(nullable: false, identity: true),
                        Brug = c.String(),
                        Teleselskab = c.String(),
                        Kontakt_KontaktId = c.Int(),
                    })
                .PrimaryKey(t => t.Nummer)
                .ForeignKey("dbo.Kontakts", t => t.Kontakt_KontaktId)
                .Index(t => t.Kontakt_KontaktId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefonnummers", "Kontakt_KontaktId", "dbo.Kontakts");
            DropForeignKey("dbo.Adresses", new[] { "By_Land", "By_PostNr" }, "dbo.Bies");
            DropIndex("dbo.Telefonnummers", new[] { "Kontakt_KontaktId" });
            DropIndex("dbo.Adresses", new[] { "By_Land", "By_PostNr" });
            DropTable("dbo.Telefonnummers");
            DropTable("dbo.Kontakts");
            DropTable("dbo.ErTilknyttets");
            DropTable("dbo.Bies");
            DropTable("dbo.Adresses");
        }
    }
}
