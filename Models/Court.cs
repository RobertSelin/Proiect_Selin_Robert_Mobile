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
    public class Court
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string CourtName { get; set; }   

        public string Adress { get; set; }  

        public string CourtDetails { get { return CourtName + " " + Adress; } }

        [OneToMany]
        public List<BookingList> BookingLists { get; set; }
    }
}
