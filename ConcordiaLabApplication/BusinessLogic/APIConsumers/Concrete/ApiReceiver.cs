using BusinessLogic.APIConsumers.Abstract;
using BusinessLogic.APIConsumers.UriCreators;
using BusinessLogic.DTOs.TrelloDtos;

namespace BusinessLogic.APIConsumers.Concrete;

public class ApiReceiver : IApiReceiver
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IUriCreatorFactory _uriCreator;

    public ApiReceiver(IHttpClientFactory httpClientFactory, IUriCreatorFactory uriCreatorFactory)
    {
        _httpClientFactory = httpClientFactory;
        _uriCreator = uriCreatorFactory;
    }

    public async Task<IEnumerable<TrelloExperimentDto>?> GetAllExperimentsInToDoColumn()
    {
        var client = _httpClientFactory.CreateClient("ApiConsumer");
        var response = await client.GetFromJsonAsync<IEnumerable<TrelloExperimentDto>?>(_uriCreator.GetAllCardsOnToDoColumn());
        var responseFromProgress = await client.GetFromJsonAsync<IEnumerable<TrelloExperimentDto>?>(_uriCreator.GetAllCardsOnProgressColumn());
        return response?.Union(responseFromProgress ?? new List<TrelloExperimentDto> { });
    }

    public async Task<IEnumerable<TrelloCommentDto>?> GetAllComments()
    {
        var client = _httpClientFactory.CreateClient("ApiConsumer");
        var response = await client.GetFromJsonAsync<IEnumerable<TrelloCommentDto>?>(_uriCreator.GetAllCommentsOnABoard());
        return response;
    }
}
