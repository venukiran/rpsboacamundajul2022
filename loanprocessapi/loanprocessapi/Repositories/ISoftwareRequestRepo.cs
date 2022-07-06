using loanprocessapi.Models;

namespace loanprocessapi.Repositories
{
    public interface ISoftwareRequestRepo
    {
        Task<SoftwareRequest> AddSoftwareReuest(SoftwareRequest SoftwareRequest);
        Task<bool> RemoveSoftwareReuest(long SoftwareRequestId);

        Task<SoftwareRequest> GetSoftwareRequestById(long SoftwareRequestId);
        Task<IEnumerable<SoftwareRequest>> GetSoftwareRequests();
    }
}
