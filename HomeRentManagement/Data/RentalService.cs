using Microsoft.EntityFrameworkCore;

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
            return await _dbContext.Rentals.Include(rental =>rental.Unit).Where(rental =>rental.Unit.OwnerId == userId).ToListAsync();
        }
        public async Task AddRental(Rental rent, int unitId)
        {

            
            rent.UnitID = unitId;
            _dbContext.Rentals.Add(rent);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Unit>> GetRentOptionsAsync(int userId)
        {
            return await _dbContext.Units.Where(unit => unit.OwnerId == userId).ToListAsync();
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
        public async Task updatedateRent(Rental updateRent)
        {
            var existingRent = await _dbContext.Rentals.FindAsync(updateRent.RentID);

            if (existingRent != null)
            {
                // Update the properties of the existing member with the new values
                existingRent.ElectricityBill = updateRent.ElectricityBill;
                existingRent.GasBill = updateRent.GasBill;
                existingRent.ServiceCharge = updateRent.ServiceCharge;
                existingRent.Rent = updateRent.Rent;

                existingRent.RentDate = updateRent.RentDate;

                existingRent.StatusId = updateRent.StatusId;




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
