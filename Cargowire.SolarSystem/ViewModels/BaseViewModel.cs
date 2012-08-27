using System.Collections.Generic;

using Cargowire.Data;

namespace Cargowire.SolarSystem.ViewModels
{
	public abstract class BaseViewModel : ObservableObject
	{
		public virtual void Initialize(IDictionary<string, string> parameters)
		{
		}
	}
}
