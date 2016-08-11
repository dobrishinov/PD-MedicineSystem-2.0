namespace WebTakManager.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using PD_Medicine.Controllers;
    using PD_Medicine.Models;
    using PD_Medicine.ViewModels.DoctorAppointments;
    using System.Web.Mvc;
    using System;
    using PD_Medicine.ViewModels.Appointments;
    using System.Collections.Generic;
    using System.Linq;
    using PD_Medicine.ViewModels;
    public class DoctorsAppointmentsManagerController : BaseController<AppointmentEntity, DoctorAppointmentsEditVM, DoctorAppointmentsListVM>
    {
        public override BaseRepository<AppointmentEntity> CreateRepository()
        {
            return new AppointmentsRepository();
        }

        public override ActionResult RedirectTo(AppointmentEntity entity)
        {
            return RedirectToAction("Index", "DoctorsAppointmentsManager");
        }

        public override void PopulateEntity(AppointmentEntity entity, DoctorAppointmentsEditVM model)
        {
            if (entity.UserId <= 0)
            {
                entity.UserId = AuthenticationManager.LoggedUser.Id;
                entity.DoctorId = model.DoctorId;
                entity.Symptoms = model.Symptoms;
                entity.DateHour = DateTime.Now;
                entity.Status = false;
            }
            else
            {
                entity.UserId = model.UserId;
                entity.DoctorId = model.DoctorId;
                entity.Symptoms = model.Symptoms;
                entity.DateHour = DateTime.Now;
                entity.Status = model.Status;
            }
        }

        public override void PopulateModel(DoctorAppointmentsEditVM model, AppointmentEntity entity)
        {
            model.Id = entity.Id;
            model.UserId = entity.UserId;
            model.Symptoms = entity.Symptoms;
            model.DateHour = entity.DateHour;
            model.Status = false;

            DoctorsRepository doctorRepo = new DoctorsRepository();
            List<DoctorEntity> doctorlist = doctorRepo.GetAll().ToList();
            
            model.DoctorId = entity.DoctorId;
        }

        public ActionResult Events()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            DoctorAppointmentsListVM model = new DoctorAppointmentsListVM();
            model.Pager = new Pager();
            TryUpdateModel(model);

            string action = this.ControllerContext.RouteData.Values["action"].ToString();
            string controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            //t => t.CreatorId == AuthenticationManager.LoggedUser.Id|| t.ResponsibleUsers == AuthenticationManager.LoggedUser.Id

            model.Items = Repository.GetAll(CreateFilter(), model.Pager.CurrentPage, model.Pager.PageSize).ToList();
            model.Pager = new Pager(Repository.GetAll(CreateFilter()).Count(), model.Pager.CurrentPage, "Pager.", action, controller, model.Pager.PageSize);

            return View(model);
        }
    }

    

    //public class DoctorsAppointmentsManagerController : Controller
    //{
    //    public ActionResult Index()
    //    {
    //        if (AuthenticationManager.LoggedUser == null)
    //            return RedirectToAction("Login", "Home");

    //        AppointmentsRepository appointmentsRepository = new AppointmentsRepository();
    //        ViewData["appointments"] = appointmentsRepository.GetAll(t => t.DoctorId == AuthenticationManager.LoggedUser.Id);

    //        return View();
    //    }

    //    public ActionResult Events()
    //    {
    //        if (AuthenticationManager.LoggedUser == null)
    //            return RedirectToAction("Login", "Home");

    //        AppointmentsRepository appointmentsRepository = new AppointmentsRepository();
    //        ViewData["appointments"] = appointmentsRepository.GetAll(t => t.DoctorId == AuthenticationManager.LoggedUser.Id);

    //        return View();
    //    }

    //    [HttpGet]
    //    public ActionResult EditAppointment(int? id)
    //    {
    //        if (AuthenticationManager.LoggedUser == null)
    //            return RedirectToAction("Login", "Home");

    //        AppointmentsRepository AppointmentsRepository = new AppointmentsRepository();

    //        AppointmentEntity appointment = null;
    //        if (id == null)
    //            appointment = new AppointmentEntity();
    //        else
    //            appointment = AppointmentsRepository.GetById(id.Value);

    //        ViewData["appointment"] = appointment;

    //        return View();
    //    }
    //    [HttpPost]
    //    public ActionResult EditAppointment(AppointmentEntity appointment)
    //    {
    //        if (AuthenticationManager.LoggedUser == null)
    //            return RedirectToAction("Login", "Home");

    //        AppointmentsRepository appointmentsRepository = new AppointmentsRepository();
    //        appointmentsRepository.Save(appointment);

    //        return RedirectToAction("Index", "DoctorsAppointmentsManager");
    //    }

    //    public ActionResult DeleteAppointment(int id)
    //    {
    //        if (AuthenticationManager.LoggedUser == null)
    //            return RedirectToAction("Login", "Home");

    //        AppointmentsRepository appointmentsRepository = new AppointmentsRepository();
    //        AppointmentEntity appointment = appointmentsRepository.GetById(id);
    //        appointmentsRepository.Delete(appointment);

    //        return RedirectToAction("Index", "AppointmentsManager");
    //    }
    //}
}