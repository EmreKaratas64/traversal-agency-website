using MediatR;
using OnlineTravel.CQRS.Results.GuideResults;

namespace OnlineTravel.CQRS.Queries.GuideQueries
{
    public class GetGuideQuery : IRequest<List<GetGuideQueryResult>>
    {
    }
}
