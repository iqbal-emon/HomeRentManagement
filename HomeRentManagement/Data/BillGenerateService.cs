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
            _dbContext.BillGenerates.Add(billgenrate);
            await _dbContext.SaveChangesAsync();
        }

        
             public async Task<List<Unit>> GetBillOptionsAsync(int userId)
        {
            return await _dbContext.Units.Where(unit=>unit.OwnerId==userId).ToListAsync();
        }

    }
}
