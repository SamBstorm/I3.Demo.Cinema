using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.CinemaProject.ASP.Models
{
    public class DiffusionDetails
    {
        [ScaffoldColumn(false)]
        [Key]
        public int Id { get; set; }
        [DisplayName("Date de diffusion")]
        [DataType("datetime-local")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        public DateTime DateDiffusion { get; set; }
        public string Titre { get; set; }
        [ScaffoldColumn(false)]
        public int Film_Id { get; set; }
        [ScaffoldColumn(false)]
        public int Cinema_Id { get; set; }
    }
}