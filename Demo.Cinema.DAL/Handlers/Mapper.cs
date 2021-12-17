using System;
using System.Collections.Generic;
using System.Data;
using Demo.CinemaProject.DAL.Entities;
using System.Text;

namespace Demo.CinemaProject.DAL.Handlers
{
    public static class Mapper
    {
        public static Cinema ToCinema(IDataRecord record)
        {
            if (record is null) return null;
            return new Cinema
            {
                Id = (int)record[nameof(Cinema.Id)],
                Nom = (string)record[nameof(Cinema.Nom)],
                Ville = (string)record[nameof(Cinema.Ville)]
            };
        }
        public static Film ToFilm(IDataRecord record)
        {
            if (record is null) return null;
            return new Film
            {
                Id = (int)record[nameof(Film.Id)],
                Titre = (string)record[nameof(Film.Titre)],
                DateSortie = (DateTime)record[nameof(Film.DateSortie)]
            };
        }
    }
    /// <summary>
    /// Si une colone est nullable, il faut faire un test de sa nullité avant de l'envoyer dans le DTO
    /// </summary>
    // DateDiffusion = (record[nameof(Diffusion.DateDiffusion)] is DBNull)? null :(DateTime?)record[nameof(Diffusion.DateDiffusion)],
}
