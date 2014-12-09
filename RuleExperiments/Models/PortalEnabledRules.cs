using System.Collections.Generic;
using Models.Models.Enums;
using Models.Models.RuleModels;

namespace RuleExperiments.Models
{
    public class PortalEnabledRules : Dictionary<string, RuleValue<bool>>
    {
        public const string Rule1 = "Rule1";
        public const string Rule2 = "Rule2";
        public const string Rule3 = "Rule3";
        public const string Rule4 = "Rule4";
        public const string Rule5 = "Rule5";
        public const string Rule6 = "Rule6";
        public const string Rule7 = "Rule7";

        public PortalEnabledRules()
        {
            Add(Rule1, new RuleValue<bool> {Name = Rule1, Value = true});
            Add(Rule2, new RuleValue<bool> {Name = Rule2, Value = false});
            Add(Rule3, new RuleValue<bool> {Name = Rule3, Value = true});
            Add(Rule4, new RuleValue<bool> {Name = Rule4, Value = true});
            Add(Rule5, new RuleValue<bool>
            {
                Name = Rule5,
                Value = true,
                DisabledWith = new List<DisableRule>
                {
                    new DisableRule {RuleName = Rule4, DisableBehavior = RuleDisableBehavior.Ignore}
                }
            });

            Add(Rule6, new RuleValue<bool>
            {
                Name = Rule6,
                Value = true,
                DisabledWith = new List<DisableRule>
                {
                    new DisableRule {RuleName = Rule7, DisableBehavior = RuleDisableBehavior.RaiseError}
                }
            });

            Add(Rule7, new RuleValue<bool>
            {
                Name = Rule7,
                Value = true,
                DisabledWith = new List<DisableRule>
                {
                    new DisableRule {RuleName = Rule6, DisableBehavior = RuleDisableBehavior.RaiseError}
                }
            });
        }
    }
}