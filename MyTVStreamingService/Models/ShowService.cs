using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTVStreamingService.Models{
	public class ShowService{
		public int ID{get;set;}
		[ForeignKey("Show")]
		public int ShowFK{get;set;}
		[ForeignKey("Service")]
		public int ServiceFK{get;set;}
	}
}