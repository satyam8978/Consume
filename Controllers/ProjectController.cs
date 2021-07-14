using Microsoft.AspNetCore.Mvc;
using System;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Consume.Models;
using Newtonsoft.Json;

namespace Consume.Controllers
{
    public class ProjectController : Controller
    {
        string Baseurl = "https://localhost:5001/";
        public async Task<IActionResult> IndexAsync()
        {
            List<Projects> ProjectInfo = new List<Projects>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/ProjectDetails/");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ProjectInfo = JsonConvert.DeserializeObject<List<Projects>>(EmpResponse);
                }
                //returning the employee list to view
                return View(ProjectInfo);
            }
        }
    }
}
