using Microsoft.AspNetCore.Mvc;
using MangaMVC.Repositories;
using MangaMVC.Models;
using System;
using System.Security.Claims;

namespace MangaMVC.Controllers
{
    public class MangaReadListController : Controller
    {

        private readonly IMangaReadListRepository _mangaReadListRepository;
        public MangaReadListController(IMangaReadListRepository mangaReadListRepository)
        {
            _mangaReadListRepository = mangaReadListRepository;
        }
        public ActionResult Index()
        {
            int userProfileId = GetCurrentUserProfileId();
            var mangaReadList = _mangaReadListRepository.GetAllUserMangaReadList(userProfileId);

            return View(mangaReadList);
        }
        public int GetCurrentUserProfileId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
