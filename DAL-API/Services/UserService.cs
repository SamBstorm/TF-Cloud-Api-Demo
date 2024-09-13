using Common_API.Repositories;
using DAL_API.Entities;
using DAL_API.Mapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_API.Services
{
    public class UserService : BaseService, IUserRepository<User>
    {
        public UserService(IConfiguration config) : base(config, "Cloud-API")
        {
        }

        public Guid Insert(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand()) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_User_Insert";
                    command.Parameters.AddWithValue("email", user.Email);
                    command.Parameters.AddWithValue("password", user.Password);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }

        public Guid? Login(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_User_CheckEmailAndPassword";
                    command.Parameters.AddWithValue("email", user.Email);
                    command.Parameters.AddWithValue("password", user.Password);
                    connection.Open();
                    object id = command.ExecuteScalar();
                    return (id is DBNull)? null : (Guid?)id;
                }
            }
        }

        public void ChangePassword(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_User_ChangePassword";
                    command.Parameters.AddWithValue("id", user.UserId);
                    command.Parameters.AddWithValue("password", user.Password);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Disabled(Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_User_Disable";
                    command.Parameters.AddWithValue("id", userId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public User Get(Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [UserId],[Email], '********' AS [Password], [CreatedAt], [DisabledAt] FROM [User] WHERE [UserId] = @id";
                    command.Parameters.AddWithValue("id", userId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToUser();
                        }
                        throw new ArgumentOutOfRangeException(nameof(userId));
                    }
                }
            }
        }
        public IEnumerable<User> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [UserId],[Email], '********' AS [Password], [CreatedAt], [DisabledAt] FROM [User]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToUser();
                        }
                    }
                }
            }
        }
    }
}
