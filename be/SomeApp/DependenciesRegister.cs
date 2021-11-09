using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;

namespace SomeApp
{
	public static class DependenciesRegister
	{
		public static ContainerBuilder RegisterApplicationServices(this ContainerBuilder builder)
		{
			builder
				.RegisterAssemblyTypes(Assembly.Load("SomeApp"))
				.Where(type => type.Namespace != null && type.Namespace.StartsWith("SomeApp.Implementations"))
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
			return builder;
		}
	}
}
