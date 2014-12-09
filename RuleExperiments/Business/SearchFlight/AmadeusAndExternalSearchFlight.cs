using System.Collections.Generic;
using RuleExperiments.Models;

namespace RuleExperiments.Business.SearchFlight
{
    public class AmadeusAndExternalSearchFlight
    {
        public List<SearchResponse> Search(SearchRequest searchRequest)
        {
            return new List<SearchResponse> {new SearchResponse {ProviderType = ProviderType.AmadeusAndExternal}};
        }
    }
}