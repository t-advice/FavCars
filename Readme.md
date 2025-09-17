# FavCars (.NET MAUI App)

FavCars is a **.NET MAUI cross-platform app** that allows users to manage their favorite cars.  
Users can **view a list of cars, add new cars (with image, name, year, engine, fuel type, and color), and see details for each car**.  

The app uses **SQLite** as a local embedded database and supports running on **Android emulator, Windows, and other MAUI targets**.

---

# Features

- **Car List**: Displays all saved cars with picture, name, and year.
- **Car Details**: Tap a car to see more info (engine, fuel type, color, year).
- **Add Car**: Add a new car with image and details.
- **SQLite Storage**: Cars are persisted locally using `sqlite-net-pcl`.
- **Image Picker**: Upload a picture from device storage.
- **AppShell Navigation**: Uses Shell for clean page navigation.
- **Export DB (Debug Tool)**: Copy or export the SQLite database for inspection.

---

## Tech Stack

- [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/) (Cross-platform UI)
- [SQLite-net-pcl](https://www.nuget.org/packages/sqlite-net-pcl) (Local database)
- C# 12 / XAML
- Android Emulator (for testing)

---

## Project Structure
FavCars/
│
├── App.xaml / App.xaml.cs # Global app configuration
├── AppShell.xaml / AppShell.xaml.cs # Shell navigation setup
│
├── Models/
│ └── Car.cs # Car model (Id, Name, Year, Engine, Fuel, Color, ImagePath)
│
├── Data/
│ └── CarDatabase.cs # SQLite database handler
│
├── Views/
│ ├── MainPage.xaml(.cs) # Car list + Add button
│ ├── CarDetailPage.xaml(.cs) # Detailed view of a single car
│ └── AddCarPage.xaml(.cs) # Add new car form
│
└── Resources/Images/ # App images/icons

## Setup & Installation

1. **Clone the repo**

   ```sh
   git clone https://github.com/yourusername/FavCars.git
   cd FavCars

###### Author - Tashwill Advice  #########
