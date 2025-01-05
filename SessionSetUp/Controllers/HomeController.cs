using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionSetUp.models;
using SessionSetUp.Models;
using System.Diagnostics;
using System.Linq;

namespace SessionSetUp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MVCDBContext context;

        public HomeController(MVCDBContext context )
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {

            var StudentSession = HttpContext.Session.GetString("StudentSession");
            if (StudentSession != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(Student std)
        {
            var Myuser = context.Students.FirstOrDefault(X => X.Email == std.Email && X.Password == std.Password);
            if (Myuser != null)
            {
                HttpContext.Session.SetString("StudentSession", Myuser.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login Failed. Please check your email and password.";
                return View();
            }
        }

        public IActionResult Dashboard()
        {
            var StudentSession = HttpContext.Session.GetString("StudentSession");
            if (StudentSession != null)
            {
                ViewBag.StudentSession = StudentSession.ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Logout()
        {
            var StudentSession = HttpContext.Session.GetString("StudentSession");
            if (StudentSession != null)
            {
                HttpContext.Session.Remove("StudentSession");
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Student std)
        {
            if (ModelState.IsValid)
            {
                await context.Students.AddAsync(std);
                await context.SaveChangesAsync();
                TempData["Success"] = "New User Registered Successfully";
                return RedirectToAction("Login");

            }
            else
            {
                TempData["error"] = "Failed to Register.....";
                return RedirectToAction("Register");
            }
                 
        }

    }
}