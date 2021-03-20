using aspdotnetCORETest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Net;
using aspdotnetCORETest.DataContracts;

namespace aspdotnetCORETest.Controllers
{
    [Route ("api/")]
    public class ApiContoller : Controller
    {
        private readonly ILogger<ApiContoller> _logger;

        public ApiContoller(ILogger<ApiContoller> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route ("worker")]
        public IActionResult Worker()
        {
            var client = new RestClient("http://dummy.restapiexample.com/api/v1");
            var request = new RestRequest("/employees", Method.GET);

            var response = client.Execute<GetEmployeesResponse>(request);


            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new BadRequestObjectResult(new Error
                {
                    Message = response.ErrorMessage,
                    Status = response.StatusCode
                });
            }

            List<Worker> workers = new List<Worker>();
            var orderedDescEmployees = response.Data.Data.OrderByDescending(x => x.employee_salary).ToList();
            orderedDescEmployees.ForEach(x => workers.Add(new Worker(x)));



            //var employees = response.Data.Data;

            //var orderedEmployees = from employee in employees
            //                       orderby employee.Salary descending
            //                       select employee;


            return new OkObjectResult(workers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
