using NUnit.Framework;
using RuleExperiments.Rules;

namespace RuleExperiments.UnitTests
{
    [TestFixture]
    public class RulesFixture
    {
        private RulesFactory RulesFactory { get; set; }

        [TestFixtureSetUp]
        public void SetUp()
        {
            RulesFactory = new RulesFactory();
        }

        [Test]
        public void SimpleRule_Should_not_null()
        {
            Assert.NotNull(RulesFactory.GetRule<SimpleRule>());
        }

        [Test]
        public void SimpleValidatorRule_Should_not_null()
        {
            Assert.NotNull(RulesFactory.GetRule<SimpleValidatorRule>());
        }

        [Test]
        public void SimpleValidatorRule_Should_not_Validate()
        {
            SimpleValidatorRule simpleValidatorRule = RulesFactory.GetRule<SimpleValidatorRule>();
            Assert.False(simpleValidatorRule.Validate());
        }
    }
}