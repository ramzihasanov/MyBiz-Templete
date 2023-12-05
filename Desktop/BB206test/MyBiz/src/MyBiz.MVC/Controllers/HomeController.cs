using Microsoft.AspNetCore.Mvc;
using MyBiz.Core.Models;
using MyBiz.Data.DAL;
using MyBiz.MVC.ViewModel;
using System.Diagnostics;

namespace MyBiz.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel homeViewModels = new HomeViewModel()
            {
                Sliders = _context.Sliders.ToList(),
             

            };
            return View(homeViewModels);
        }





    }
}