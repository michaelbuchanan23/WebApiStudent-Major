﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiStudent_Major.Models {
	public class Major {

		public int Id { get; set; }
		public string Description { get; set; }
		public int MinSat { get; set; }

		public Major() { }
	}
}