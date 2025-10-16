using FavCars.Models;
using FavCars.Views;
using System.Linq;

namespace FavCars.Views;

public partial class MainPage : ContentPage
{
    

    public MainPage()
    {
        InitializeComponent();
        LoadCarsAsync();
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
    private async Task LoadCarsAsync()
    {
        var cars = await App.Database.GetCarsAsync();
        CarsCollectionView.ItemsSource = cars;
    }




    //private async void OnCarSelected(object sender, SelectionChangedEventArgs e)
    //{
    //    var car = e.CurrentSelection.FirstOrDefault() as Car;
    //    if (car == null) return; // No selection

    //    await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?{nameof(CarDetailsPage.Id)}?CarId={car.id}");
    //    ((CollectionView)sender).SelectedItem = null; // Deselect item
    //}

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private async void OnDeleteCarClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Car car)
        {
            // Animate the button for a cool effect
            //await button.ScaleTo(0.9, 80, Easing.CubicIn);
            //await button.ScaleTo(1.0, 80, Easing.CubicOut);

            bool confirm = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete {car.Name}?", "Yes", "No");
            if (!confirm)
                return;

            await App.Database.DeleteCarAsync(car); // Remove from SQLite
            await LoadCarsAsync();                  // Refresh list

            await DisplayAlert("Deleted", $"{car.Name} has been removed.", "OK");
        }

    }
    private async void OnCarSelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedCar = e.CurrentSelection.FirstOrDefault() as Car;
        if (selectedCar == null)
            return;

        await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?carId={selectedCar.Id}");
        ((CollectionView)sender).SelectedItem = null; // clear selection
    }

}
