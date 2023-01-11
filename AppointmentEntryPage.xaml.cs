using Dog_Grooming_App.Models;

namespace Dog_Grooming_App;

public partial class AppointmentEntryPage : ContentPage
{
	public AppointmentEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetAppointmentListsAsync();
    }
    async void OnAppointmentListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPage
        {
            BindingContext = new AppointmentList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = e.SelectedItem as AppointmentList
            });
        }
    }
}