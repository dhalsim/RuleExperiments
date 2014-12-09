using System;
using System.Reflection;
using HaveBox;
using HaveBox.SubConfigs;
using Models.Exceptions;
using Models.Interfaces.Rules;
using Models.Models.Enums;

namespace Library.Helpers
{
    public class IOCHelper
    {
        private static Container _container;

        public static Container Scan()
        {
            var assembly = Assembly.GetAssembly(typeof(IEnabledRule));
            _container = new Container();
            _container.Configure(config => config.MergeConfig(new SimpleScanner(assembly)));
            return _container;
        }

        public T GetInstance<T>(ProviderType e)
        {
            if(_container == null)
                _container = Scan();

            Type type = typeof(T);
            string interfaceName = type.Name;
            string interfaceNamespace = type.Namespace;
            string implementationName = e + interfaceName.TrimStart('I');
            Type implementationType = Type.GetType(string.Format("{0}.{1}", interfaceNamespace, implementationName));

            if (implementationType == null)
            {
                throw new SystemLevelException(string.Format("GetInstance method failed with Interface {0} and Enum {1}",
                    interfaceName, e));
            }

            return _container.GetInstance<T>(implementationName);
        }

        public object GetInstance(ProviderType e)
        {
            if (_container == null)
                _container = Scan();

            Type type = typeof(IEnabledRule);
            string interfaceName = type.Name;
            string interfaceNamespace = type.Namespace;
            string implementationName = e + interfaceName.TrimStart('I');
            Type implementationType = Type.GetType(string.Format("{0}.{1}", interfaceNamespace, implementationName));

            if (implementationType == null)
            {
                throw new SystemLevelException(string.Format("GetInstance method failed with Interface {0} and Enum {1}",
                    interfaceName, e));
            }

            return _container.GetInstance<T>(implementationName);
        }
    }
}