using NUnit.Framework;
using RuleExperiments.Business;

namespace RuleExperiments.UnitTests
{
    [TestFixture]
    public class EnabledFixture
    {
        [Test]
        public void Should_call_with_enabled_true()
        {
            var businessManager = new BusinessManager();
            int value = 4;
            Assert.True(businessManager.ShouldCall(ref value));
            Assert.AreEqual(5, value);

            Assert.True(businessManager.EnabledInterceptor.Called);
            Assert.True(businessManager.EnabledInterceptor.Runned);
            Assert.True(businessManager.EnabledInterceptor.Succeeded);
        }

        [Test]
        public void Should_not_call_with_enabled_false()
        {
            var businessManager = new BusinessManager();
            int value = 4;
            Assert.False(businessManager.ShouldNotCall(ref value));
            Assert.AreEqual(4, value);

            Assert.True(businessManager.EnabledInterceptor.Called);
            Assert.False(businessManager.EnabledInterceptor.Runned);
            Assert.True(businessManager.EnabledInterceptor.Succeeded);
        }

        [Test]
        public void Should_not_call_with_multiple_rules()
        {
            var businessManager = new BusinessManager();
            int value = 4;
            Assert.False(businessManager.ShouldNotCallWithMultipleRules(ref value));
            Assert.AreEqual(4, value);

            Assert.True(businessManager.EnabledInterceptor.Called);
            Assert.False(businessManager.EnabledInterceptor.Runned);
            Assert.True(businessManager.EnabledInterceptor.Succeeded);
        }

        [Test]
        public void Should_call_with_multiple_rules()
        {
            var businessManager = new BusinessManager();
            int value = 4;
            Assert.True(businessManager.ShouldCallWithMultipleRules(ref value));
            Assert.AreEqual(5, value);

            Assert.True(businessManager.EnabledInterceptor.Called);
            Assert.True(businessManager.EnabledInterceptor.Runned);
            Assert.True(businessManager.EnabledInterceptor.Succeeded);
        }
    }
}