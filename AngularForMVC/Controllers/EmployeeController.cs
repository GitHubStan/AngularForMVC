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
            return new HttpStatusCodeResult(201, "New employee added");
        }
    }
}