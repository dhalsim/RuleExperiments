using System;
using System.Linq;
using Castle.DynamicProxy;
using RuleExperiments.Exceptions;
using RuleExperiments.Rules;

namespace RuleExperiments.Interceptors
{
    public class ValidatorWithFuncInterceptor : BaseInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            try
            {
                Called = true;

                // Before target call
                var valideWithFuncRule = (ValidatorRuleWithFuncRule)
                    invocation.Method.GetCustomAttributes(typeof (ValidatorRuleWithFuncRule), false).FirstOrDefault()
                                         ??
                                         (ValidatorRuleWithFuncRule)
                                             invocation.MethodInvocationTarget.GetCustomAttributes(
                                                 typeof (ValidatorRuleWithFuncRule), false).FirstOrDefault();

                if (valideWithFuncRule != null)
                {
                    Runned = true;
                    if (!valideWithFuncRule.ValidateWithFunc())
                    {
                        throw new UserLevelException("Validation error");
                    }
                }

                // method call
                invocation.Proceed();

                // after method call
                Succeeded = true;
            }
            catch (UserLevelException)
            {
                Succeeded = false;
                throw;
            }
            catch (Exception exception)
            {
                Succeeded = false;
                throw new SystemLevelException("Validation error", exception);
            }
            finally
            {
                // After target call
            }
        }
    }
}