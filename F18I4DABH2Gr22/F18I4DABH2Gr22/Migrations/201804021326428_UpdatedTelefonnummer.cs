namespace HandIn21_Udvidet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTelefonnummer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Telefonnummers", "Nummer", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Telefonnummers", "Nummer", c => c.Int(nullable: false));
        }
    }
}
