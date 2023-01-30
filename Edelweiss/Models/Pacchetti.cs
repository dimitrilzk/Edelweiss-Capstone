namespace Edelweiss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pacchetti")]
    public partial class Pacchetti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pacchetti()
        {
            Ordini = new HashSet<Ordini>();
        }

        [Key]
        public int IdPacchetto { get; set; }

        [Column(TypeName = "money")]
        public decimal? PrezzoScontato { get; set; }

        [Column(TypeName = "money")]
        public decimal PrezzoEffettivo { get; set; }

        [Required]
        public string Descrizione { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordini> Ordini { get; set; }
    }
}
