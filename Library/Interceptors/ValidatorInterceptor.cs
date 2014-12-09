using System;
using System.Linq;
using Castle.DynamicProxy;
using Models.Exceptions;
using Models.Models.Attributes.Rules;

namespace Library.Interceptors
{
    public class ValidatorInterceptor : BaseInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            try
            {
                Called = true;

                // Before target call
                var simpleValidatorRule = (SimpleValidatorRule)
                    invocation.Method.GetCustomAttributes(typeof (SimpleValidatorRule), false).FirstOrDefault()
                                          ??
                                          (SimpleValidatorRule)
                                              invocation.MethodInvocationTarget.GetCustomAttributes(
                                                  typeof (SimpleValidatorRule), false).FirstOrDefault();

                if (simpleValidatorRule != null)
                {
                    Runned = true;
                    if (!simpleValidatorRule.Validate())
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