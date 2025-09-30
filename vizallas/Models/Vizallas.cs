using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vizallas.Models
{
    public class Vizallas
    {
        public int Id { get; set; }

        [Display(Name = "Dátum")]
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        [Column("Vizallas")]
        [Display(Name = "Vízállás (cm)")]
        public int Ertek { get; set; }

        [Required, Display(Name = "Város")]
        public string Varos { get; set; } = string.Empty;

        [Required, Display(Name = "Folyó")]
        public string Folyo { get; set; } = string.Empty;
    }
}
