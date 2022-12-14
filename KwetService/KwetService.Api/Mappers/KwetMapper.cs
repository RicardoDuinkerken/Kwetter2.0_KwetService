using KwetService.Dal.Models;
using KwetService.Grpc;

namespace KwetService.Api.Mappers;

public static class KwetMapper
{
    public static Kwet CreateKwetRequestToKwet(CreateKwetRequest request)
    {
        return new()
        {
            Username = request.Username,
            Content = request.Content
        };
    }
    
    public static Kwet UpdateKwetRequestToKwet(UpdateKwetRequest request)
    {
        return new()
        {
            Id = request.Id,
            Username = request.Username,
            Content = request.Content
        };
    }

    public static KwetResponse KwetToKwetResponse(Kwet kwet)
    {
        return new()
        {
            Id = kwet.Id,
            Username = kwet.Username,
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