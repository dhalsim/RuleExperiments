using Models.Bases;
using Models.Interfaces.Rules;

namespace Models.Models.Attributes.Rules
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