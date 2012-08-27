using System;

namespace Cargowire.IoC
{
	/// <remarks>Wrapper for IoC similar to Common Service locator etc</remarks>
    public interface IServiceLocator
    {
        object GetInstance(Type @type);
        T GetInstance<T>();
    }
}