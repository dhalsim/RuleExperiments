using System.Collections.Generic;

namespace Models.Models.RuleModels
{
    public class RuleValue<T>
    {
        public string Name { get; set; }

        public T Value { get; set; }

        public List<DisableRule> DisabledWith { get; set; }

        public List<string> EnabledWith { get; set; }
    }
}