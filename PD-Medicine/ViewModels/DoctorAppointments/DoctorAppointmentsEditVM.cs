namespace PD_Medicine.ViewModels.DoctorAppointments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class DoctorAppointmentsEditVM : BaseEditVM
    {
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        [Required]
        public string Symptoms { get; set; }
        [Required]
        public DateTime DateHour { get; set; }
        public bool Status { get; set; }

    }
}