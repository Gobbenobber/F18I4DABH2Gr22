namespace HandIn21.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rework : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Telefonnummers", "KontaktId", "dbo.Kontakts");
            DropIndex("dbo.Telefonnummers", new[] { "KontaktId" });
            DropColumn("dbo.Telefonnummers", "KontaktId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Telefonnummers", "KontaktId", c => c.Int(nullable: false));
            CreateIndex("dbo.Telefonnummers", "KontaktId");
            AddForeignKey("dbo.Telefonnummers", "KontaktId", "dbo.Kontakts", "Id", cascadeDelete: true);
        }
    }
}
