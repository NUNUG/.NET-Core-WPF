using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Windows;
using CoreWPF.Pages.Shell;
using Unity;
using CoreWPF.Pages;
using CoreWPF.Pages.Main;

namespace CoreWPF
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
		}

		protected override object GetInstance(Type service, string key) => Container.Resolve(service, key);
		protected override IEnumerable<object> GetAllInstances(Type service) => Container.ResolveAll(service);
		protected override void BuildUp(object instance) => Container.BuildUp(instance);
		protected override void OnStartup(object sender, StartupEventArgs e) => DisplayRootViewFor<IShell>();
	}
}