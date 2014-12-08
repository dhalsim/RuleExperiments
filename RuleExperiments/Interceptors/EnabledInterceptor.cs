using System;
using System.Reflection;
using Castle.DynamicProxy;
using RuleExperiments.Exceptions;
using RuleExperiments.Rules;
using RuleExperiments.Rules.Models;

namespace RuleExperiments.Interceptors
{
    public class EnabledInterceptor : BaseInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            try
            {
                Called = true;

                // Before target call
                MethodInfo methodInfo = invocation.MethodInvocationTarget;
                var enabledRules = (EnabledRule[]) methodInfo.GetCustomAttributes(typeof (EnabledRule), false);

                RuleDisableBehavior disableBehavior = CalculateDisableBehaviour(enabledRules);

                if (disableBehavior == RuleDisableBehavior.RaiseError)
                {
                    throw new SystemLevelException("Rules are not supposed to work together");
                }

                bool enabled = true;
                if (disableBehavior != RuleDisableBehavior.Ignore)
                {
                    foreach (var enabledRule in enabledRules)
                    {
                        enabled = enabledRule.Enabled();

                        if (!enabled)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    enabled = false;
                }

                // method call
                if (enabled)
                {
                    invocation.Proceed();
                    Runned = true;
                }
                else
                {
                    var type = methodInfo.ReturnType;
                    invocation.ReturnValue = GetDefaultValue(type);
                }

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

        private RuleDisableBehavior CalculateDisableBehaviour(EnabledRule[] enabledRules)
        {
            int length = enabledRules.Length;
            for (int index = 0; index < length; index++)
            {
                EnabledRule enabledRule = enabledRules[index];

                if (index + 1 == length)
                {
                    break;
                }

                for (int j = index + 1; j < length; j++)
                {
                    EnabledRule enabledRule2 = enabledRules[j];

                    DisableRule disabledWith = enabledRule.GetDisabledWith(enabledRule2);

                    if (disabledWith != null)
                    {
                        return disabledWith.DisableBehavior;
                    }
                }
            }

            return RuleDisableBehavior.DoNothing;
        }

        private object GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);

            return null;
        }
    }
}