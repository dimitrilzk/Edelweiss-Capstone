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

        public static List<PacchettoAcquistato> ListaPacchetti = new List<PacchettoAcquistato>();
    }
}