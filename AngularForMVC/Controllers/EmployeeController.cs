using System.Net;
using System.Web.Configuration;
using AngularForMVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AngularForMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult GetEmployees()
        {
            var list = new List<EmployeeVM>
            {
                new EmployeeVM
                {
                    FullName = "Milton Waddams"
                },
                new EmployeeVM
                {
                    FullName = "Andy Bernard"
                }
            };

            return GetJsonContentResult(list);
        }

        public ActionResult Create(EmployeeVM employeeVm)
        {
            //Validate the employeeVm
            if (ModelState.IsValid)
            {
                var id = new {id = 12345}; //Hardcoded for now. ID will come from the database.
                return GetJsonContentResult(id);
            }

            var errors = new List<string> {"Insert failed."};
            if (!ModelState.IsValidField("Notes"))
            {
                errors.Add("Notes must be at least 5 characters long.");
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, string.Join("  ", errors));
        }

        public ActionResult Update(EmployeeVM employeeVm)
        {
            //Validate the employeeVm
            if (ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Update success.");
            }

            var errors = new List<string> {"Update failed."};
            if (!ModelState.IsValidField("Notes"))
            {
                errors.Add("Notes must be at least 5 characters long.");
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, string.Join("  ", errors));
        }

        public ContentResult GetJsonContentResult(object data)
        {
            var camelCaseFormatter = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(data, camelCaseFormatter),
                ContentType = "application/json"
            };

            return jsonResult;
        }
    }
}