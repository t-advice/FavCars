using FavCars;
using FavCars.Models;
using Microsoft.Maui.Storage;
using System.Formats.Tar;


namespace FavCars.Views;

public partial class AddCarPage : ContentPage
{
    private string _imagePath;

    public AddCarPage()
    {
        InitializeComponent();
    }

    // Upload picture from gallery
    private async void OnUploadPictureClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select a car picture"
            });

            if (result != null)
            {
                _imagePath = result.FullPath;
                CarImage.Source = _imagePath;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Unable to upload image: {ex.Message}", "OK");
        }
    }

    // Save car to database
    private async void OnSaveCarClicked(object sender, EventArgs e)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlert("Error", "Please enter the car name.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(YearEntry.Text) || !int.TryParse(YearEntry.Text, out int year))
        {
            await DisplayAlert("Error", "Please enter a valid numeric year.", "OK");
            return;
        }

        if (FuelPicker.SelectedItem == null)
        {
            await DisplayAlert("Error", "Please select a fuel type.", "OK");
            return;
        }

        // Create car object
        var car = new Car
        {
            Name = NameEntry.Text,
            Year = year,
            Engine = EngineEntry.Text,
            Color = ColorEntry.Text,
            FuelType = FuelPicker.SelectedItem.ToString(),
            ImagePath = _imagePath
        };

        // Save to SQLite
        await App.Database.SaveCarAsync(car);

        await DisplayAlert("Success", "Car saved!", "OK");

        // Navigate back to MainPage
        await Shell.Current.GoToAsync("..");
    }
}


