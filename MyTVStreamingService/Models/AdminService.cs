using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTVStreamingService.Models
{
    public class AdminService
    {
        public int Id { get; set; }
        public string Service { get; set; }
        public decimal Price { get; set; }
        public ICollection<AdminNetwork> AdminNetworks { get; set; }
    }
}
