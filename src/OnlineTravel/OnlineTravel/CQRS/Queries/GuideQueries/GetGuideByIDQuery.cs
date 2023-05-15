using MediatR;
using OnlineTravel.CQRS.Results.GuideResults;

namespace OnlineTravel.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery : IRequest<GetGuideByIDQueryResult>
    {
        public GetGuideByIDQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
