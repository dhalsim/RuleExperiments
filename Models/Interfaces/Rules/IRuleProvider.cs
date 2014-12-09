namespace Models.Interfaces.Rules
{
    public interface IRuleProvider
    {
        T Get<T>(string ruleName);

        bool Contains(string ruleName);

        void Set(string ruleName, object value);
    }
}