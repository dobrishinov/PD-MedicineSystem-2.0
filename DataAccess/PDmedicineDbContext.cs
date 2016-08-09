namespace DataAccess
{
    using System.Data.Entity;

    public class PDmedicineDb<T> : DbContext where T : class
    {
        public PDmedicineDb() : base("PDmedicineDb")
        {
        }

        public DbSet<T> Items { get; set; }

    }
}