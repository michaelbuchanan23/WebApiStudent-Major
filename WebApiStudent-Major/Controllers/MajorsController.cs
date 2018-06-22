using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiStudent_Major.Models;
using WebApiStudent_Major.Utility;

namespace WebApiStudent_Major.Controllers {
	public class MajorsController : ApiController {

		private WebApiStudentDbContext db = new WebApiStudentDbContext();


		public MajorsController() { }

		//GET-ALL
		//indicates that a get method will be used to get this info vs. post which updates
		[HttpGet]
		[ActionName("List")] //this is the name the client will use to call this method
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.Majors.ToList()
			};
		}

		//GET-ONE
		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Major(int? id) {
			if (id == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Id does not exist"
				};
			}
			return new JsonResponse {
				Data = db.Majors.Find(id)
			};
		}

		//POST
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(Major major) {
			if (major == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of Major"
				};
			}
			if (!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Majors.Add(major);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = major
			};
		}

		//CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(Major major) {
			if (major == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of Major"
				};
			}
			if (!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(major).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = major
			};
		}
		//DELETE
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(Major major) {
			if (major == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Remove requires an instance of Major"
				};
			}
			if (!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(major).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = major
			};
		}
		[HttpGet]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if (id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a Major.Id"
				};
			var major = db.Majors.Find(id);
			if (major == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No major has Id of {id}"
				};
			db.Majors.Remove(major);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = major
			};
		}
	}
}
