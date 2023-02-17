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
        [Display(Name = "Prezzo Scontato")]
        [DataType(DataType.Currency)]
        public decimal? PrezzoScontato { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Prezzo Effettivo")]
        [DataType(DataType.Currency)]
        public decimal PrezzoEffettivo { get; set; }

        [Required]
        public string Descrizione { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Display(Name ="Dettaglio 1")]
        public string Dettaglio1 { get; set; }
        [Display(Name = "Dettaglio 2")]
        public string Dettaglio2 { get; set; }
        [Display(Name = "Dettaglio 3")]
        public string Dettaglio3 { get; set; }
        [Display(Name = "Dettaglio 4")]
        public string Dettaglio4 { get; set; }
        [Display(Name = "Dettaglio 5")]
        public string Dettaglio5 { get; set; }
        [Display(Name = "Dettaglio 6")]
        public string Dettaglio6 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordini> Ordini { get; set; }
    }
}
