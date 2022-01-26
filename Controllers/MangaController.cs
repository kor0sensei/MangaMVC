using Microsoft.AspNetCore.Mvc;
using MangaMVC.Repositories;
using MangaMVC.Models;
using System;

namespace MangaMVC.Controllers
{
    public class MangaController : Controller
    {

        private readonly IMangaRepository _mangaRepository;
        public MangaController(IMangaRepository mangaRepository)
        {
            _mangaRepository = mangaRepository;
        }
        public ActionResult Index()
        {
            var mangas = _mangaRepository.GetAllManga();
            return View(mangas);
        }
    }
}
