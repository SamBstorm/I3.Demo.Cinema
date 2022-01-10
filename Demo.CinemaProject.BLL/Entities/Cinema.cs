using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.CinemaProject.BLL.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }
        public IEnumerable<Diffusion> Diffusions { get; set; }

        public Cinema(int id, string nom, string ville)
        {
            Id = id;
            Nom = nom;
            Ville = ville;
        }

        public void AddDiffusion(DateTime dateDiffusion, Film film)
        {
            throw new NotImplementedException();
        }

        public void CancelDiffusion(Diffusion diffusion)
        {
            throw new NotImplementedException();
        }
    }
}
