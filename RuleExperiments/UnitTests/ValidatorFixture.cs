using Models.Exceptions;
using NUnit.Framework;
using RuleExperiments.Business;

namespace RuleExperiments.UnitTests
{
    [TestFixture]
    public class ValidatorFixture
    {
        [Test]
        public void ValidateWithSimpleRule_Should_throw_user_level_exception()
        {
            var businessManager = new BusinessManager();
            Assert.Throws<UserLevelException>(businessManager.ValidateWithSimpleRule);
            Assert.True(businessManager.ValidatorInterceptor.Called);
            Assert.True(businessManager.ValidatorInterceptor.Runned);
            Assert.False(businessManager.ValidatorInterceptor.Succeeded);

            Assert.False(businessManager.ValidatorWithFuncInterceptor.Called);
            Assert.False(businessManager.ValidatorWithFuncInterceptor.Runned);
            Assert.False(businessManager.ValidatorWithFuncInterceptor.Succeeded);
        }

        [Test]
        public void ValidateWithFuncRule_Should_Return_true()
        {
            var businessManager = new BusinessManager();
            Assert.True(businessManager.ValidateWithFunc());

            Assert.True(businessManager.ValidatorInterceptor.Called);
            Assert.False(businessManager.ValidatorInterceptor.Runned);
            Assert.True(businessManager.ValidatorInterceptor.Succeeded);

            Assert.True(businessManager.ValidatorWithFuncInterceptor.Called);
            Assert.True(businessManager.ValidatorWithFuncInterceptor.Runned);
            Assert.True(businessManager.ValidatorWithFuncInterceptor.Succeeded);
        }
    }
}