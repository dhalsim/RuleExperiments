using Models.Models.Enums;

namespace Models.Models.RuleModels
{
    public class DisableRule
    {
        public string RuleName { get; set; }

        public RuleDisableBehavior DisableBehavior { get; set; }
    }
}