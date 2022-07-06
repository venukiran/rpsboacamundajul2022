using loanprocessapi.Contexts;
using loanprocessapi.Models;
using Microsoft.EntityFrameworkCore;

namespace loanprocessapi.Repositories
{
    public class SoftwareRequestRepo : ISoftwareRequestRepo
    {
        private SoftwareRequestContext _dbContext;

        public SoftwareRequestRepo(SoftwareRequestContext context)
        {
            _dbContext = context;
        }

        
        public async Task<SoftwareRequest> AddSoftwareReuest(SoftwareRequest SoftwareRequest)
        {
            var result = await this._dbContext.swrequests.AddAsync(SoftwareRequest);

            await this._dbContext.SaveChangesAsync();

            return result.Entity;

        }

        public async Task<SoftwareRequest> GetSoftwareRequestById(long SoftwareRequestId)
        {
            var result = await this._dbContext.swrequests
                .FirstOrDefaultAsync(sw => sw.SoftwareId == SoftwareRequestId);
            if (result == null)
                return null;
            else
                return result;
        }

        public async Task<IEnumerable<SoftwareRequest>> GetSoftwareRequests()
        {
            return await this._dbContext.swrequests.ToListAsync();
        }

        public async Task<bool> RemoveSoftwareReuest(long SoftwareRequestId)
        {
            var result = await this._dbContext.swrequests
                .FirstOrDefaultAsync(sw => sw.SoftwareId
           == SoftwareRequestId);
            if (result != null)
            {
                this._dbContext.swrequests.Remove(result);
                await this._dbContext.SaveChangesAsync();
            }
            result = await this._dbContext.swrequests
                .FirstOrDefaultAsync(sw => sw.SoftwareId == SoftwareRequestId);
            if (result == null)
                return true;
            else
                return false;
        }
    }
}
