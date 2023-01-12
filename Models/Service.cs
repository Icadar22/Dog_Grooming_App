using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dog_Grooming_App.Models
{
    public class Service
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ImageSource Image { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
    }

}
