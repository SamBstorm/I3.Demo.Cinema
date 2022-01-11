using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.CinemaProject.ASP.Models
{
    public class CinemaDetails
    {
        [ScaffoldColumn(false)]
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }

        public IEnumerable<DiffusionDetails> Diffusions { get; set; }
    }
}
