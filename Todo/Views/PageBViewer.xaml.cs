using System;
using timesheet.Models;
using timesheet.Views;
using Xamarin.Forms;

namespace timesheet
{
	public partial class PageBViewer : ContentPage
	{
		public PageBViewer()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Reset the 'resume' id, since we just want to re-start here
			((App)App.Current).ResumeAtTodoId = -1;
			listView.ItemsSource = await App.Database.GetItemsAsync();
		}

		async void OnItemAdded(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PageACompiler
			{
				BindingContext = new TsItems()
			});
		}

		async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TsItems).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TsItems).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new PageACompiler
                {
                    BindingContext = e.SelectedItem as TsItems
                });
            }
		}
	}
}
