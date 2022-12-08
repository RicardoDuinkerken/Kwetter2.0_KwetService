using Grpc.Core;
using KwetService.Api.Mappers;
using KwetService.Core.Services.Interfaces;
using KwetService.Grpc;
using Microsoft.Extensions.Logging;

namespace KwetService.Api.Controllers;

public class KwetController : Grpc.KwetService.KwetServiceBase
{
    private readonly ILogger<KwetController> _logger;
    private readonly IKwetService _kwetService;

    public KwetController(ILogger<KwetController> logger, IKwetService kwetService)
    {
        _logger = logger;
        _kwetService = kwetService;
    }
    
    public override async Task<KwetResponse> CreateKwet(CreateKwetRequest request,
        ServerCallContext context)
    {
        _logger.LogInformation("CreateKwet invoked");
        
        try
        {
            return KwetMapper.KwetToKwetResponse(
                await _kwetService.CreateKwetAsync(
                   KwetMapper.CreateKwetRequestToKwet(request)));
        }
        catch (Exception e)
        {
            _logger.LogError("{E}", e);
            throw new RpcException(new Status(StatusCode.Internal, e.Message));
        }
    }
    
    public override async Task<KwetResponse> UpdateKwet(UpdateKwetRequest request,
        ServerCallContext context)
    {
        _logger.LogInformation("UpdateKwet invoked");
        
        try
        {
            return KwetMapper.KwetToKwetResponse(
                await _kwetService.UpdateKwetAsync(
                    KwetMapper.UpdateKwetRequestToKwet(request)));
        }
        catch (Exception e)
        {
            _logger.LogError("{E}", e);
            throw new RpcException(new Status(StatusCode.Internal, e.Message));
        }
    }
    
    public override async Task<DeleteKwetResponse> DeleteKwet(DeleteKwetRequest request,
        ServerCallContext context)
    {
        _logger.LogInformation("DeleteKwet invoked");
        
        try
        {
            return KwetMapper.KwetToDeleteKwetResponse(
                await _kwetService.DeleteKwetAsync(
                    KwetMapper.DeleteKwetRequestToId(request)));
        }
        catch (Exception e)
        {
            _logger.LogError("{E}", e);
            throw new RpcException(new Status(StatusCode.Internal, e.Message));
        }
    }
    
}