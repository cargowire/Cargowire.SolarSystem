﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Cargowire.Data
{
	/// <remarks>Sourced from online (somewhere I can't remember!) essentially just allows INotifyPropertyChanged
	/// without writing the boiler plate everywhere.</remarks>
	public static class PropertySupport
	{
		public static String ExtractPropertyName<T>(Expression<Func<T>> propertyExpresssion)
		{
			if (propertyExpresssion == null)
			{
				throw new ArgumentNullException("propertyExpresssion");
			}

			var memberExpression = propertyExpresssion.Body as MemberExpression;
			if (memberExpression == null)
			{
				throw new ArgumentException("The expression is not a member access expression.", "propertyExpresssion");
			}

			var property = memberExpression.Member as PropertyInfo;
			if (property == null)
			{
				throw new ArgumentException("The member access expression does not access a property.", "propertyExpresssion");
			}

			var getMethod = property.GetGetMethod(true);
			if (getMethod.IsStatic)
			{
				throw new ArgumentException("The referenced property is a static property.", "propertyExpresssion");
			}

			return memberExpression.Member.Name;
		}
	}

    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
		
		private string _test;
		public string test { get { return _test; } set { _test = value; OnPropertyChanged(new PropertyChangedEventArgs("test")); } }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpresssion)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpresssion);
            this.RaisePropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged(String propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
	}
}
