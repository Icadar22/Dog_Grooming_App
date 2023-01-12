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
        var alist = (AppointmentList)BindingContext;
        alist.Date = DateTime.UtcNow;
        await App.Database.SaveAppointmentListAsync(alist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var alist = (AppointmentList)BindingContext;
        await App.Database.DeleteAppointmentListAsync(alist);
        await Navigation.PopAsync();
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DogPage((AppointmentList)
       this.BindingContext)
        {
            BindingContext = new Dog()
        });

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var appointmentl = (AppointmentList)BindingContext;

        listView.ItemsSource = await App.Database.GetDogListsAsync(appointmentl.ID);
    }
}