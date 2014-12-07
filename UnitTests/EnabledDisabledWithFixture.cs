using NUnit.Framework;
using RuleExperiments.Business;
using RuleExperiments.Exceptions;

namespace RuleExperiments.UnitTests
{
    [TestFixture]
    public class EnabledDisabledWithFixture
    {
        [Test]
        public void Should_ignore_if_disabled_with()
        {
            var businessManager = new BusinessManager();
            int value = 4;
            Assert.True(businessManager.ShouldIgnoreAndCall(ref value));
            Assert.AreEqual(5, value);

            Assert.True(businessManager.EnabledInterceptor.Called);
            Assert.True(businessManager.EnabledInterceptor.Runned);
            Assert.True(businessManager.EnabledInterceptor.Succeeded);
        }

        [Test]
        public void Should_raise_error_if_disabled_with()
        {
            var businessManager = new BusinessManager();
            int value = 4;
            Assert.Throws<SystemLevelException>(() => businessManager.ShouldRaiseError(ref value));
            Assert.AreEqual(4, value);

            Assert.True(businessManager.EnabledInterceptor.Called);
            Assert.False(businessManager.EnabledInterceptor.Runned);
            Assert.False(businessManager.EnabledInterceptor.Succeeded);
        }
    }
}