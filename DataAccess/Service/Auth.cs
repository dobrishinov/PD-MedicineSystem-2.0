namespace DataAccess.Service
{
    using System.Linq;
    using Repository;
    using Entity;

    public class Auth
    {
        public UserEntity LoggedUser { get; private set; }

        public void Authenticate(string username, string password)
        {
            UsersRepository usersRepository = new UsersRepository();
            LoggedUser = usersRepository.GetAll(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (LoggedUser == null)
            {
                DoctorsRepository doctorRepository = new DoctorsRepository();
                LoggedUser = doctorRepository.GetAll(u => u.Username == username && u.Password == password).FirstOrDefault();

            }
            if (LoggedUser == null)
            {
                AdminRepository adminRepository = new AdminRepository();
                LoggedUser = adminRepository.GetAll(u => u.Username == username && u.Password == password).FirstOrDefault();
            }
        }
    }
}