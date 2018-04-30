namespace HandIn21_Udvidet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adresses", "By_Id", "dbo.Bies");
            DropForeignKey("dbo.ErTilknyttets", "Adresse_Id", "dbo.Adresses");
            DropIndex("dbo.Adresses", new[] { "By_Id" });
            DropIndex("dbo.ErTilknyttets", new[] { "Adresse_Id" });
            RenameColumn(table: "dbo.Adresses", name: "By_Id", newName: "ById");
            RenameColumn(table: "dbo.ErTilknyttets", name: "Adresse_Id", newName: "AdresseId");
            AlterColumn("dbo.Adresses", "ById", c => c.Int(nullable: false));
            AlterColumn("dbo.ErTilknyttets", "AdresseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Adresses", "ById");
            CreateIndex("dbo.ErTilknyttets", "AdresseId");
            AddForeignKey("dbo.Adresses", "ById", "dbo.Bies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ErTilknyttets", "AdresseId", "dbo.Adresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ErTilknyttets", "AdresseId", "dbo.Adresses");
            DropForeignKey("dbo.Adresses", "ById", "dbo.Bies");
            DropIndex("dbo.ErTilknyttets", new[] { "AdresseId" });
            DropIndex("dbo.Adresses", new[] { "ById" });
            AlterColumn("dbo.ErTilknyttets", "AdresseId", c => c.Int());
            AlterColumn("dbo.Adresses", "ById", c => c.Int());
            RenameColumn(table: "dbo.ErTilknyttets", name: "AdresseId", newName: "Adresse_Id");
            RenameColumn(table: "dbo.Adresses", name: "ById", newName: "By_Id");
            CreateIndex("dbo.ErTilknyttets", "Adresse_Id");
            CreateIndex("dbo.Adresses", "By_Id");
            AddForeignKey("dbo.ErTilknyttets", "Adresse_Id", "dbo.Adresses", "Id");
            AddForeignKey("dbo.Adresses", "By_Id", "dbo.Bies", "Id");
        }
    }
}
