using Demo.CinemaProject.Common.Repositories;
using Demo.CinemaProject.DAL.Entities;
using Demo.CinemaProject.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Demo.CinemaProject.DAL.Repositories
{
    public class DiffusionService : ServiceBase, IDiffusionRepository<Diffusion>
    {
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Diffusion] WHERE [Id] = @id";
                    //Parameters...
                    SqlParameter p_id = new SqlParameter("id", id);
                    command.Parameters.Add(p_id);
                    connection.Open();
                    //Choose Execution method
                    command.ExecuteNonQuery();
                }
            }
        }

        public Diffusion Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Id], [Cinema_Id], [Film_Id], [DateDiffusion] FROM [Diffusion] WHERE [Id] = @id";
                    //Parameters...
                    SqlParameter p_id = new SqlParameter("id", id);
                    command.Parameters.Add(p_id);
                    connection.Open();
                    //Choose Execution method
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToDiffusion(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Diffusion> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Id], [Cinema_Id], [Film_Id], [DateDiffusion] FROM [Diffusion]";
                    //Parameters...
                    connection.Open();
                    //Choose Execution method
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToDiffusion(reader);
                }
            }
        }

        public IEnumerable<Diffusion> Get(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Id], [Cinema_Id], [Film_Id], [DateDiffusion] FROM [Diffusion] WHERE [DateDiffusion]=@date";
                    //Parameters...
                    SqlParameter p_date = new SqlParameter("date", date);
                    command.Parameters.Add(p_date);
                    connection.Open();
                    //Choose Execution method
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToDiffusion(reader);
                }
            }
        }

        public IEnumerable<Diffusion> GetByCinemaId(int cinema_id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Id], [Cinema_Id], [Film_Id], [DateDiffusion] FROM [Diffusion] WHERE [Cinema_Id]=@cinema";
                    //Parameters...
                    SqlParameter p_cinema = new SqlParameter("cinema", cinema_id);
                    command.Parameters.Add(p_cinema);
                    connection.Open();
                    //Choose Execution method
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToDiffusion(reader);
                }
            }
        }

        public IEnumerable<Diffusion> GetByFilmId(int film_id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Id], [Cinema_Id], [Film_Id], [DateDiffusion] FROM [Diffusion] WHERE [Film_Id]=@film";
                    //Parameters...
                    SqlParameter p_film = new SqlParameter("film", film_id);
                    command.Parameters.Add(p_film);
                    connection.Open();
                    //Choose Execution method
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToDiffusion(reader);
                }
            }
        }

        public int Insert(Diffusion entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [Diffusion]([Cinema_Id], [Film_Id], [DateDiffusion]) OUTPUT [inserted].[Id] VALUES (@cinema, @film, @date)";
                    SqlParameter p_cinema = new SqlParameter("cinema", entity.Cinema_Id);
                    command.Parameters.Add(p_cinema);
                    SqlParameter p_film = new SqlParameter("film", entity.Film_Id);
                    command.Parameters.Add(p_film);
                    SqlParameter p_date = new SqlParameter("date", entity.DateDiffusion);
                    command.Parameters.Add(p_date);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Diffusion entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Diffusion] SET [Cinema_Id] = @cinema, [DateDiffusion] = @date, [Film_Id] = @film WHERE [Id] = @id";
                    //Parameters...
                    SqlParameter p_cinema = new SqlParameter("cinema", entity.Cinema_Id);
                    command.Parameters.Add(p_cinema);
                    SqlParameter p_film = new SqlParameter("film", entity.Film_Id);
                    command.Parameters.Add(p_film);
                    SqlParameter p_date = new SqlParameter("date", entity.DateDiffusion);
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
