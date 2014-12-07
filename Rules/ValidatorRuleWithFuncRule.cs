using System;
using RuleExperiments.Exceptions;
using RuleExperiments.Rules.Attributes;
using RuleExperiments.Rules.Interfaces;

namespace RuleExperiments.Rules
{
    [RuleName("ValidatorRuleWithFuncRule")]
    public class ValidatorRuleWithFuncRule : BaseRule, IValidatableWithFunc
    {
        public Type ValidatorType { get; set; }

        public bool ValidateWithFunc()
        {
            if (ValidatorType != null)
            {
                var instance = (IValidatableWithFunc) Activator.CreateInstance(ValidatorType);
                return instance.ValidateWithFunc();
            }

            throw new SystemLevelException("ValidatorRuleWithFuncRule error");
        }
    }
}