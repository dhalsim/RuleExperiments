using System.Collections.Generic;

namespace RuleExperiments.Business.SearchFlight
{
    public interface ISearchFlight
    {
        List<SearchResponse> Search(SearchRequest searchRequest);
    }
}