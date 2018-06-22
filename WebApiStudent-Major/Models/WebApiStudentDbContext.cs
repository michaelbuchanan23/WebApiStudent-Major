using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiStudent_Major.Models {
	public class WebApiStudentDbContext: DbContext {

		public WebApiStudentDbContext() : base() { }

		public DbSet<Major> Majors{ get; set; }

		public DbSet<Student> Students { get; set; }
	}
}