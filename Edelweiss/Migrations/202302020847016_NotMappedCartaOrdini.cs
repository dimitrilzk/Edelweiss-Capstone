namespace Edelweiss.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotMappedCartaOrdini : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ordini", "DataAcquisto", c => c.DateTime(nullable: false));
            DropColumn("dbo.Ordini", "NumeroCarta");
            DropColumn("dbo.Ordini", "Scadenza");
            DropColumn("dbo.Ordini", "CodiceCVV");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ordini", "CodiceCVV", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.Ordini", "Scadenza", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Ordini", "NumeroCarta", c => c.String(nullable: false, maxLength: 19));
            DropColumn("dbo.Ordini", "DataAcquisto");
        }
    }
}
