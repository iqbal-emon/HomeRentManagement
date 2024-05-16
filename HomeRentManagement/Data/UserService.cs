using HomeRentManagement.Data;

namespace HomeRentManagement.Data
{
    public class UserService
    {
        
            private readonly addDbContex _dbContext;

            public UserService(addDbContex dbContext)
            {
                _dbContext = dbContext;
            }
            public User? GetByUserName(string userName)
            {
            return _dbContext.Users.FirstOrDefault(x => x.Username == userName || x.Email == userName);

            }

    }
}
