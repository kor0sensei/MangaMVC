using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MangaMVC.Models;

namespace MangaMVC.Repositories
{
    public class MangaRepository : BaseRepository, IMangaRepository
    {
        public MangaRepository(IConfiguration config) : base(config) { }
        public List<Manga> GetAllManga()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, Name, ReleaseYear, VolumeCount, ChapterCount FROM Manga";
                    var reader = cmd.ExecuteReader();

                    var manga = new List<Manga>();

                    while (reader.Read())
                    {
                        manga.Add(new Manga()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            ReleaseYear = reader.GetInt32(reader.GetOrdinal("ReleaseYear")),
                            VolumeCount = reader.GetInt32(reader.GetOrdinal("VolumeCount")),
                            ChapterCount = reader.GetInt32(reader.GetOrdinal("ChapterCount"))
                        });
                    }

                    reader.Close();

                    return manga;
                }
            }
        }
        public Manga GetMangaById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                       SELECT Manga.Id, Name, ReleaseYear, VolumeCount, ChapterCount
                       FROM Manga 
                       WHERE Manga.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Manga manga = new Manga
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            ReleaseYear = reader.GetInt32(reader.GetOrdinal("ReleaseYear")),
                            VolumeCount = reader.GetInt32(reader.GetOrdinal("VolumeCount")),
                            ChapterCount = reader.GetInt32(reader.GetOrdinal("ChapterCount"))
                        };


                        reader.Close();
                        return manga;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }
    }
}