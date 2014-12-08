using NUnit.Framework;
using RuleExperiments.Exceptions;
using RuleExperiments.Rules;

namespace RuleExperiments.UnitTests
{
    [TestFixture]
    public class RulesFactoryFixture
    {
        [Test]
        public void Should_return_SimpleRule()
        {
            var factory = new RulesFactory();
            Assert.IsNotNull(factory.GetRule("SimpleRule"));
        }

        [Test]
        public void Should_return_SimpleRule_with_type()
        {
            var factory = new RulesFactory();
            Assert.IsNotNull(factory.GetRule<SimpleRule>());
        }

        [Test]
        public void Should_throw_exception_if_not_found()
        {
            var factory = new RulesFactory();
            Assert.Throws<UserLevelException>(() => factory.GetRule("DontExists"));
        }
    }
}