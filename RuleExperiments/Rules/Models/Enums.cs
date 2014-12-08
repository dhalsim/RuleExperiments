namespace RuleExperiments.Rules.Models
{
    public enum RuleDisableBehavior
    {
        DoNothing = 0,
        Ignore = 1,
        RaiseError = 2
    }

    public enum ProviderType
    {
        Amadeus = 0,
        External = 1,
        AmadeusAndExternal = 2
    }

    public enum MethodName
    {
        Search = 0
    }
}