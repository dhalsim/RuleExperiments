using System.Collections.Generic;
using Models.Interfaces;
using RuleExperiments.Models;

namespace RuleExperiments.Business.SearchFlight
{
    public class AmadeusSearchFlight : ISearchFlight
    {
        public List<SearchResponse> Search(SearchRequest searchRequest)
        {
            return new List<SearchResponse> {new SearchResponse {ProviderType = ProviderType.Amadeus}};
        }
    }
}