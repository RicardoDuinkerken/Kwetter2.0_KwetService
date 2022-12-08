using KwetService.Dal.Models;
using KwetService.Grpc;

namespace KwetService.Api.Mappers;

public static class KwetMapper
{
    public static Kwet CreateKwetRequestToKwet(CreateKwetRequest request)
    {
        return new()
        {
            AccountId = request.AccountId,
            Content = request.Content
        };
    }
    
    public static Kwet UpdateKwetRequestToKwet(UpdateKwetRequest request)
    {
        return new()
        {
            Id = request.Id,
            AccountId = request.AccountId,
            Content = request.Content
        };
    }

    public static KwetResponse KwetToKwetResponse(Kwet kwet)
    {
        return new()
        {
            Id = kwet.Id,
            AccountId = kwet.AccountId,
            Content = kwet.Content
        };
    }

    public static long DeleteKwetRequestToId(DeleteKwetRequest request)
    {
        return request.Id;
    }

    public static DeleteKwetResponse KwetToDeleteKwetResponse(long kwetId)
    {
        return new()
        {
            Id = kwetId
        };
    }
}