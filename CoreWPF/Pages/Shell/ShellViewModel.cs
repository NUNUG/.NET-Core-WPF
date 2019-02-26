using Caliburn.Micro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWPF.Pages.Shell
{
	public class ShellViewModel : Screen, IShell
	{
		private string _Title;
		public string Title
		{
			get => _Title;
			set { _Title = value; NotifyOfPropertyChange(nameof(Title)); }
		}

		public ShellViewModel()
		{
			DisplayName = "Shell View";
			Title = "Welcome to .NET Core 3 with WPF!";
		}

		public async Task ExitApp()
		{
			App.Current.Shutdown();
		}
	}
}