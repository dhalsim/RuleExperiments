using Castle.DynamicProxy;

namespace RuleExperiments.Interceptors
{
    public abstract class BaseInterceptor : IInterceptor
    {
        public bool Called { get; set; }

        public bool Runned { get; set; }

        public bool Succeeded { get; set; }

        public abstract void Intercept(IInvocation invocation);
    }
}