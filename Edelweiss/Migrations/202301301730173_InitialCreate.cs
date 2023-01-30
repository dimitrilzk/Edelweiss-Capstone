namespace Edelweiss.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collaboratori",
                c => new
                    {
                        IdCollaboratore = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Cognome = c.String(nullable: false, maxLength: 50),
                        Mansione = c.String(nullable: false),
                        Cellulare = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Foto = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdCollaboratore);
            
            CreateTable(
                "dbo.Contatti",
                c => new
                    {
                        IdContatto = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Cognome = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Cellulare = c.String(nullable: false, maxLength: 50),
                        Messaggio = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdContatto);
            
            CreateTable(
                "dbo.Ordini",
                c => new
                    {
                        IdOrdine = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Cognome = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Cellulare = c.String(nullable: false, maxLength: 50),
                        NumeroCarta = c.String(nullable: false, maxLength: 19),
                        Scadenza = c.String(nullable: false, maxLength: 50),
                        CodiceCVV = c.String(nullable: false, maxLength: 3),
                        IdPacchetto = c.Int(nullable: false),
                        PrezzoAcquisto = c.Decimal(nullable: false, storeType: "money"),
                        NomePacchetto = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdOrdine)
                .ForeignKey("dbo.Pacchetti", t => t.IdPacchetto)
                .Index(t => t.IdPacchetto);
            
            CreateTable(
                "dbo.Pacchetti",
                c => new
                    {
                        IdPacchetto = c.Int(nullable: false, identity: true),
                        PrezzoScontato = c.Decimal(storeType: "money"),
                        PrezzoEffettivo = c.Decimal(nullable: false, storeType: "money"),
                        Descrizione = c.String(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdPacchetto);
            
            CreateTable(
                "dbo.Utenti",
                c => new
                    {
                        IdUtente = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        PasswordUtente = c.String(nullable: false, maxLength: 50),
                        Ruolo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdUtente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ordini", "IdPacchetto", "dbo.Pacchetti");
            DropIndex("dbo.Ordini", new[] { "IdPacchetto" });
            DropTable("dbo.Utenti");
            DropTable("dbo.Pacchetti");
            DropTable("dbo.Ordini");
            DropTable("dbo.Contatti");
            DropTable("dbo.Collaboratori");
        }
    }
}
