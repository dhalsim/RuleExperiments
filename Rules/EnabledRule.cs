using System;
using System.Collections.Generic;
using RuleExperiments.Exceptions;
using RuleExperiments.Rules.Interfaces;
using RuleExperiments.Rules.Models;

namespace RuleExperiments.Rules
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class EnabledRule : BaseRule, IEnabledRule
    {
        private string RuleName { get; set; }

        public EnabledRule(string ruleName)
        {
            RuleName = ruleName;
        }

        public bool Enabled()
        {
            var rules = new PortalEnabledRules();
            if (rules.ContainsKey(RuleName))
            {
                return rules[RuleName].Value;
            }

            throw new SystemLevelException(string.Format("Rule {0} is not available", RuleName));
        }

        public DisableRule GetDisabledWith(EnabledRule rule)
        {
            var rules = new PortalEnabledRules();
            if (rules.ContainsKey(RuleName))
            {
                List<DisableRule> disabledWith = rules[RuleName].DisabledWith;
                if (disabledWith != null)
                {
                    return disabledWith.Find(disableRule => disableRule.RuleName == rule.RuleName);
                }
            }

            return null;
        }
    }
}