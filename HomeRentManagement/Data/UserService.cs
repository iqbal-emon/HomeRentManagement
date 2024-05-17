using HomeRentManagement.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

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
            return _dbContext.Users
    .Include(u => u.Role)
    .FirstOrDefault(x => x.Username == userName || x.Email == userName);


        }
        public async Task<List<User>> GetActiveMembersAsync()
        {
            return await _dbContext.Users
                .Where(u => u.Role.Title != "admin").Include(user=> user.Status) // Exclude admin users and inactive users
                .ToListAsync();
        }

        public async Task AddOwner(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserByIdAsync(int userId)
        {
            var memberToDelete = await _dbContext.Users.FindAsync(userId);

            if (memberToDelete != null)
            {
                // Update the StatusId here
                memberToDelete.StatusId = 3;

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<User> GetMemberByIdAsync(int memberId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(m => m.UserId == memberId);
        }

        public async Task updatedateUser(User updateUser)
        {
            var existingUser = await _dbContext.Users.FindAsync(updateUser.UserId);

            if (existingUser != null)
            {
                // Update the properties of the existing member with the new values
                existingUser.Username = updateUser.Username;
                existingUser.Password = updateUser.Password;
                existingUser.Email = updateUser.Email;
                existingUser.Phone = updateUser.Phone;
                existingUser.Address = updateUser.Address;
                existingUser.StatusId = updateUser.StatusId;

                // Use UpdateAsync instead of Update
                _dbContext.Users.Update(existingUser);
                // Save the changes to the database
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Member not found");
            }
        }
        public async Task<List<Status>> GetStatusOptionsAsync()
        {
            return await _dbContext.Statuss.ToListAsync();
        }

    }
}
