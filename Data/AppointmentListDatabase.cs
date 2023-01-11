using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
        public Task<int> SaveAppointmentListAsync(AppointmentList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteAppointmentListAsync(AppointmentList slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
