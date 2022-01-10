using System;

namespace Demo.CinemaProject.BLL.Entities
{
    public class Diffusion
    {
        public int Id { get; set; }
        public DateTime DateDiffusion { get; set; }
        //public int Cinema_Id { get; set; } 
        //public int Film_Id { get; set; }
        public Cinema Cinema { get; set; }
        public Film Film { get; set; }

        public Diffusion(int id, DateTime dateDiff, Cinema cinema, Film film)
        {
            Id = id;
            DateDiffusion = dateDiff;
            Cinema = cinema;
            Film = film;
        }
    }
}