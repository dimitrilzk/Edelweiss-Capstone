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

        [Required]
        [StringLength(19)]
        public string NumeroCarta { get; set; }

        [Required]
        [StringLength(50)]
        public string Scadenza { get; set; }

        [Required]
        [StringLength(3)]
        public string CodiceCVV { get; set; }

        public int IdPacchetto { get; set; }

        [Column(TypeName = "money")]
        public decimal PrezzoAcquisto { get; set; }

        //[Required]
        [StringLength(50)]
        public string NomePacchetto { get; set; }

        public virtual Pacchetti Pacchetti { get; set; }
    }
}
