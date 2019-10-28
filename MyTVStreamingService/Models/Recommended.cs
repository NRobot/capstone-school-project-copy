using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTVStreamingService.Models
{
    public class Recommended
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public string show { get; set; }
        public int count { get; set; }
    }
}
