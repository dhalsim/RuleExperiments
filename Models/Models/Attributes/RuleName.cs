using System;

namespace Models.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RuleName : Attribute
    {
        public string Name { get; set; }

        public RuleName(string ruleName)
        {
            Name = ruleName;
        }
    }
}