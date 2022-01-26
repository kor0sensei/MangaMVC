using MangaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaMVC.Repositories
{
    public interface IMangaRepository
    {
        List<Manga> GetAllManga();
    }
}
