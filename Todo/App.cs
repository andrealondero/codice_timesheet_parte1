using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using timesheet.Views;
using timesheet.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace timesheet
{
	public class App : Application
	{
		static DBHelper database;

		public App()
		{
			Resources = new ResourceDictionary();
			Resources.Add("primaryGray", Color.FromHex("E5E9EA"));
			Resources.Add("primaryDarkGray", Color.FromHex("2D2A2A"));
            Resources.Add("primaryAqua", Color.FromHex("83D3D4"));
            Resources.Add("primaryDarkAqua", Color.FromHex("2D8183"));
            Resources.Add("primaryRed", Color.FromHex("FF5657"));
            Resources.Add("primaryDarkRed", Color.FromHex("910C07"));

            var nav = new NavigationPage(new DashBoardPage());
			nav.BarBackgroundColor = (Color)App.Current.Resources["primaryDarkRed"];
			nav.BarTextColor = Color.White;

			MainPage = nav;
		}

		public static DBHelper Database
		{
			get
			{
				if (database == null)
				{
                    database = new DBHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
				}
				return database;
			}
		}

		public int ResumeAtTodoId { get; set; }

		protected override void OnStart()
		{
			//Debug.WriteLine("OnStart");

			//// always re-set when the app starts
			//// users expect this (usually)
			////			Properties ["ResumeAtTodoId"] = "";
			//if (Properties.ContainsKey("ResumeAtTodoId"))
			//{
			//	var rati = Properties["ResumeAtTodoId"].ToString();
			//	Debug.WriteLine("   rati=" + rati);
			//	if (!String.IsNullOrEmpty(rati))
			//	{
			//		Debug.WriteLine("   rati=" + rati);
			//		ResumeAtTodoId = int.Parse(rati);

			//		if (ResumeAtTodoId >= 0)
			//		{
			//			var todoPage = new PageACompiler();
			//			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
			//			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
			//		}
			//	}
			//}
		}

		protected override void OnSleep()
		{
			//Debug.WriteLine("OnSleep saving ResumeAtTodoId = " + ResumeAtTodoId);
			//// the app should keep updating this value, to
			//// keep the "state" in case of a sleep/resume
			//Properties["ResumeAtTodoId"] = ResumeAtTodoId;
		}

		protected override void OnResume()
		{
			//Debug.WriteLine("OnResume");
			//if (Properties.ContainsKey("ResumeAtTodoId"))
			//{
			//	var rati = Properties["ResumeAtTodoId"].ToString();
			//	Debug.WriteLine("   rati=" + rati);
			//	if (!String.IsNullOrEmpty(rati))
			//	{
			//		Debug.WriteLine("   rati=" + rati);
			//		ResumeAtTodoId = int.Parse(rati);

			//		if (ResumeAtTodoId >= 0)
			//		{
			//			var todoPage = new PageACompiler();
			//			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
			//			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
			//		}
			//	}
			//}
		}
	}
}

