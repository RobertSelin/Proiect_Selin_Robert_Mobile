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
    public class Sport
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string SportName { get; set; }

        [OneToMany]
        public List<ListSport> ListSports { get; set; }
    }
}
