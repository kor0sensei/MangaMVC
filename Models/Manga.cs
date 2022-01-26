using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaMVC.Models
{
    public class Manga
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int VolumeCount { get; set; }
        public int ChapterCount { get; set; }
    }
}
