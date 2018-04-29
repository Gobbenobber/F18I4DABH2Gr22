namespace HandIn21_Udvidet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteOnCasesTilknyttedeAdresser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ErTilknyttets", "Kontakt_Id", "dbo.Kontakts");
            DropIndex("dbo.ErTilknyttets", new[] { "Kontakt_Id" });
            AlterColumn("dbo.ErTilknyttets", "Kontakt_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ErTilknyttets", "Kontakt_Id");
            AddForeignKey("dbo.ErTilknyttets", "Kontakt_Id", "dbo.Kontakts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ErTilknyttets", "Kontakt_Id", "dbo.Kontakts");
            DropIndex("dbo.ErTilknyttets", new[] { "Kontakt_Id" });
            AlterColumn("dbo.ErTilknyttets", "Kontakt_Id", c => c.Int());
            CreateIndex("dbo.ErTilknyttets", "Kontakt_Id");
            AddForeignKey("dbo.ErTilknyttets", "Kontakt_Id", "dbo.Kontakts", "Id");
        }
    }
}
