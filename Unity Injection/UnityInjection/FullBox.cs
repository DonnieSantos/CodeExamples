using Microsoft.Practices.Unity;

namespace UnityInjection
{
    class FullBox : WrapsItem
    {
        private Wrappable contents = Factory.Resolve<Wrappable>();

        public void printContents()
        {
            System.Console.WriteLine("I Contain " + contents.getDescription() + ".");
        }
    }
}