using Library.Helpers;
using Models.Interfaces;
using Models.Models.Enums;
using NUnit.Framework;
using RuleExperiments.Business.SearchFlight;

namespace RuleExperiments.UnitTests
{
    [TestFixture]
    public class IOCFixture
    {
        [Test]
        public void Should_create_amadeus_flight_search_object()
        {
            var container = new IOCHelper();

            var flightObject = container.GetInstance<ISearchFlight>(ProviderType.Amadeus);
            Assert.IsInstanceOf<AmadeusSearchFlight>(flightObject);
        }
    }
}