using System;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace $safeprojectname$.Pages.Main.Page1
{
	public class Page1ViewModel : Screen, IMainScreen
	{
		public Page1ViewModel()
		{
			DisplayName = "Sub-page 1";
		}
	}
}