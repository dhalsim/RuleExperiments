using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Models.Exceptions;
using Models.Interfaces.Business;
using Models.Models.Attributes.Rules;

namespace Library.Interceptors
{
    public class ConditionalInterceptor : BaseInterceptor
    {
        private IBusinessContainer BusinessContainer { get; set; }

        public override void Intercept(IInvocation invocation)
        {
            try
            {
                Called = true;

                // Before target call
                MethodInfo methodInfo = invocation.MethodInvocationTarget;
                var conditionalRule =
                    (ConditionalRule) methodInfo.GetCustomAttributes(typeof (ConditionalRule), false).FirstOrDefault();

                if (conditionalRule != null)
                {
                    Type factoryType = typeof (BusinessFactory<>);
                    Type declaringType = methodInfo.DeclaringType;

                    if (declaringType == null)
                    {
                        string message = string.Format(@"ConditionalInterceptor error. DeclaringType is null. 
                            Method Name: {0}", methodInfo.Name);
                        throw new SystemException(message);
                    }

                    Type firstInterface = declaringType.GetInterfaces().FirstOrDefault();

                    if (firstInterface == null)
                    {
                        string message = string.Format(@"ConditionalInterceptor error. Interface cannot be found. 
                            Method Name: {0}, Declaring Type: {1}", methodInfo.Name, declaringType.Name);
                        throw new SystemLevelException(message);
                    }

                    Type[] invocatioTypes = {firstInterface};
                    var factoryObject = factoryType.MakeGenericType(invocatioTypes);
                    var factoryInstance = Activator.CreateInstance(factoryObject);

                    var factoryMethod = factoryInstance.GetType().GetMethod("Get");
                    var objectInstance = factoryMethod.Invoke(factoryInstance, new[] {conditionalRule.Value});

                    var businessObject = BusinessContainer.Get<>()


                    invocation.ReturnValue = firstInterface.GetMethod(conditionalRule.Method.ToString())
                        .Invoke(objectInstance, invocation.Arguments.ToArray());
                }

                // method call bypassed, ReturnValue used instead of Proceed
                // invocation.Proceed();
                Runned = true;

                // after method call
                Succeeded = true;
            }
            catch (Exception exception)
            {
                Succeeded = false;
                throw new SystemLevelException("Enabled Interceptor error", exception);
            }
            finally
            {
                // After target call
            }
        }
    }
}