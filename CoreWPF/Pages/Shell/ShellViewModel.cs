using Caliburn.Micro;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using MaterialDesignThemes.Wpf;

namespace CoreWPF.Pages.Shell
{
	public class ShellViewModel : Conductor<IApplicationScreen>.Collection.OneActive, IShell
	{
		private string _Title;
		public string Title
		{
			get => _Title;
			set { _Title = value; NotifyOfPropertyChange(nameof(Title)); }
		}

		public ISnackbarMessageQueue MessageQueue { get; }

		public ShellViewModel(IEnumerable<IApplicationScreen> screens, ISnackbarMessageQueue messageQueue)
		{
			DisplayName = "Shell View";
			Title = "Welcome to .NET Core 3 with WPF!";

			Items.AddRange(screens);

			MessageQueue = messageQueue;
		}

		protected override void OnActivate()
		{
			base.OnActivate();

			ActivateItem(Items.First());
		}

		public void ExitApp()
		{
			App.Current.Shutdown();
		}
	}
}