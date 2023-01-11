using Dog_Grooming_App.Models;
namespace Dog_Grooming_App;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (AppointmentList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveAppointmentListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (AppointmentList)BindingContext;
        await App.Database.DeleteAppointmentListAsync(slist);
        await Navigation.PopAsync();
    }
}