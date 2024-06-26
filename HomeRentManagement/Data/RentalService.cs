﻿using Microsoft.EntityFrameworkCore;

namespace HomeRentManagement.Data
{
    public class RentalService
    {
        private readonly addDbContex _dbContext;

        public RentalService(addDbContex dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Rental>> GetAllRent(int userId)
        {
            return await _dbContext.Rentals.Include(rental =>rental.Tenant.Unit).Where(rental =>rental.Tenant.OwnerId == userId).ToListAsync();
        }

        


             public async Task<List<BillGenerate>> GetTotal(int userId)
        {
            return await _dbContext.BillGenerates.Where(rental => rental.Tenant.OwnerId == userId).ToListAsync();
        }
        public async Task AddRental(Rental rent, int tenant)
        {
  
            rent.TenantID = tenant;
            _dbContext.Rentals.Add(rent);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Tenant>> GetRentOptionsAsync(int userId)
        {
            return await _dbContext.Tenants.Where(tenant => tenant.OwnerId == userId && tenant.StatusId != 3).ToListAsync();
        }
        public async Task<bool> deleteAsync(int rentToDelete)
        {
            var billTo = await _dbContext.Rentals.FindAsync(rentToDelete);

            if (billTo != null)
            {
                // Update the StatusId here
                billTo.StatusId = 3;
                _dbContext.Rentals.Update(billTo);
                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<Rental> GetRentById(int rentId)
        {
            return await _dbContext.Rentals.FirstOrDefaultAsync(r => r.RentID == rentId);
        }
        public async Task updatedateRent(Rental updateRent,int newUnitId)
        {
            var tenantTo = await _dbContext.Tenants.FirstOrDefaultAsync(tenant => tenant.UnitID == newUnitId);
            var existingRent = await _dbContext.Rentals.FindAsync(updateRent.RentID);

            if (existingRent != null)
            {
                // Update the properties of the existing member with the new values
                existingRent.totalRent = updateRent.totalRent;
           existingRent.TenantID=updateRent.TenantID;
                existingRent.RentMont = updateRent.RentMont;


                existingRent.RentDate = updateRent.RentDate;
                
                

                // Use UpdateAsync instead of Update
                _dbContext.Rentals.Update(existingRent);
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
