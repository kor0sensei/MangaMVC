//using Microsoft.Data.SqlClient;
//using MangaMVC.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;

//namespace MangaMVC.Repositories
//{
//    public class UserProfileRepository : IUserProfileRepository
//    {

//        private readonly IConfiguration _config;

//        public UserProfileRepository(IConfiguration config)
//        {
//            _config = config;
//        }

//        public SqlConnection Connection
//        {
//            get
//            {
//                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
//            }
//        }

//        public UserProfile GetById(int id)
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                                    SELECT Id, Name, DisplayName, FirstName, LastName
//                                    FROM UserProfile
//                                    WHERE Id = @Id";

//                    cmd.Parameters.AddWithValue("@id", id);

//                    UserProfile userProfile = null;

//                    var reader = cmd.ExecuteReader();
//                    if (reader.Read())
//                    {
//                        userProfile = new UserProfile
//                        {
//                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
//                            Email = reader.GetString(reader.GetOrdinal("Name"))
//                        };
//                    }
//                    reader.Close();

//                    return userProfile;
//                }
//            }
//        }

//        public void Add(UserProfile userProfile)
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                                        INSERT INTO
//                                        UserProfile (Email, DisplayName, FirstName, LastName) 
//                                        OUTPUT INSERTED.ID
//                                        VALUES(@email, @displayName, @firstName, @lastName)";

//                    cmd.Parameters.AddWithValue("@email", userProfile.Email);
//                    cmd.Parameters.AddWithValue("@displayName", userProfile.DisplayName);
//                    cmd.Parameters.AddWithValue("@firstName", userProfile.FirstName);
//                    cmd.Parameters.AddWithValue("@lastName", userProfile.LastName);

//                    userProfile.Id = (int)cmd.ExecuteScalar();
//                }
//            }
//        }
//    }
//}
