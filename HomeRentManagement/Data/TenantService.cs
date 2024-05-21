using Microsoft.EntityFrameworkCore;

namespace HomeRentManagement.Data
{
    public class TenantService
    {
        private readonly addDbContex _dbContext;

        public TenantService(addDbContex dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Tenant>> GetTeant(int userId)
        {
            return await _dbContext.Tenants.Include(tenant => tenant.Status).Include(Tenant=>Tenant.Unit).Where(tenant => tenant.OwnerId == userId).ToListAsync();
        }


        public async Task AddTenant(Tenant tenant)
        {
            _dbContext.Tenants.Add(tenant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> deleteAsync(int tenantToDelete)
        {
            var tenantTo = await _dbContext.Tenants.FindAsync(tenantToDelete);

            if (tenantTo != null)
            {
                // Update the StatusId here
                tenantTo.StatusId = 3;
                _dbContext.Tenants.Update(tenantTo);
                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<Tenant> GetTenantById(int tenantId)
        {
            return await _dbContext.Tenants.FirstOrDefaultAsync(h => h.TenantID == tenantId);
        }
        public async Task updatedateTenant(Tenant updateTenant)
        {
            var existingTenant = await _dbContext.Tenants.FindAsync(updateTenant.TenantID);

            if (existingTenant != null)
            {
                // Update the properties of the existing member with the new values
                existingTenant.TenantName = updateTenant.TenantName;
                existingTenant.PhoneNumber = updateTenant.PhoneNumber;
                existingTenant.IdCardNumber = updateTenant.IdCardNumber;
                existingTenant.UnitID = updateTenant.UnitID;
               

                existingTenant.StatusId = updateTenant.StatusId;




                // Use UpdateAsync instead of Update
                _dbContext.Tenants.Update(existingTenant);
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
