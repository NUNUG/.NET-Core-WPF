using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Windows;
using $safeprojectname$.Pages.Shell;
using Unity;
using $safeprojectname$.Pages;
using $safeprojectname$.Pages.Main;
using $safeprojectname$.Pages.Main.Page1;
using $safeprojectname$.Pages.Main.Page2;

namespace $safeprojectname$
{
	public class Bootstrapper : BootstrapperBase
	{
		private IUnityContainer Container { get; }

		public Bootstrapper()
		{
			Container = new UnityContainer();

			Initialize();
		}

		protected override void Configure()
		{
			Container.RegisterSingleton<IWindowManager, WindowManager>();
			Container.RegisterSingleton<IEventAggregator, EventAggregator>();

			Container.RegisterSingleton<IShell, ShellViewModel>();
			Container.RegisterSingleton<IApplicationScreen, MainViewModel>();

			Container.RegisterSingleton<IMainScreen, Page1ViewModel>("Page1");
			Container.RegisterSingleton<IMainScreen, Page2ViewModel>("Page2");
		}

		protected override object GetInstance(Type service, string key) => Container.Resolve(service, key);
		protected override IEnumerable<object> GetAllInstances(Type service) => Container.ResolveAll(service);
		protected override void BuildUp(object instance) => Container.BuildUp(instance);
		protected override void OnStartup(object sender, StartupEventArgs e) => DisplayRootViewFor<IShell>();
	}
}