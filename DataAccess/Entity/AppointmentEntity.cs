namespace DataAccess.Entity
{
    using System;

    public class AppointmentEntity : BaseEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int DoctorId { get; set; }
        public string DoctorUsername { get; set; }
        public string Symptoms { get; set; }
        public DateTime DateHour { get; set; }
        public bool Status { get; set; }
    }

    //public enum StatusEnum
    //{
    //    Pending,
    //    Approved,
    //    Unapproved
    //}
}
