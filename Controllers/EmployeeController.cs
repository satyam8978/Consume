using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Consume.Models;
using Newtonsoft.Json;
using Consume.Repositry;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Consume.Controllers
{
    public class EmployeeController : Controller
    {
        string Baseurl = "https://localhost:5001/";

        public async Task<IActionResult> IndexAsync()
        {
            List<Employee> EmployeInfo = new List<Employee>();
            using (var client = new HttpClient())
            {
                //Passing service base url

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/EmployeeDetails/");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    EmployeInfo = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);
                }
                //returning the employee list to view
                return View(EmployeInfo);
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(string empid)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/EmployeeDetails/" + empid);
            response.EnsureSuccessStatusCode();
            Models.Employee products = response.Content.ReadAsAsync<Models.Employee>().Result;
            ViewBag.Title = "All Project";
            return View(products);
        }

        [HttpPost]

        public ActionResult Create(Models.Employee project)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/EmployeeDetails/", project);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");



        }

        public ActionResult Edit(string empid)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/EmployeeDetails/" + empid);
            response.EnsureSuccessStatusCode();
            var products = response.Content.ReadAsAsync<Models.Emp>().Result;
            ViewBag.Title = "All Project";
            return View(products);
        }
        //[HttpPut] 
        public ActionResult Update(Models.Employee emp)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/EmployeeDetails/", emp);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
 
        public ActionResult Delete( string EmpId)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/EmployeeDetails/" + EmpId);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        }
}