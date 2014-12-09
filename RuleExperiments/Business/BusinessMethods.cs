using Models.Interfaces;
using Models.Models.Attributes.Rules;
using RuleExperiments.Models;

namespace RuleExperiments.Business
{
    public class BusinessMethods : IBusinessMethods
    {
        [SimpleValidatorRule]
        public void ValidateWithSimpleRule()
        {
        }

        [ValidatorRuleWithFuncRule(ValidatorType = typeof (ValidateWithFuncImp))]
        public bool ValidateWithFunc()
        {
            return true;
        }

        [EnabledRule(PortalEnabledRules.Rule1)]
        public bool ShouldCall(ref int value)
        {
            value++;
            return true;
        }

        [EnabledRule(PortalEnabledRules.Rule2)]
        public bool ShouldNotCall(ref int value)
        {
            value++;
            return true;
        }

        [EnabledRule(PortalEnabledRules.Rule1)]
        [EnabledRule(PortalEnabledRules.Rule2)]
        public bool ShouldNotCallWithMultipleRules(ref int value)
        {
            value++;
            return true;
        }

        [EnabledRule(PortalEnabledRules.Rule1)]
        [EnabledRule(PortalEnabledRules.Rule3)]
        public bool ShouldCallWithMultipleRules(ref int value)
        {
            value++;
            return true;
        }

        [EnabledRule(PortalEnabledRules.Rule4)]
        [EnabledRule(PortalEnabledRules.Rule5)]
        public bool ShouldIgnoreAndCall(ref int value)
        {
            value++;
            return true;
        }

        [EnabledRule(PortalEnabledRules.Rule6)]
        [EnabledRule(PortalEnabledRules.Rule7)]
        public bool ShouldRaiseError(ref int value)
        {
            value++;
            return true;
        }
    }
}