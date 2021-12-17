using Demo.CinemaProject.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Demo.CinemaProject.DAL.Entities;

namespace Demo.CinemaProject.DAL.Repositories
{
    public class CinemaService : ServiceBase, ICinemaRepository
    {
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Cinema] WHERE [Id] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Cinema> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Id],[Nom],[Ville] FROM [Cinema]";
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToCinema(reader);
                }
            }
        }

        public Cinema Get(int id)
        {
            using(SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Id],[Nom],[Ville] FROM [Cinema] WHERE [Id] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToCinema(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Cinema> GetByDiffusion(int id_movie, DateTime DateDiffusion)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Cinema].[Id],[Nom],[Ville] FROM [Cinema] JOIN [Diffusion] ON [Cinema].[Id] = [Diffusion].[Cinema_Id] WHERE [Diffusion].[Film_Id] = @id_movie AND [Diffusion].[DateDiffusion] = @date";
                    SqlParameter p_id_movie = new SqlParameter() { ParameterName = "id_movie", Value = id_movie };
                    command.Parameters.Add(p_id_movie);
                    SqlParameter p_date = new SqlParameter() { ParameterName = "date", Value = DateDiffusion };
                    command.Parameters.Add(p_date);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToCinema(reader);
                }
            }
        }

        public IEnumerable<Cinema> GetByFilm(int id_movie)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Cinema].[Id],[Nom],[Ville] FROM [Cinema] JOIN [Diffusion] ON [Cinema].[Id] = [Diffusion].[Cinema_Id] WHERE [Diffusion].[Film_Id] = @id_movie";
                    SqlParameter p_id_movie = new SqlParameter() { ParameterName = "id_movie", Value = id_movie };
                    command.Parameters.Add(p_id_movie);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToCinema(reader);
                }
            }
        }

        public int Insert(Cinema entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [Cinema]([Nom], [Ville]) OUTPUT [inserted].[Id] VALUES (@nom, @ville)";
                    SqlParameter p_nom = new SqlParameter { ParameterName = "nom", Value = entity.Nom };
                    SqlParameter p_ville = new SqlParameter { ParameterName = "ville", Value = entity.Ville };
                    command.Parameters.Add(p_nom);
                    command.Parameters.Add(p_ville);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Cinema entity)
        {
            using(SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Cinema] SET [Nom] = @nom, [Ville] = @ville WHERE [Id] = @id";
                    SqlParameter p_nom = new SqlParameter { ParameterName = "nom", Value = entity.Nom };
                    SqlParameter p_ville = new SqlParameter { ParameterName = "ville", Value = entity.Ville };
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_nom);
                    command.Parameters.Add(p_ville);
                    command.Parameters.Add(p_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
