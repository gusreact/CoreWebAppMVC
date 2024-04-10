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
        private IWebHostEnvironment _hosting;
        public HomeController(ILogger<HomeController> logger,
            IFriendRepository friendRepository,
            IWebHostEnvironment hosting)
        {
            _logger = logger;
            _friendRepository = friendRepository;
            _hosting = hosting;
        }

        [Route("Home/Details/{id?}")]
        public IActionResult Details(int? id)
        {
            DetailFriendView details = new DetailFriendView();
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
        public IActionResult Create([FromForm] CreateFriendView friend)
        {
            if (ModelState.IsValid)
            {
                string guidImage = null;
                if (friend.ImagePath != null)
                {
                    string imagesFolder = Path.Combine(_hosting.WebRootPath, "images");
                    guidImage = Guid.NewGuid().ToString() + friend.ImagePath.FileName;
                    string rootStore = Path.Combine(imagesFolder, guidImage);
                    friend.ImagePath.CopyTo(new FileStream(rootStore, FileMode.Create));
                }

                Friend friendCreated = new Friend();
                friendCreated.Id = friend.Id;
                friendCreated.Name = friend.Name;
                friendCreated.Email = friend.Email;
                friendCreated.Skill = friend.Skill;
                friendCreated.ImagePath = guidImage;
                _friendRepository.Create(friendCreated);
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
