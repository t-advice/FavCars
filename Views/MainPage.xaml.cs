using FavCars.Models;
using FavCars.Views;
using System.Linq;

namespace FavCars.Views;

public partial class MainPage : ContentPage
{
    

    public MainPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CarsCollectionView.ItemsSource = await App.Database.GetCarsAsync();
    }
    private async void OnAddCarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddCarPage));
    
    }
    private async void OnCarSelected(object sender, SelectionChangedEventArgs e)
    {
        var car = e.CurrentSelection.FirstOrDefault() as Car;
        if (car == null) return; // No selection

        await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?{nameof(CarDetailsPage.Id)}?CarId={car.id}");
        ((CollectionView)sender).SelectedItem = null; // Deselect item
    }
}
