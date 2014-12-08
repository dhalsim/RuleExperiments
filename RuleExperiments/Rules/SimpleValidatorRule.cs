using RuleExperiments.Rules.Attributes;
using RuleExperiments.Rules.Interfaces;

namespace RuleExperiments.Rules
{
    [RuleName("SimpleValidatorRule")]
    public class SimpleValidatorRule : BaseRule, IValidatableRule
    {
        public bool Validate()
        {
            return false;
        }
    }
}