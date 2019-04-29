using Caliburn.Micro;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace $safeprojectname$.Pages.Shell
{
	public class ShellViewModel : Conductor<IApplicationScreen>.Collection.OneActive, IShell
	{
		private string _Title;
		public string Title
		{
			get => _Title;
			set { _Title = value; NotifyOfPropertyChange(nameof(Title)); }
		}

		public ShellViewModel(IEnumerable<IApplicationScreen> screens)
		{
			DisplayName = "Shell View";
			Title = "Welcome to .NET Core 3 with WPF!";

			Items.AddRange(screens);
		}

		protected override void OnActivate()
		{
			base.OnActivate();

			ActivateItem(Items.First());
		}

		public async Task ExitApp()
		{
			App.Current.Shutdown();
		}
	}
}