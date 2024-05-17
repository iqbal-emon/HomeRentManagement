using Microsoft.EntityFrameworkCore;

namespace HomeRentManagement.Data
{
    public class RoleService
    {
        private readonly addDbContex _dbContext;

        public RoleService(addDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Role>> GetRoles()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task AddRole(Role role)
        {
            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> deleteAsync(int roleId)
        {
            var roleToDelete = await _dbContext.Roles.FindAsync(roleId);

            if (roleToDelete != null)
            {
                // Update the StatusId here
                roleToDelete.StatusId = 3;
                 _dbContext.Roles.Update(roleToDelete);
                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<Role> GetRoleById(int roleId)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
        }
        public async Task updatedateRole(Role updateRole)
        {
            var existingRole = await _dbContext.Roles.FindAsync(updateRole.Id);

            if (existingRole != null)
            {
                // Update the properties of the existing member with the new values
                existingRole.Title = updateRole.Title;
                existingRole.ShortForm = updateRole.ShortForm;
                existingRole.StatusId = updateRole.StatusId;
               

                // Use UpdateAsync instead of Update
                _dbContext.Roles.Update(existingRole);
                // Save the changes to the database
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Member not found");
            }
        }

    }
}
