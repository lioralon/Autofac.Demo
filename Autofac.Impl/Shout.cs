using Autofac.Interface;

namespace Autofac.Impl
{
    public class Shouter : IShout
    {
        public string Shout(string name)
        {
            return string.Format("{0} - meow,meow", name);
        }
    }
}