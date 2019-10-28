using System;
using System.ComponentModel.DataAnnotations;

namespace MyTVStreamingService.Models
{
    public class Recommendation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QueryString { get; set; }
    }
}