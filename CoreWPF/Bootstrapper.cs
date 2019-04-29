using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Windows;
using CoreWPF.Pages.Shell;
using Unity;
using CoreWPF.Pages;
using CoreWPF.Pages.Main;
using CoreWPF.Pages.Main.Page1;
using CoreWPF.Pages.Main.Page2;
using MaterialDesignThemes.Wpf;

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

			Container.RegisterSingleton<IMainScreen, Page1ViewModel>("Page1");
			Container.RegisterSingleton<IMainScreen, Page2ViewModel>("Page2");

			Container.RegisterSingleton<ISnackbarMessageQueue, SnackbarMessageQueue>();
		}

		protected override object GetInstance(Type service, string key) => Container.Resolve(service, key);
		protected override IEnumerable<object> GetAllInstances(Type service) => Container.ResolveAll(service);
		protected override void BuildUp(object instance) => Container.BuildUp(instance);
		protected override void OnStartup(object sender, StartupEventArgs e) => DisplayRootViewFor<IShell>();
	}
}