namespace PD_Medicine.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Models;
    using System.Web.Mvc;

    public class DoctorsManagerController : Controller
    {
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            DoctorsRepository doctorsRepository = new DoctorsRepository();
            ViewData["doctors"] = doctorsRepository.GetAll();

            return View();
        }
        [HttpGet]
        public ActionResult EditDoctor(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            DoctorsRepository doctorsRepository = new DoctorsRepository();

            DoctorEntity doctor = null;
            if (id == null)
                doctor = new DoctorEntity();
            else
                doctor = doctorsRepository.GetById(id.Value);

            ViewData["doctor"] = doctor;

            return View();
        }
        [HttpPost]
        public ActionResult EditDoctor(DoctorEntity doctor)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            DoctorsRepository doctorRepository = new DoctorsRepository();
            doctorRepository.Save(doctor);

            return RedirectToAction("Index", "DoctorsManager");
        }

        public ActionResult DeleteDoctor(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            DoctorsRepository doctorRepository = new DoctorsRepository();
            DoctorEntity doctor = doctorRepository.GetById(id);
            doctorRepository.Delete(doctor);

            return RedirectToAction("Index", "DoctorsManager");
        }
    }
}