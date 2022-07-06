using loanprocessapi.Models;

namespace loanprocessapi.Repositories
{
    public interface ISoftwareRequestRepo
    {
        Task<SoftwareRequest> AddSoftwareRequest(SoftwareRequest SoftwareRequest);
        Task<bool> RemoveSoftwareReuest(long SoftwareRequestId);

        Task<SoftwareRequest> GetSoftwareRequestById(long SoftwareRequestId);
        Task<IEnumerable<SoftwareRequest>> GetSoftwareRequests();
    }
}
