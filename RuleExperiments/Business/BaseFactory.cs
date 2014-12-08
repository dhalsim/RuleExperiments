using System;
using RuleExperiments.Exceptions;

namespace RuleExperiments.Business
{
    public class BusinessFactory<TReturnType>
    {
        public virtual TReturnType Get(Enum e)
        {
            Type type = typeof (TReturnType);
            string interfaceName = type.Name;
            string interfaceNamespace = type.Namespace;
            string implementationName = e + interfaceName.TrimStart('I');
            Type implementationType = Type.GetType(string.Format("{0}.{1}", interfaceNamespace, implementationName));

            if (implementationType == null)
            {
                throw new SystemLevelException(string.Format("Factory method failed with Interface {0} and Enum {1}",
                    interfaceName, e));
            }

            return (TReturnType) Activator.CreateInstance(implementationType);
        }
    }
}