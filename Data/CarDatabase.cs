using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using FavCars.Models;

namespace FavCarsAppShell.Data;

public class CarDatabase
{
    readonly SQLiteAsyncConnection _database; // SQLite connection

    public CarDatabase(string dbPath)  // Constructor
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Car>().Wait();
    }

    // Get all cars method 
    public Task<List<Car>> GetCarsAsync() 
    {
        return _database.Table<Car>().ToListAsync();
    }

    // Get a single car
    public Task<Car> GetCarAsync(int id)
    {
        return _database.Table<Car>().Where(c => c.id == id).FirstOrDefaultAsync();
    }

    // Save car (insert or update)
    public Task<int> SaveCarAsync(Car car)
    {
        if (car.id != 0)
            return _database.UpdateAsync(car);
        else
            return _database.InsertAsync(car);
    }

    // Delete car
    public Task<int> DeleteCarAsync(Car car)
    {
        return _database.DeleteAsync(car);
    }
}

