using System.Net;
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

            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(list, camelCaseFormatter),
                ContentType = "application/json"
            };

            return jsonResult;
        }

        public ActionResult Create(EmployeeVM employeeVm)
        {
            //Validate the employeeVm
            if (ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Created, "New employee added");
            }

            var errors = new List<string> {"Insert failed."};
            if (!ModelState.IsValidField("Notes"))
            {
                errors.Add("Notes must be at least 5 characters long.");
            }

            var s = string.Join("\n", errors);

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, string.Join("  ", errors));
        }
    }
}