using System;
using timesheet.Models;
using Xamarin.Forms;

namespace timesheet.Views
{
	public partial class PageACompiler : ContentPage
	{
		public PageACompiler()
		{
			InitializeComponent();
		}

		async void OnSaveClicked(object sender, EventArgs e)
		{
			var todoItem = (TsItems)BindingContext;
			await App.Database.SaveItemAsync(todoItem);
            await Navigation.PushAsync(new PageBViewer
            {
                BindingContext = new TsItems()
            });
        }

		async void OnDeleteClicked(object sender, EventArgs e)
		{
			var todoItem = (TsItems)BindingContext;
			await App.Database.DeleteItemAsync(todoItem);
			await Navigation.PopAsync();
		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		void OnSpeakClicked(object sender, EventArgs e)
		{
			var todoItem = (TsItems)BindingContext;
			DependencyService.Get<ITextToSpeech>().Speak(todoItem.Hours + " " + todoItem.Description);
		}
	}
}
