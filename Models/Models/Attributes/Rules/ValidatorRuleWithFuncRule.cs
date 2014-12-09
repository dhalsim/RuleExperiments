using System;
using Models.Bases;
using Models.Exceptions;
using Models.Interfaces.Rules;

namespace Models.Models.Attributes.Rules
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