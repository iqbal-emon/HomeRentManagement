using Microsoft.EntityFrameworkCore;

namespace HomeRentManagement.Data
{
    public class StatusService
    {
        private readonly addDbContex _dbContext;

        public StatusService(addDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Status>> GetStatus()
        {
            return await _dbContext.Statuss.ToListAsync();
        }

        public async Task AddStatus(Status status)
        {
            _dbContext.Statuss.Add(status);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> deleteAsync(int statusId)
        {
            var statusToDelete = await _dbContext.Statuss.FindAsync(statusId);

            if (statusToDelete != null)
            {
         
                 _dbContext.Statuss.Remove(statusToDelete);
                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<Status> GetStatusById(int statusId)
        {
            return await _dbContext.Statuss.FirstOrDefaultAsync(r => r.Id == statusId);
        }
        public async Task updatedateStatus(Status updateStatus)
        {
            var existingStatus = await _dbContext.Statuss.FindAsync(updateStatus.Id);

            if (existingStatus != null)
            {
                // Update the properties of the existing member with the new values
                existingStatus.Name = updateStatus.Name;
                existingStatus.ShorForm = updateStatus.ShorForm;
               
               

                // Use UpdateAsync instead of Update
                _dbContext.Statuss.Update(existingStatus);
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
