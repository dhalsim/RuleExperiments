﻿using Models.Bases;

namespace Models.Models.Attributes.Rules
{
    public class ConditionalRule : BaseRule
    {
        public object Value { get; set; }

        public object Method { get; set; }

        public ConditionalRule(object enumValue, object enumMethod)
        {
            Value = enumValue;
            Method = enumMethod;
        }
    }
}