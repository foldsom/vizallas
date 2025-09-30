using System.ComponentModel.DataAnnotations;

namespace vizallas.Models
{
    public class Vizallas
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        public int VizallasErtek { get; set; }

        [Required]
        public string Varos { get; set; } = string.Empty;

        [Required]
        public string Folyo { get; set; } = string.Empty;
    }
}
