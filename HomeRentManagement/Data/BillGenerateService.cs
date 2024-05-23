using Microsoft.EntityFrameworkCore;

namespace HomeRentManagement.Data
{
    public class BillGenerateService
    {
        private readonly addDbContex _dbContext;

        public BillGenerateService(addDbContex dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BillGenerate>> GetAllBill(int userId)
        {
            return await _dbContext.BillGenerates.Include(bill => bill.Tenant.Unit).Where(bill=>bill.Tenant.OwnerId == userId).ToListAsync();
        }
        public async Task AddBill(BillGenerate billgenrate,int unitId)
         {

            var tenantTo = await _dbContext.Tenants.FirstOrDefaultAsync(tenant => tenant.UnitID == unitId);
            billgenrate.TenantID = tenantTo.TenantID;
            billgenrate.TotalRent = (billgenrate.ElectricityBill + billgenrate.GasBill + billgenrate.ServiceCharge + tenantTo.Unit.Rent);
            _dbContext.BillGenerates.Add(billgenrate);
            await _dbContext.SaveChangesAsync();
        }

        
             public async Task<List<Unit>> GetBillOptionsAsync(int userId)
        {
            return await _dbContext.Units.Where(unit=>unit.OwnerId==userId).ToListAsync();
        }
        public async Task<bool> deleteAsync(int BillToDelete)
        {
            var billTo = await _dbContext.BillGenerates.FindAsync(BillToDelete);

            if (billTo != null)
            {
                // Update the StatusId here
                billTo.StatusId = 3;
                _dbContext.BillGenerates.Update(billTo);
                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<BillGenerate> GetBillById(int billId)
        {
            return await _dbContext.BillGenerates.FirstOrDefaultAsync(h => h.BillingID == billId);
        }
        public async Task updatedateBill(BillGenerate updateBill,int UnitId)
        {
            var tenantTo = await _dbContext.Tenants.FirstOrDefaultAsync(tenant => tenant.UnitID == UnitId);
            var existingBill = await _dbContext.BillGenerates.FindAsync(updateBill.BillingID);
           

            if (existingBill != null)
            {
                // Update the properties of the existing member with the new values
                existingBill.ElectricityBill = updateBill.ElectricityBill;
                existingBill.GasBill = updateBill.GasBill;
                existingBill.ServiceCharge = updateBill.ServiceCharge;
                existingBill.TenantID = tenantTo.TenantID;
                existingBill.StatusId = updateBill.StatusId;
               existingBill.TotalRent=(updateBill.ElectricityBill+updateBill.GasBill+updateBill.ServiceCharge+tenantTo.Unit.Rent);




                // Use UpdateAsync instead of Update
                _dbContext.BillGenerates.Update(existingBill);
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
