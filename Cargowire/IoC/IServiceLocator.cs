using System;

namespace Cargowire.IoC
{
    public interface IServiceLocator
    {
        object GetInstance(Type @type);
        T GetInstance<T>();
    }
}