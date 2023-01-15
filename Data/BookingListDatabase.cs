using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using Proiect_Selin_Robert_Mobile.Models;

namespace Proiect_Selin_Robert_Mobile.Data
{
    public class BookingListDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public BookingListDatabase (string dbPath)
        {
            _database = new SQLiteAsyncConnection (dbPath);
            _database.CreateTableAsync<BookingList>().Wait();
            _database.CreateTableAsync<Sport>().Wait();
            _database.CreateTableAsync<ListSport>().Wait();
            _database.CreateTableAsync<Court>().Wait();
        }

        // pt sporturi preferate

        public Task<int> SaveSportAsync(Sport sport)
        {
            if (sport.ID != 0)
            {
                return _database.UpdateAsync(sport);
            }
            else
            {
                return _database.InsertAsync(sport);
            }
        }

        public Task<int> DeleteSportAsync(Sport sport)
        {
            return _database.DeleteAsync(sport);
        }

        public Task<List<Sport>> GetSportsAsync()
        {
            return _database.Table<Sport>().ToListAsync();
        }

        //sporturi preferate end

        public Task<List<BookingList>> GetBookingListsAsync()
        {
            return _database.Table<BookingList>().ToListAsync();
        }

        public Task<BookingList> GetBookingListAsync(int id)
        {
            return _database.Table<BookingList>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveBookingListAsync(BookingList blist)
        {
            if (blist.ID != 0)
            {
                return _database.UpdateAsync(blist);
            }
            else
            {
                return _database.InsertAsync(blist);
            }
        }

        public Task<int> DeleteShopListBookingListAsync(BookingList blist)
        {
            return _database.DeleteAsync(blist);
        }

        public Task<int> SaveListSportAsync(ListSport lists)
        {
            if (lists.ID != 0)
            {
                return _database.UpdateAsync(lists);
            }
            else
            {
                return _database.InsertAsync(lists);
            }
        }

        public Task<List<Sport>> GetListSportsAsync(int sportlistid)
        {
            return _database.QueryAsync<Sport>(
            "select S.ID, S.SportName from Sport S"
            + " inner join ListSport LS" 
            + " on S.ID = LS.SportID where LS.BookingListID = ?", 
            sportlistid);
        }

        // Court

        public Task<List<Court>> GetCourtsAsync()
        {
            return _database.Table<Court>().ToListAsync();
        }

        public Task<int> SaveCourtAsync(Court court)
        {
            if (court.ID != 0)
            {
                return _database.UpdateAsync(court);
            }
            else
            {
                return _database.InsertAsync(court);
            }

        }

    }
}
