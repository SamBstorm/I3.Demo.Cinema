using System;
using System.Collections.Generic;
using System.Data;
using e = Demo.Cinema.DAL.Entities;
using System.Text;

namespace Demo.Cinema.DAL.Handlers
{
    public static class Mapper
    {
        public static e.Cinema convert(IDataRecord record) {
            if (record is null) return null;
            return new e.Cinema
            {
                Id = (int)record[nameof(e.Cinema.Id)],
                Nom = (string)record[nameof(e.Cinema.Nom)],
                Ville = (string)record[nameof(e.Cinema.Ville)]
            };
        }
    }
    /// <summary>
    /// Si une colone est nullable, il faut faire un test de sa nullité avant de l'envoyer dans le DTO
    /// </summary>
    // DateDiffusion = (record[nameof(e.Diffusion.DateDiffusion)] is DBNull)? null :(DateTime?)record[nameof(e.Diffusion.DateDiffusion)],
}
