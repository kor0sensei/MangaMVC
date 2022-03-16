using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaMVC.Models
{
    public class MangaReadList
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        //public UserProfile UserProfile { get; set; }
        public int MangaId { get; set; }
        public int UserChapterCount { get; set; }

    }
}
