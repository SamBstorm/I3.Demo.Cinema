using B = Demo.CinemaProject.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using D = Demo.CinemaProject.DAL.Entities;

namespace Demo.CinemaProject.BLL.Handlers
{
    public static class Mapper
    {
        public static B.Cinema ToBLL(this D.Cinema entity)
        {
            if(entity == null) return null;
            return new B.Cinema(
                entity.Id,
                entity.Nom,
                entity.Ville
                );
        }

        public static D.Cinema ToDAL(this B.Cinema entity)
        {
            if(entity==null) return null;
            return new D.Cinema
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Ville = entity.Ville
            };
        }
        public static B.Film ToBLL(this D.Film entity)
        {
            if (entity == null) return null;
            return new B.Film(
                entity.Id,
                entity.Titre,
                entity.DateSortie
                );
        }
        public static D.Film ToDAL(this B.Film entity)
        {
            if (entity == null) return null;
            return new D.Film
            {
                Id =entity.Id,
                Titre =entity.Titre,
                DateSortie = entity.DateSortie
            };
        }

        public static B.Diffusion ToBLL(this D.Diffusion entity)
        {
            if( entity == null) return null;
            return new B.Diffusion(
                entity.Id,
                entity.DateDiffusion,
                entity.Cinema_Id,
                entity.Film_Id
                );
        }

        public static D.Diffusion ToDAL(this B.Diffusion entity)
        {
            if(entity == null) return null;
            return new D.Diffusion { 
                Id = entity.Id,
                DateDiffusion = entity.DateDiffusion,
                Cinema_Id = entity.Cinema.Id,
                Film_Id = entity.Film.Id
            };
        }
    }
}
