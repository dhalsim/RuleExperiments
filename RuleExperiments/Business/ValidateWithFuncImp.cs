using Models.Interfaces.Rules;

namespace RuleExperiments.Business
{
    public class ValidateWithFuncImp : IValidatableWithFunc
    {
        public bool ValidateWithFunc()
        {
            return true;
        }
    }
}