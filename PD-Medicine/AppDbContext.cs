namespace PD_Medicine
{
    using DataAccess.Entity;
    using System.Data.Entity;

    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("PD_MedicineDb")
        {
        }

        public DbSet<AppointmentEntity> Appointments { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }
    }
}