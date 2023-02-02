namespace Edelweiss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [Key]
        public int IdOrdine { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Cognome { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Cellulare { get; set; }

        [NotMapped()]
        [StringLength(19)]
        public string NumeroCarta { get; set; }

        [NotMapped()]
        [StringLength(50)]
        public string Scadenza { get; set; }

        [NotMapped()]
        [StringLength(3)]
        public string CodiceCVV { get; set; }

        public int IdPacchetto { get; set; }

        [Column(TypeName = "money")]
        public decimal PrezzoAcquisto { get; set; }

        [StringLength(50)]
        public string NomePacchetto { get; set; }
        public DateTime DataAcquisto { get; set; }

        public virtual Pacchetti Pacchetti { get; set; }
    }
}
