using NUnit.Framework;
using RuleExperiments.Business;
using RuleExperiments.Business.SearchFlight;
using RuleExperiments.Rules.Models;

namespace RuleExperiments.UnitTests
{
    [TestFixture]
    public class BusinessFactoryFixture
    {
        [Test]
        public void Should_create_amadeus_flight_search_object()
        {
            var flightObject = new BusinessFactory<ISearchFlight>().Get(ProviderType.Amadeus);
            Assert.IsInstanceOf<AmadeusSearchFlight>(flightObject);
        }
    }
}