using Autofac.Interface;

namespace Autofac.Impl
{
    public class Wrapper
    {
        public IShout Shoutter { get; set; }

        public Wrapper(IShout shout)
        {
            this.Shoutter = shout;
        }
    }
}