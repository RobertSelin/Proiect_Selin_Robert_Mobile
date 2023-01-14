using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Proiect_Selin_Robert_Mobile.Models
{
    public class BookingList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(500), Unique]
        public string PlanForTheWeek { get; set; }

        public DateTime Date { get; set; }
    }
}
