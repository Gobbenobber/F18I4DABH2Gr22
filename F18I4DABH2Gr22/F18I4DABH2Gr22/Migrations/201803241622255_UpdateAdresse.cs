namespace HandIn21.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdresse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ErTilknyttets", "Adresse_Vejnavn", c => c.String(maxLength: 128));
            AddColumn("dbo.ErTilknyttets", "Adresse_Husnummer", c => c.Int());
            AddColumn("dbo.ErTilknyttets", "Kontakt_KontaktId", c => c.Int());
            CreateIndex("dbo.ErTilknyttets", new[] { "Adresse_Vejnavn", "Adresse_Husnummer" });
            CreateIndex("dbo.ErTilknyttets", "Kontakt_KontaktId");
            AddForeignKey("dbo.ErTilknyttets", new[] { "Adresse_Vejnavn", "Adresse_Husnummer" }, "dbo.Adresses", new[] { "Vejnavn", "Husnummer" });
            AddForeignKey("dbo.ErTilknyttets", "Kontakt_KontaktId", "dbo.Kontakts", "KontaktId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ErTilknyttets", "Kontakt_KontaktId", "dbo.Kontakts");
            DropForeignKey("dbo.ErTilknyttets", new[] { "Adresse_Vejnavn", "Adresse_Husnummer" }, "dbo.Adresses");
            DropIndex("dbo.ErTilknyttets", new[] { "Kontakt_KontaktId" });
            DropIndex("dbo.ErTilknyttets", new[] { "Adresse_Vejnavn", "Adresse_Husnummer" });
            DropColumn("dbo.ErTilknyttets", "Kontakt_KontaktId");
            DropColumn("dbo.ErTilknyttets", "Adresse_Husnummer");
            DropColumn("dbo.ErTilknyttets", "Adresse_Vejnavn");
        }
    }
}
