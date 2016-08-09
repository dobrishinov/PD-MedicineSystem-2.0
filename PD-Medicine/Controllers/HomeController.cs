namespace PD_Medicine.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using PD_Medicine.Models;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            AuthenticationManager.Authenticate(username, password);

            if (AuthenticationManager.LoggedUser == null)
            {
                ModelState.AddModelError("authenticationFailed", "Wrong username or password!");
                ViewData["username"] = username;

                return View();
            }

            

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            if (AuthenticationManager.LoggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }

            AuthenticationManager.Logout();

            return RedirectToAction("Login", "Home");
        }

        public ActionResult FakeAdmin()
        {
            AdminRepository arepo = new AdminRepository();
            AdminEntity a = new AdminEntity();
            a.Username = "admin";
            a.Password = "admin";
            a.LastName = "admin";
            a.FirstName = "admin";
            a.UserStatus = true;
            a.Admin = "admin";
            arepo.Save(a);
            return View();
        }

        public ActionResult FakeUser()
        {
            UsersRepository urepo = new UsersRepository();
            UserEntity u = new UserEntity();
            u.Username = "user";
            u.Password = "user";
            u.LastName = "user";
            u.FirstName = "user";
            u.UserStatus = false;
            urepo.Save(u);
            return View();
        }

        public ActionResult FakeDoctor()
        {
            DoctorsRepository drepo = new DoctorsRepository();
            DoctorEntity d = new DoctorEntity();
            d.Username = "doctor";
            d.Password = "doctor";
            d.LastName = "doctor";
            d.FirstName = "doctor";
            d.DoctorType = "Some Type";
            d.Description = "Best Doctor";
            d.Address = "Plovdiv";
            d.Phone = "Phone";
            d.UserStatus = true;
            drepo.Save(d);
            return View();
        }
    }
}