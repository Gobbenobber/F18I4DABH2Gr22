namespace HandIn21_Udvidet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedKeysOnErTilknyttet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ErTilknyttets", "Adresse_Id", "dbo.Adresses");
            DropForeignKey("dbo.ErTilknyttets", "Kontakt_Id", "dbo.Kontakts");
            DropIndex("dbo.ErTilknyttets", new[] { "Adresse_Id" });
            DropIndex("dbo.ErTilknyttets", new[] { "Kontakt_Id" });
            RenameColumn(table: "dbo.ErTilknyttets", name: "Adresse_Id", newName: "AdresseId");
            RenameColumn(table: "dbo.ErTilknyttets", name: "Kontakt_Id", newName: "KontaktId");
            DropPrimaryKey("dbo.ErTilknyttets");
            AlterColumn("dbo.ErTilknyttets", "AdresseId", c => c.Int(nullable: false));
            AlterColumn("dbo.ErTilknyttets", "KontaktId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ErTilknyttets", new[] { "KontaktId", "AdresseId", "Type" });
            CreateIndex("dbo.ErTilknyttets", "KontaktId");
            CreateIndex("dbo.ErTilknyttets", "AdresseId");
            AddForeignKey("dbo.ErTilknyttets", "AdresseId", "dbo.Adresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ErTilknyttets", "KontaktId", "dbo.Kontakts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ErTilknyttets", "KontaktId", "dbo.Kontakts");
            DropForeignKey("dbo.ErTilknyttets", "AdresseId", "dbo.Adresses");
            DropIndex("dbo.ErTilknyttets", new[] { "AdresseId" });
            DropIndex("dbo.ErTilknyttets", new[] { "KontaktId" });
            DropPrimaryKey("dbo.ErTilknyttets");
            AlterColumn("dbo.ErTilknyttets", "KontaktId", c => c.Int());
            AlterColumn("dbo.ErTilknyttets", "AdresseId", c => c.Int());
            AddPrimaryKey("dbo.ErTilknyttets", "Type");
            RenameColumn(table: "dbo.ErTilknyttets", name: "KontaktId", newName: "Kontakt_Id");
            RenameColumn(table: "dbo.ErTilknyttets", name: "AdresseId", newName: "Adresse_Id");
            CreateIndex("dbo.ErTilknyttets", "Kontakt_Id");
            CreateIndex("dbo.ErTilknyttets", "Adresse_Id");
            AddForeignKey("dbo.ErTilknyttets", "Kontakt_Id", "dbo.Kontakts", "Id");
            AddForeignKey("dbo.ErTilknyttets", "Adresse_Id", "dbo.Adresses", "Id");
        }
    }
}
