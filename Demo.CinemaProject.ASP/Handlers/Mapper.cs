using Demo.CinemaProject.ASP.Models;
using Demo.CinemaProject.BLL.Entities;

namespace Demo.CinemaProject.ASP.Handlers
{
    public static class Mapper
    {
        public static CinemaListItem ToListItem(this Cinema entity)
        {
            if (entity == null) return null;
            return new CinemaListItem
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Ville = entity.Ville
            };
        }
        public static CinemaDetails ToDetails(this Cinema entity)
        {
            if (entity == null) return null;
            return new CinemaDetails
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Ville = entity.Ville
            };
        }

        public static DiffusionDetails ToDetails(this Diffusion entity)
        {
            if(entity == null) return null;
            return new DiffusionDetails
            {
                Id = entity.Id,
                DateDiffusion = entity.DateDiffusion,
                Film_Id = entity.Film.Id,
                Cinema_Id = entity.Cinema.Id,
                Titre = entity.Film.Titre
            };
        }
    }
}
