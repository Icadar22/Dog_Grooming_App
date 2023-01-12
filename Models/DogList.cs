using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Dog_Grooming_App.Models
{
    public class DogList
    {
        [PrimaryKey, AutoIncrement] 
        public int ID { get; set; }
        [ForeignKey(typeof(AppointmentList))] 
        public int AppointmentListID { get; set; }
        public int DogID { get; set; }
    }
}
