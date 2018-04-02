namespace HandIn21.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedAccordingToUML : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ErTilknyttets", "KontaktId", "dbo.Kontakts");
            DropIndex("dbo.ErTilknyttets", new[] { "KontaktId" });
            RenameColumn(table: "dbo.ErTilknyttets", name: "KontaktId", newName: "Kontakt_Id");
            DropPrimaryKey("dbo.ErTilknyttets");
            AlterColumn("dbo.ErTilknyttets", "Kontakt_Id", c => c.Int());
            AddPrimaryKey("dbo.ErTilknyttets", new[] { "AdresseId", "Type" });
            CreateIndex("dbo.ErTilknyttets", "Kontakt_Id");
            AddForeignKey("dbo.ErTilknyttets", "Kontakt_Id", "dbo.Kontakts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ErTilknyttets", "Kontakt_Id", "dbo.Kontakts");
            DropIndex("dbo.ErTilknyttets", new[] { "Kontakt_Id" });
            DropPrimaryKey("dbo.ErTilknyttets");
            AlterColumn("dbo.ErTilknyttets", "Kontakt_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ErTilknyttets", new[] { "KontaktId", "AdresseId", "Type" });
            RenameColumn(table: "dbo.ErTilknyttets", name: "Kontakt_Id", newName: "KontaktId");
            CreateIndex("dbo.ErTilknyttets", "KontaktId");
            AddForeignKey("dbo.ErTilknyttets", "KontaktId", "dbo.Kontakts", "Id", cascadeDelete: true);
        }
    }
}
