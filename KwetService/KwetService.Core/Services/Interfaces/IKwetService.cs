using KwetService.Dal.Models;

namespace KwetService.Core.Services.Interfaces;

public interface IKwetService
{
    Task<Kwet> CreateKwetAsync(Kwet kwet);
    Task<Kwet> UpdateKwetAsync(Kwet kwet);
    Task<long> DeleteKwetAsync(long kwetId);
}