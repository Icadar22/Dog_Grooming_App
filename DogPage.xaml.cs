using Dog_Grooming_App.Models;
using Dog_Grooming_App.Data;
namespace Dog_Grooming_App;

public partial class DogPage : ContentPage
{
    AppointmentList al;
    public DogPage(AppointmentList alist)
    {
        InitializeComponent();
        al = alist;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var dog = (Dog)BindingContext;
        await App.Database.SaveDogAsync(dog);
        listView.ItemsSource = await App.Database.GetDogsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var dog = (Dog)BindingContext;
        await App.Database.DeleteDogAsync(dog);
        listView.ItemsSource = await App.Database.GetDogsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetDogsAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Dog d;
        if (listView.SelectedItem != null)
        {
            d = listView.SelectedItem as Dog;
            var dl = new DogList()
            {
                AppointmentListID = al.ID,
                DogID = d.ID
            };
            await App.Database.SaveDogListAsync(dl);
            d.DogLists = new List<DogList> { dl };
            await Navigation.PopAsync();
        }

    }

    async void OnRemoveButtonClicked(object sender, EventArgs e)
    {
        var selectedDog = listView.SelectedItem as Dog;
        if (selectedDog != null)
        {
            await App.Database.DeleteDogListAsync(selectedDog.ID);
            await Navigation.PopAsync();
        }
    }

}

