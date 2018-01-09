using Microsoft.Practices.Unity;

namespace UnityInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory.Context = InjectionContext.Normal;
            var box = Factory.Resolve<WrapsItem>();
            box.printContents();

            Factory.Context = InjectionContext.Test;
            box = Factory.Resolve<WrapsItem>();
            box.printContents();

            System.Console.Write("Press any key to continue... ");
            System.Console.ReadKey();
        }
    }
}