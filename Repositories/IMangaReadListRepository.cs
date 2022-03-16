using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangaMVC.Models;

namespace MangaMVC.Repositories
{
   public interface IMangaReadListRepository
    {
        List<MangaReadList> GetAllUserMangaReadList(int id);
    }
}
