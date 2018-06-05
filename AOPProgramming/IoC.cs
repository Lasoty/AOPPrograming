using Autofac;
using System;

namespace AOPProgramming
{
	internal static class IoC
	{
		public static IContainer Container { get; set; }

		internal static void SetupContainer()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterType<MenuCreator>().AsSelf();
			builder.RegisterType<BookRepository>().As<IRepository<Book>>().SingleInstance();

			Container = builder.Build();
		}
	}
}