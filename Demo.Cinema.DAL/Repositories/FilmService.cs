using Demo.CinemaProject.Common.Repositories;
using Demo.CinemaProject.DAL.Entities;
using Demo.CinemaProject.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Demo.CinemaProject.DAL.Repositories
{
    public class FilmService : ServiceBase, IFilmRepository<Film>
    {
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Film] WHERE [Id] = @id";
                    //Parameters...
                    SqlParameter p_id = new SqlParameter("id", id);
                    command.Parameters.Add(p_id);
                    connection.Open();
                    //Choose Execution method
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Film> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Id], [Titre], [DateSortie] FROM [Film]";
                    //Parameters...
                    connection.Open();
                    //Choose Execution method
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToFilm(reader);
                }
            }
        }

        public Film Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Id], [Titre], [DateSortie] FROM [Film] WHERE [Id] = @id";
                    //Parameters...
                    SqlParameter p_id = new SqlParameter("id", id);
                    command.Parameters.Add(p_id);
                    connection.Open();
                    //Choose Execution method
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToFilm(reader);
                    return null;
                }
            }
        }

        public Film GetByDiffusionId(int diffusionId)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Film].[Id], [Titre], [DateSortie] FROM [Film] JOIN [Diffusion] ON [Film].[Id] = [Film_id] WHERE [Diffusion].[Id] = @id";
                    //Parameters...
                    SqlParameter p_id = new SqlParameter("id", diffusionId);
                    command.Parameters.Add(p_id);
                    connection.Open();
                    //Choose Execution method
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToFilm(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Film> GetByYear(int year)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Id], [Titre], [DateSortie] FROM [Film] WHERE YEAR([DateSortie]) = @year";
                    //Parameters...
                    SqlParameter p_year = new SqlParameter("year", year);
                    command.Parameters.Add(p_year);
                    connection.Open();
                    //Choose Execution method
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToFilm(reader);
                }
            }
        }

        public int Insert(Film entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_Film_Insert";
                    //Parameters...
                    SqlParameter p_titre = new SqlParameter("titre", entity.Titre);
                    command.Parameters.Add(p_titre);
                    SqlParameter p_date = new SqlParameter("date", entity.DateSortie);
                    command.Parameters.Add(p_date);
                    connection.Open();
                    //Choose Execution method
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Film entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Film] SET [Titre] = @titre, [DateSortie] = @date WHERE [Id] = @id";
                    //Parameters...
                    SqlParameter p_titre = new SqlParameter("titre", entity.Titre);
                    command.Parameters.Add(p_titre);
                    SqlParameter p_date = new SqlParameter("date", entity.DateSortie);
                    command.Parameters.Add(p_date);
                    SqlParameter p_id = new SqlParameter("id", id);
                    command.Parameters.Add(p_id);
                    connection.Open();
                    //Choose Execution method
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
