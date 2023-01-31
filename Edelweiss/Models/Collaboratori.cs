namespace Edelweiss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Collaboratori")]
    public partial class Collaboratori
    {
        [Key]
        public int IdCollaboratore { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Cognome { get; set; }

        [Required]
        public string Mansione { get; set; }

        [Required]
        [StringLength(50)]
        public string Cellulare { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Foto { get; set; }
        [NotMapped]
        [Required]
        public HttpPostedFileBase FileFoto { get; set; }
    }
}
