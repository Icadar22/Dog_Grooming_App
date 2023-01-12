using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Dog_Grooming_App.Models
{
    public class Dog
    {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }

            [MaxLength(250), Unique]
            public string Name { get; set; }
            public string Description { get; set; }
            [OneToMany] 
            public List<DogList> DogLists { get; set; }

    }
}
