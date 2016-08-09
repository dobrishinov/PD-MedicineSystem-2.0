namespace PD_Medicine.ViewModels.Appointments
{
    using DataAccess.Entity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public class AppointmentsEditVM : BaseEditVM
    {        
        public int UserId { get; set; }
        [Required]
        public string Symptoms { get; set; }
        [Required]
        public DateTime DateHour { get; set; }
        public bool Status { get; set; }


        [Display(Name = "Assignee:")]
        public int DoctorId { get; set; }

        public List<DoctorEntity> doctors;
        public IEnumerable<SelectListItem> DoctorsList
        {
            get
            {
                var allUsers = doctors.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Username
                });
                return allUsers;

            }
        }
    }
}