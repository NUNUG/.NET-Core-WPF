using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CoreWPF.Pages.Main.Page2
{
	public class Page2ViewModel : Screen, IMainScreen
	{
		public ObservableCollection<string> Topics { get; }

		public Page2ViewModel()
		{
			DisplayName = "Sub-page 2";

			Topics = new ObservableCollection<string>();
		}

		public void OnRemove(string topic) => Topics.Remove(topic);

		protected override void OnActivate()
		{
			base.OnActivate();

			Topics.Clear();
			Topics.Add(".NET Core & WPF");
			Topics.Add("Using Caliburn with .NET Core");
			Topics.Add("Using Unity with .NET Core");
			Topics.Add("Using Material Design with .NET Core");
			Topics.Add("Creating Pages with .NET Core");
		}
	}
}