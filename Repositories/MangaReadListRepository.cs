using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MangaMVC.Models;

namespace MangaMVC.Repositories
{
    public class MangaReadListRepository : BaseRepository, IMangaReadListRepository
    {
        public MangaReadListRepository(IConfiguration config) : base(config) { }
        public List<MangaReadList> GetAllUserMangaReadList(int userProfileId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id, UserProfileId, MangaId, UserChapterCount
                                       FROM UserMangaReadList
                                       JOIN UserProfile ON UserProfileId = UserProfile.id
                                       WHERE MangaReadList.UserProfileId = @userProfileId";

                    cmd.Parameters.AddWithValue("@userProfileId", userProfileId);
                    var reader = cmd.ExecuteReader();

                    var mangaReadList = new List<MangaReadList>();

                    while (reader.Read())
                    {
                        mangaReadList.Add(new MangaReadList()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                            MangaId = reader.GetInt32(reader.GetOrdinal("MangaId")),
                            UserChapterCount = reader.GetInt32(reader.GetOrdinal("UserChapterCount"))
                        });
                    }

                    reader.Close();

                    return mangaReadList;
                }
            }
        }
    }
}