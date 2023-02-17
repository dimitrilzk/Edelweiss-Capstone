namespace Edelweiss.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDettagli : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacchetti", "Dettaglio1", c => c.String());
            AddColumn("dbo.Pacchetti", "Dettaglio2", c => c.String());
            AddColumn("dbo.Pacchetti", "Dettaglio3", c => c.String());
            AddColumn("dbo.Pacchetti", "Dettaglio4", c => c.String());
            AddColumn("dbo.Pacchetti", "Dettaglio5", c => c.String());
            AddColumn("dbo.Pacchetti", "Dettaglio6", c => c.String());
            DropColumn("dbo.Pacchetti", "Obiettivo1");
            DropColumn("dbo.Pacchetti", "Obiettivo2");
            DropColumn("dbo.Pacchetti", "Obiettivo3");
            DropColumn("dbo.Pacchetti", "Obiettivo4");
            DropColumn("dbo.Pacchetti", "Obiettivo5");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pacchetti", "Obiettivo5", c => c.String());
            AddColumn("dbo.Pacchetti", "Obiettivo4", c => c.String());
            AddColumn("dbo.Pacchetti", "Obiettivo3", c => c.String());
            AddColumn("dbo.Pacchetti", "Obiettivo2", c => c.String());
            AddColumn("dbo.Pacchetti", "Obiettivo1", c => c.String());
            DropColumn("dbo.Pacchetti", "Dettaglio6");
            DropColumn("dbo.Pacchetti", "Dettaglio5");
            DropColumn("dbo.Pacchetti", "Dettaglio4");
            DropColumn("dbo.Pacchetti", "Dettaglio3");
            DropColumn("dbo.Pacchetti", "Dettaglio2");
            DropColumn("dbo.Pacchetti", "Dettaglio1");
        }
    }
}
