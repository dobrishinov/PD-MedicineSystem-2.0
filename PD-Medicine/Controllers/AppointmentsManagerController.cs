namespace WebTakManager.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using PD_Medicine.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class AppointmentsManagerController : Controller
    {
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");
            DoctorsRepository doctorRepository = new DoctorsRepository();
            AppointmentsRepository appointmentsRepository = new AppointmentsRepository();
            var appointments = appointmentsRepository.GetAll(t => t.UserId == AuthenticationManager.LoggedUser.Id);
            foreach (var item in appointments)
            {
                item.DoctorUsername = doctorRepository.GetById(item.DoctorId).Username;
            }
            ViewData["appointments"] = appointments;

            return View();
        }

        [HttpGet]
        public ActionResult EditAppointment(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            AppointmentsRepository AppointmentsRepository = new AppointmentsRepository();

            AppointmentEntity appointment = null;
            if (id == null)
                appointment = new AppointmentEntity();
            else
                appointment = AppointmentsRepository.GetById(id.Value);

            appointment.UserId = AuthenticationManager.LoggedUser.Id;
            appointment.Username = AuthenticationManager.LoggedUser.Username;

            DoctorsRepository repo = new DoctorsRepository();

            List<DoctorEntity> docs = repo.GetAll().ToList();
            ViewData["appointment"] = appointment;
            var selectList = new List<SelectListItem>();
            foreach (var doc in docs)
            {
                selectList.Add(new SelectListItem
                {
                    Text = doc.FirstName + " " + doc.LastName + " - " + doc.DoctorType,
                    Value = doc.Id.ToString()
                });
            }

            ViewData["selectList"] = selectList;
            return View();
        }
        [HttpPost]
        public ActionResult EditAppointment(AppointmentEntity appointment)
        {
            if (AuthenticationManager.LoggedUser == null)
            return RedirectToAction("Login", "Home");

            appointment.DoctorId = Convert.ToInt32(Request.Form["doctor"]);
            AppointmentsRepository appointmentsRepository = new AppointmentsRepository();

            appointmentsRepository.Save(appointment);

            return RedirectToAction("Index", "AppointmentsManager");
        }

        public ActionResult DeleteAppointment(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            AppointmentsRepository appointmentsRepository = new AppointmentsRepository();
            AppointmentEntity appointment = appointmentsRepository.GetById(id);
            appointmentsRepository.Delete(appointment);

            return RedirectToAction("Index", "AppointmentsManager");
        }

        //public void GetDoctors()
        //{
        //    List<SelectListItem> list = new List<SelectListItem>();
        //    foreach (var users in )
        //    {
        //        list.Add(users.FirstName);
        //    }
        //}
    }
}