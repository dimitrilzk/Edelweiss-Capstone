namespace Edelweiss.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddObiettivi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacchetti", "Obiettivo1", c => c.String());
            AddColumn("dbo.Pacchetti", "Obiettivo2", c => c.String());
            AddColumn("dbo.Pacchetti", "Obiettivo3", c => c.String());
            AddColumn("dbo.Pacchetti", "Obiettivo4", c => c.String());
            AddColumn("dbo.Pacchetti", "Obiettivo5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pacchetti", "Obiettivo5");
            DropColumn("dbo.Pacchetti", "Obiettivo4");
            DropColumn("dbo.Pacchetti", "Obiettivo3");
            DropColumn("dbo.Pacchetti", "Obiettivo2");
            DropColumn("dbo.Pacchetti", "Obiettivo1");
        }
    }
}
