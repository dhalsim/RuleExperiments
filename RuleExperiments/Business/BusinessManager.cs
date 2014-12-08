using Castle.DynamicProxy;
using RuleExperiments.Interceptors;

namespace RuleExperiments.Business
{
    public class BusinessManager : IBusinessMethods
    {
        private ProxyGenerator ProxyGenerator { get; set; }
        private IBusinessMethods Proxy { get; set; }

        public ValidatorInterceptor ValidatorInterceptor;
        public ValidatorWithFuncInterceptor ValidatorWithFuncInterceptor;
        public EnabledInterceptor EnabledInterceptor;

        public BusinessManager()
        {
            ProxyGenerator = new ProxyGenerator();
            ValidatorInterceptor = new ValidatorInterceptor();
            ValidatorWithFuncInterceptor = new ValidatorWithFuncInterceptor();
            EnabledInterceptor = new EnabledInterceptor();
            Proxy = (IBusinessMethods) ProxyGenerator.CreateClassProxy(typeof (BusinessMethods),
                new[] {typeof (IBusinessMethods)},
                ValidatorInterceptor, ValidatorWithFuncInterceptor, EnabledInterceptor);
        }

        public void ValidateWithSimpleRule()
        {
            Proxy.ValidateWithSimpleRule();
        }

        public bool ValidateWithFunc()
        {
            return Proxy.ValidateWithFunc();
        }

        public bool ShouldCall(ref int value)
        {
            return Proxy.ShouldCall(ref value);
        }

        public bool ShouldNotCall(ref int value)
        {
            return Proxy.ShouldNotCall(ref value);
        }

        public bool ShouldNotCallWithMultipleRules(ref int value)
        {
            return Proxy.ShouldNotCallWithMultipleRules(ref value);
        }

        public bool ShouldCallWithMultipleRules(ref int value)
        {
            return Proxy.ShouldCallWithMultipleRules(ref value);
        }

        public bool ShouldIgnoreAndCall(ref int value)
        {
            return Proxy.ShouldIgnoreAndCall(ref value);
        }

        public bool ShouldRaiseError(ref int value)
        {
            return Proxy.ShouldRaiseError(ref value);
        }
    }
}