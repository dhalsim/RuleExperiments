using System.Collections.Generic;
using Castle.DynamicProxy;
using Library.Interceptors;
using Models.Interfaces;
using Models.Models.Attributes.Rules;
using Models.Models.Enums;
using NUnit.Framework;
using RuleExperiments.Models;

namespace RuleExperiments.UnitTests
{
    public class SearchMethods : ISearchFlight
    {
        [ConditionalRule(ProviderType.Amadeus, MethodName.Search)]
        public List<SearchResponse> Search(SearchRequest searchRequest)
        {
            return null;
        }
    }

    public class SearchBusiness : ISearchFlight
    {
        public ISearchFlight SearchFlightProxy { get; set; }

        private ProxyGenerator ProxyGenerator { get; set; }

        public SearchBusiness()
        {
            ProxyGenerator = new ProxyGenerator();
            SearchFlightProxy = (ISearchFlight) ProxyGenerator.CreateClassProxy(typeof (SearchMethods),
                new[] {typeof (ISearchFlight)}, new ConditionalInterceptor());
        }

        public List<SearchResponse> Search(SearchRequest searchRequest)
        {
            return SearchFlightProxy.Search(searchRequest);
        }
    }

    [TestFixture]
    public class ConditionalRuleFixture
    {
        [Test]
        public void Should_Search_With_OnlyAmadeus()
        {
            var result = new SearchBusiness().Search(new SearchRequest());
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<SearchResponse>>(result);
            Assert.AreEqual(1, result.Count);
        }
    }
}