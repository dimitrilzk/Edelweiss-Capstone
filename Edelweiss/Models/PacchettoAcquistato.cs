using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edelweiss.Models
{
    public class PacchettoAcquistato
    {
        public int IdPacchetto;
        public string Nome;
        public decimal Prezzo;
        public DateTime DataAcquisto;
        public string Dettaglio1;
        public string Dettaglio2;
        public string Dettaglio3;
        public string Dettaglio4;
        public string Dettaglio5;
        public string Dettaglio6;
        public static List<PacchettoAcquistato> ListaPacchetti = new List<PacchettoAcquistato>();
    }
}