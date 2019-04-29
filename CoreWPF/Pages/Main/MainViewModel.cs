using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;
using Caliburn.Micro;
using CoreWPF.Commands;

namespace CoreWPF.Pages.Main
{
	public class MainViewModel : Conductor<IMainScreen>.Collection.OneActive, IApplicationScreen
	{
		private bool _IsMenuOpen;
		public bool IsMenuOpen
		{
			get => _IsMenuOpen;
			set { _IsMenuOpen = value; NotifyOfPropertyChange(nameof(IsMenuOpen)); }
		}

		public ICommand SelectPage { get; }

		public MainViewModel(IEnumerable<IMainScreen> screens)
		{
			IsMenuOpen = false;

			Items.AddRange(screens);

			SelectPage = new SimpleCommand<IMainScreen>(screen =>
			{
				ActivateItem(screen);
				IsMenuOpen = false;
			});
		}

		protected override void OnActivate()
		{
			base.OnActivate();

			ActivateItem(Items.First());
		}

		public async Task OpenDrawer() => IsMenuOpen = !IsMenuOpen;
	}
}