namespace HandIn21.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTelefonnummer : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Telefonnummers");
            DropColumn("dbo.Telefonnummers", "Nummer");

            AddColumn("dbo.Telefonnummers", "Nummer", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Telefonnummers", "Nummer");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Telefonnummers");
            DropColumn("dbo.Telefonnummers", "Nummer");

            AddColumn("dbo.Telefonnummers", "Nummer", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Telefonnummers", "Nummer");
        }
    }
}
