using Microsoft.EntityFrameworkCore;

namespace HomeRentManagement.Data
{
    public class HomeService
    {

        private readonly addDbContex _dbContext;

        public HomeService(addDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<House>> GetHouses(int userId)
        {
            return await _dbContext.Houses.Include(user => user.Status).Where(house => house.OwnerId == userId).ToListAsync();
        }


        public async Task AddHouse(House house)
        {
            _dbContext.Houses.Add(house);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> deleteAsync(int houseToDelete)
        {
            var houseTo = await _dbContext.Houses.FindAsync(houseToDelete);

            if (houseToDelete != null)
            {
                // Update the StatusId here
                houseTo.StatusId = 3;
                _dbContext.Houses.Update(houseTo);
                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<House> GetRoleById(int HouseId)
        {
            return await _dbContext.Houses.FirstOrDefaultAsync(h => h.HouseID == HouseId);
        }
        public async Task updatedateHouse(House updateHouse)
        {
            var existingHouse = await _dbContext.Houses.FindAsync(updateHouse.HouseID);

            if (existingHouse != null)
            {
                // Update the properties of the existing member with the new values
                existingHouse.HouseName = existingHouse.HouseName;
                existingHouse.HouseAddress = existingHouse.HouseAddress;
                existingHouse.StatusId = existingHouse.StatusId;


                // Use UpdateAsync instead of Update
                _dbContext.Houses.Update(existingHouse);
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
