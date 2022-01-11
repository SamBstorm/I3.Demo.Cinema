using System;

namespace Demo.CinemaProject.BLL.Entities
{
    public class Diffusion
    {
        public int Id { get; set; }
        public DateTime DateDiffusion { get; set; }
        public int Cinema_Id { get; set; } 
        public int Film_Id { get; set; }
        public Cinema Cinema { get; set; }
        public Film Film { get; set; }

        public Diffusion(int id, DateTime dateDiff, Cinema cinema, Film film)
        {
            Id = id;
            DateDiffusion = dateDiff;
            Cinema = cinema;
            if (cinema == null) throw new ArgumentNullException(nameof(Cinema_Id));
            Cinema_Id = cinema.Id;
            Film = film;
            if (film == null) throw new ArgumentNullException(nameof(Film_Id));
            Film_Id = film.Id;
        }
        public Diffusion(int id, DateTime dateDiff, int cinema_id, int film_id)
        {
            Id= id;
            DateDiffusion= dateDiff;
            Cinema_Id = cinema_id;
            Film_Id = film_id;
            Cinema = null; 
            Film = null;
        }
    }
}