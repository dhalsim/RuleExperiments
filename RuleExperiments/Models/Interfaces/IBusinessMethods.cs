namespace Models.Interfaces
{
    public interface IBusinessMethods
    {
        void ValidateWithSimpleRule();

        bool ValidateWithFunc();

        bool ShouldCall(ref int value);

        bool ShouldNotCall(ref int value);

        bool ShouldNotCallWithMultipleRules(ref int value);

        bool ShouldCallWithMultipleRules(ref int value);

        bool ShouldIgnoreAndCall(ref int value);

        bool ShouldRaiseError(ref int value);
    }
}