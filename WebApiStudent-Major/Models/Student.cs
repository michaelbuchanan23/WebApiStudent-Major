using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiStudent_Major.Models {
	public class Student {

		public int Id { get; set; }
		public string Name { get; set; }
		public int SAT { get; set; }
		public int MajorId { get; set; }
		public virtual Major major { get; set; }

		public Student() { }
	}
}