namespace HandIn21_Udvidet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadedeletetelefonnummer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Telefonnummers", "KontaktId", "dbo.Kontakts");
            AddColumn("dbo.Telefonnummers", "Kontakt_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Telefonnummers", "Kontakt_Id");
            AddForeignKey("dbo.Telefonnummers", "Kontakt_Id", "dbo.Kontakts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefonnummers", "Kontakt_Id", "dbo.Kontakts");
            DropIndex("dbo.Telefonnummers", new[] { "Kontakt_Id" });
            DropColumn("dbo.Telefonnummers", "Kontakt_Id");
            AddForeignKey("dbo.Telefonnummers", "KontaktId", "dbo.Kontakts", "Id", cascadeDelete: true);
        }
    }
}
