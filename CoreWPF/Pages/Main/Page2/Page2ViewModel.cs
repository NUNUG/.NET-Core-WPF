using System;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CoreWPF.Pages.Main.Page2
{
	public class Page2ViewModel : Screen, IMainScreen
	{
		public Page2ViewModel()
		{
			DisplayName = "Sub-page 2";
		}
	}
}