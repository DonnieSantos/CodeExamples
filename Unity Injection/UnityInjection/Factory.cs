using Microsoft.Practices.Unity;
using System;

namespace UnityInjection
{
    public enum InjectionContext
    {
        Normal, Test
    }

    static class Factory
    {
        private static IUnityContainer _container = new UnityContainer();

        private static InjectionContext _context;

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public static InjectionContext Context
        {
            set
            {
                _context = value;
                registerTypes();
            }
        }

        private static void registerTypes()
        {
            switch (_context)
            {
                case InjectionContext.Normal:
                    _container.RegisterType<WrapsItem, FullBox>();
                    _container.RegisterType<Wrappable, Item>();
                    break;
                case InjectionContext.Test:
                    _container.RegisterType<WrapsItem, EmptyBox>();
                    _container.RegisterType<Wrappable, Item>();
                    break;
            }
        }
    }
}