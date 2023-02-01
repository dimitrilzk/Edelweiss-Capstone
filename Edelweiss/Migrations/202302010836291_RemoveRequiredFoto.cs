namespace Edelweiss.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredFoto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Collaboratori", "Foto", c => c.String(maxLength: 50));
            AlterColumn("dbo.Ordini", "NomePacchetto", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ordini", "NomePacchetto", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Collaboratori", "Foto", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
