using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using e = Demo.Cinema.DAL.Entities;

namespace Demo.Cinema.DAL.Repositories
{
    public class CinemaService : IRepository<e.Cinema, int>
    {
        private string _connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Demo.Cinema.Database;Integrated Security=True";

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

        public IEnumerable<e.Cinema> Get()
        {
            throw new NotImplementedException();
        }

        public e.Cinema Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(e.Cinema entity)
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

        public void Update(int id, e.Cinema entity)
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
