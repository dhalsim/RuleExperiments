using System.Collections.Generic;
using RuleExperiments.Models;

namespace Models.Interfaces
{
    public interface ISearchFlight
    {
        List<SearchResponse> Search(SearchRequest searchRequest);
    }
}