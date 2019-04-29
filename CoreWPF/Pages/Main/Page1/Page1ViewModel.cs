using System;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using MaterialDesignThemes.Wpf;

namespace CoreWPF.Pages.Main.Page1
{
	public class Page1ViewModel : Screen, IMainScreen
	{
		private int _Rating;
		public int Rating
		{
			get => _Rating;
			set { _Rating = value; NotifyOfPropertyChange(nameof(Rating)); }
		}

		protected ISnackbarMessageQueue MessageQueue { get; }
		private Random RND {get;}

		public Page1ViewModel(ISnackbarMessageQueue messageQueue)
		{
			DisplayName = "Sub-page 1";

			MessageQueue = messageQueue;
			RND = new Random();
		}

		public void RatingChanged()
		{
			if(Rating < 3)
				MessageQueue.Enqueue("Thanks for rating, I guess. I'll try to do better next time.");
			else if(Rating == 3)
				MessageQueue.Enqueue("Well, at least it didn't suck, right?");
			else
				MessageQueue.Enqueue("Hurray, people are paying attention to me!");
		}

		protected override void OnActivate()
		{
			base.OnActivate();

			MessageQueue.Enqueue("It Works!", "Toast Again!", MakeToast);
		}

		private void MakeToast()
		{
			int next = RND.Next(0, Messages.Length);
			MessageQueue.Enqueue(Messages[next], "Toast Again!", MakeToast);
		}

		private static string[] Messages = new string[]
		{
			"Material Design for the win!",
			"Why are toasts called snack bars in Material Design?",
			"Mmmm. Toast.",
			"A snackbar sounds like a great idea. Nate, make it happen!",
			"NUNUG is great!",
			"What on earth is Phil doing?"
		};
	}
}