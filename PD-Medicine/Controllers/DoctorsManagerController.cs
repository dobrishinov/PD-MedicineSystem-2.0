namespace PD_Medicine.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using Models;
    using System.Web.Mvc;
    using ViewModels.Doctors;
    using System;

    public class DoctorsManagerController : BaseController<DoctorEntity, DoctorsEditVM, DoctorsListVM>
    {
        public override BaseRepository<DoctorEntity> CreateRepository()
        {
            return new DoctorsRepository();
        }

        public override ActionResult RedirectTo(DoctorEntity entity)
        {
            return RedirectToAction("Index", "DoctorsManager", new { id = entity.Id });
        }

        public override void PopulateEntity(DoctorEntity entity, DoctorsEditVM model)
        {
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Username = model.Username;
            entity.Password = model.Password;
            entity.DoctorType = model.DoctorType;
            entity.Description = model.Description;
            entity.Address = model.Address;
            entity.Phone = model.Phone;
            entity.UserStatus = true;
        }

        public override void PopulateModel(DoctorsEditVM model, DoctorEntity entity)
        {
            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;
            model.Username = entity.Username;
            model.Password = entity.Password;
            model.DoctorType = entity.DoctorType;
            model.Description = entity.Description;
            model.Address = entity.Address;
            model.Phone = entity.Phone;
            model.UserStatus = entity.UserStatus;
        }
    }




    //public class DoctorsManagerController : Controller
    //{
    //    public ActionResult Index()
    //    {
    //        if (AuthenticationManager.LoggedUser == null)
    //            return RedirectToAction("Login", "Home");

    //        DoctorsRepository doctorsRepository = new DoctorsRepository();
    //        ViewData["doctors"] = doctorsRepository.GetAll();

    //        return View();
    //    }
    //    [HttpGet]
    //    public ActionResult EditDoctor(int? id)
    //    {
    //        if (AuthenticationManager.LoggedUser == null)
    //            return RedirectToAction("Login", "Home");

    //        DoctorsRepository doctorsRepository = new DoctorsRepository();

    //        DoctorEntity doctor = null;
    //        if (id == null)
    //            doctor = new DoctorEntity();
    //        else
    //            doctor = doctorsRepository.GetById(id.Value);

    //        ViewData["doctor"] = doctor;

    //        return View();
    //    }
    //    [HttpPost]
    //    public ActionResult EditDoctor(DoctorEntity doctor)
    //    {
    //        if (AuthenticationManager.LoggedUser == null)
    //            return RedirectToAction("Login", "Home");

    //        DoctorsRepository doctorRepository = new DoctorsRepository();
    //        doctorRepository.Save(doctor);

    //        return RedirectToAction("Index", "DoctorsManager");
    //    }

    //    public ActionResult DeleteDoctor(int id)
    //    {
    //        if (AuthenticationManager.LoggedUser == null)
    //            return RedirectToAction("Login", "Home");

    //        DoctorsRepository doctorRepository = new DoctorsRepository();
    //        DoctorEntity doctor = doctorRepository.GetById(id);
    //        doctorRepository.Delete(doctor);

    //        return RedirectToAction("Index", "DoctorsManager");
    //    }
    //}
}