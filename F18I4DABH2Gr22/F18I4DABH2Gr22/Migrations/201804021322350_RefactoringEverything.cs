namespace HandIn21_Udvidet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoringEverything : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ErTilknyttets", "AdresseId", "dbo.Adresses");
            DropIndex("dbo.ErTilknyttets", new[] { "AdresseId" });
            RenameColumn(table: "dbo.ErTilknyttets", name: "AdresseId", newName: "Adresse_Id");
            DropPrimaryKey("dbo.ErTilknyttets");
            AddColumn("dbo.ErTilknyttets", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ErTilknyttets", "Adresse_Id", c => c.Int());
            AlterColumn("dbo.ErTilknyttets", "Type", c => c.String());
            AddPrimaryKey("dbo.ErTilknyttets", "Id");
            CreateIndex("dbo.ErTilknyttets", "Adresse_Id");
            AddForeignKey("dbo.ErTilknyttets", "Adresse_Id", "dbo.Adresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ErTilknyttets", "Adresse_Id", "dbo.Adresses");
            DropIndex("dbo.ErTilknyttets", new[] { "Adresse_Id" });
            DropPrimaryKey("dbo.ErTilknyttets");
            AlterColumn("dbo.ErTilknyttets", "Type", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ErTilknyttets", "Adresse_Id", c => c.Int(nullable: false));
            DropColumn("dbo.ErTilknyttets", "Id");
            AddPrimaryKey("dbo.ErTilknyttets", new[] { "AdresseId", "Type" });
            RenameColumn(table: "dbo.ErTilknyttets", name: "Adresse_Id", newName: "AdresseId");
            CreateIndex("dbo.ErTilknyttets", "AdresseId");
            AddForeignKey("dbo.ErTilknyttets", "AdresseId", "dbo.Adresses", "Id", cascadeDelete: true);
        }
    }
}
