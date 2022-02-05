using Autofac;
using  Framework.Core.Bus;
using Framework.Core.IOC;
using System;
using System.Collections.Generic;

namespace Framework.Configuration.Autofac
{
    public class AutofacContainer : Core.IOC.IContainer
    {
        public IComponentContext Container { get; }


        public AutofacContainer(IComponentContext container)
        {
            Container = container;
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return Container.Resolve<IEnumerable<T>>();
        }
    }
}
