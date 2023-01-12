using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dog_Grooming_App.Models;




namespace Dog_Grooming_App.Data
{
    public class AppointmentListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public AppointmentListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AppointmentList>().Wait();
            _database.CreateTableAsync<Dog>().Wait();
            _database.CreateTableAsync<DogList>().Wait();
        }
        public Task<int> SaveDogAsync(Dog dog)
        {
            if (dog.ID != 0)
            {
                return _database.UpdateAsync(dog);
            }
            else
            {
                return _database.InsertAsync(dog);
            }
        }
        public Task<int> DeleteDogAsync(Dog dog)
        {
            return _database.DeleteAsync(dog);
        }
        public Task<List<Dog>> GetDogsAsync()
        {
            return _database.Table<Dog>().ToListAsync();
        }

        public Task<int> SaveDogListAsync(DogList listd)
        {
            if (listd.ID != 0)
            {
                return _database.UpdateAsync(listd);
            }
            else
            {
                return _database.InsertAsync(listd);
            }
        }

        public Task<int> DeleteDogListAsync(int dogId)
        {
            return _database.DeleteAsync<Dog>(dogId);
        }



        public Task<List<Dog>> GetDogListsAsync(int appointmentlistid)
        {
            return _database.QueryAsync<Dog>(
            "select D.ID, D.Description from Dog D"
            + " inner join DogList DL"
            + " on D.ID = DL.DogID where DL.AppointmentListID = ?",
            appointmentlistid);
        }



        public Task<List<AppointmentList>> GetAppointmentListsAsync()
        {
            return _database.Table<AppointmentList>().ToListAsync();
        }
        public Task<AppointmentList> GetAppointmentListAsync(int id)
        {
            return _database.Table<AppointmentList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveAppointmentListAsync(AppointmentList alist)
        {
            if (alist.ID != 0)
            {
                return _database.UpdateAsync(alist);
            }
            else
            {
                return _database.InsertAsync(alist);
            }
        }
        public Task<int> DeleteAppointmentListAsync(AppointmentList alist)
        {
            return _database.DeleteAsync(alist);
        }
    }
}