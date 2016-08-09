namespace PD_Medicine.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Models;
    using System.Web.Mvc;

    public class RegistrationController : Controller
    {
        [HttpGet]
        public ActionResult Register(int? id)
        {
            UsersRepository usersRepository = new UsersRepository();

            UserEntity user = null;
            if (id == null)
                user = new UserEntity();
            else
                user = usersRepository.GetById(id.Value);

            ViewData["user"] = user;

            return View();
        }

        [HttpPost]
        public ActionResult Register(UserEntity user)
        {
            UsersRepository usersRepository = new UsersRepository();
            usersRepository.Save(user);

            return RedirectToAction("Login", "Home");
        }
    }
}