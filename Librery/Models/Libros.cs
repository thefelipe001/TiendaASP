namespace Librery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Libros
    {
        [Key]
        [Column(Order = 0)]
        public int codigo { get; set; }

        [StringLength(30)]
        public string titulo { get; set; }

        [StringLength(30)]
        public string autor { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte codigoeditorial { get; set; }

        public decimal? precio { get; set; }
    }
}
