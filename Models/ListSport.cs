using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Selin_Robert_Mobile.Models
{
    public class ListSport
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(BookingList))]
        public int BookingListID { get; set; }

        public int SportID { get; set; }
    }
}
