using CoreWebAppMVC.Models;
using CoreWebAppMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreWebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IFriendRepository _friendRepository;
        public HomeController(ILogger<HomeController> logger, IFriendRepository friendRepository)
        {
            _logger = logger;
            _friendRepository = friendRepository;
        }

        [Route("Home/Details/{id?}")]
        public IActionResult Details(int? id)
        {
            DetailsView details = new DetailsView();
            //Is id si null, get friend with id 1
            details.Friend = _friendRepository.GetFriend(id?? 1);
            details.Title = "Friends list View Model";
            details.Subtitle = "XXXXXXXXXXX";
            return View(details);
        }

        public IActionResult Index()
        {
            return View(_friendRepository.GetAllFriends());
        }

        [Route("Home/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Friend friend)
        {
            if (ModelState.IsValid)
            {
                Friend friendCreated = _friendRepository.Create(friend);
                return RedirectToAction("details", new { id = friendCreated.Id });
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
