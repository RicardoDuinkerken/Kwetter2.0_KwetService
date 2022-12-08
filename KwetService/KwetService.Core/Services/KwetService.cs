using GenericDal;
using KwetService.Core.Services.Interfaces;
using KwetService.Dal.Models;
using Microsoft.Extensions.Logging;

namespace KwetService.Core.Services;

public class KwetService : IKwetService
{
    private ILogger<KwetService> _logger;
    private readonly IAsyncRepository<Kwet, long> _kwetRepository;

    public KwetService(ILogger<KwetService> logger, IAsyncRepository<Kwet, long> kwetRepository)
    {
        _logger = logger;
        _kwetRepository = kwetRepository;
    }
    
    public async Task<Kwet> CreateKwetAsync(Kwet kwet)
    {
        kwet = await _kwetRepository.CreateAsync(kwet);

        _logger.LogInformation("Kwet created with id: {Id}", kwet.Id);
        
        return kwet;
    }
    
    public async Task<Kwet> UpdateKwetAsync(Kwet kwet)
    {
        kwet = await _kwetRepository.UpdateAsync(kwet);
        _logger.LogInformation("Kwet updated with id: {Id}", kwet.Id);
        
        return kwet;
    }

    public async Task<long> DeleteKwetAsync(long kwetId)
    {
        if (!await _kwetRepository.DeleteAsync(kwetId))
            throw new ArgumentException($"No account found with id: {kwetId}");
        
        return kwetId;
    }
    
}