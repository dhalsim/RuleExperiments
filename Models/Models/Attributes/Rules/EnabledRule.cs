using System;
using System.Collections.Generic;
using Models.Bases;
using Models.Exceptions;
using Models.Interfaces.Rules;
using Models.Models.RuleModels;

namespace Models.Models.Attributes.Rules
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class EnabledRule : BaseRule, IEnabledRule
    {
        private string RuleName { get; set; }

        private IRuleProvider RuleProvider { get; set; }

        public EnabledRule(string ruleName)
        {
            RuleName = ruleName;
        }

        public bool Enabled()
        {
            if (RuleProvider.Contains(RuleName))
            {
                return RuleProvider.Get<RuleValue<bool>>(RuleName).Value;
            }

            throw new SystemLevelException(string.Format("Rule {0} is not available", RuleName));
        }

        public DisableRule GetDisabledWith(EnabledRule enabledRule)
        {
            if (RuleProvider.Contains(RuleName))
            {
                var rule = RuleProvider.Get<RuleValue<bool>>(RuleName);
                List<DisableRule> disabledWith = rule.DisabledWith;
                if (disabledWith != null)
                {
                    return disabledWith.Find(disableRule => disableRule.RuleName == enabledRule.RuleName);
                }
            }

            return null;
        }
    }
}