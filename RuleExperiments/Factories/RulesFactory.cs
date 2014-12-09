using System;
using System.Collections.Generic;
using System.Linq;
using Models.Bases;
using Models.Exceptions;
using Models.Models.Attributes;
using Models.Models.Attributes.Rules;

namespace RuleExperiments.Factories
{
    public class RulesFactory
    {
        public RulesFactory()
        {
            Rules = new Dictionary<string, BaseRule>
            {
                {"SimpleRule", new SimpleRule()},
                {"SimpleValidatorRule", new SimpleValidatorRule()}
            };
        }

        public Dictionary<string, BaseRule> Rules { get; set; }

        public BaseRule GetRule(string ruleName)
        {
            BaseRule rule;
            if (Rules.TryGetValue(ruleName, out rule))
            {
                return rule;
            }

            throw new UserLevelException(string.Format("Rule {0} not found", ruleName));
        }

        public TBaseRuleType GetRule<TBaseRuleType>() where TBaseRuleType : BaseRule
        {
            Type type = typeof (TBaseRuleType);
            var attribute = type.GetCustomAttributes(typeof (RuleName), false).FirstOrDefault();

            if (attribute != null)
            {
                var ruleNameAttribute = attribute as RuleName;

                if (ruleNameAttribute != null)
                {
                    BaseRule rule;
                    if (Rules.TryGetValue(ruleNameAttribute.Name, out rule))
                    {
                        return (TBaseRuleType) rule;
                    }
                }
            }

            throw new UserLevelException(string.Format("Rule type {0} not found", type.Name));
        }
    }
}