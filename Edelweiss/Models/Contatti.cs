namespace Edelweiss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contatti")]
    public partial class Contatti
    {
        [Key]
        public int IdContatto { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Cognome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Cellulare { get; set; }

        [Required]
        public string Messaggio { get; set; }
    }
}
