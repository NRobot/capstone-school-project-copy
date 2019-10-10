using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTVStreamingService.Models{
	public class Service{
		public int ID{get;set;}
		[StringLength(60, MinimumLength = 3), Required]
		public String name {get;set;}
		public double cost{get;set;}
	}
}