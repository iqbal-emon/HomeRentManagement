using Microsoft.EntityFrameworkCore;

namespace HomeRentManagement.Data
{
    public class UnitService
    {
        private readonly addDbContex _dbContext;

        public UnitService(addDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Unit>> GetUnit(int userId)
        {
            return await _dbContext.Units.Include(user => user.Status).Where(unit => unit.OwnerId == userId).ToListAsync();
        }
        public async Task<List<Unit>> GetUnitAllUnit(int userId,int houseId)
        {
            return await _dbContext.Units.Where(unit => unit.OwnerId == userId&&unit.HomeId== houseId).ToListAsync();
        }

        public async Task AddUnit(Unit unit,int newHome)
        {
            unit.HomeId = newHome;
            _dbContext.Units.Add(unit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> deleteAsync(int unitToDelete)
        {
            var unitTo = await _dbContext.Units.FindAsync(unitToDelete);

            if (unitTo != null)
            {
                // Update the StatusId here
                unitTo.StatusId = 3;
                _dbContext.Units.Update(unitTo);
                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<Unit> GetUnitById(int unitId)
        {
            return await _dbContext.Units.FirstOrDefaultAsync(h => h.UnitID == unitId);
        }
        public async Task<List<House>> getAllHouse(int userId)
        {
            return await _dbContext.Houses.Where(house=>house.OwnerId== userId).ToListAsync();
        }
        public async Task updatedateUnit(Unit updateUnit,int newHome)
        {
            var existingUnit = await _dbContext.Units.FindAsync(updateUnit.UnitID);

            if (existingUnit != null)
            {
                // Update the properties of the existing member with the new values
                existingUnit.unitName = updateUnit.unitName;
                existingUnit.BedRoom = updateUnit.BedRoom;
                existingUnit.WashRoom = updateUnit.WashRoom;
                existingUnit.BedRoom = updateUnit.BedRoom;
                existingUnit.Rent = updateUnit.Rent;
                existingUnit.HomeId = newHome;
                existingUnit.StatusId = updateUnit.StatusId;




                // Use UpdateAsync instead of Update
                _dbContext.Units.Update(existingUnit);
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

