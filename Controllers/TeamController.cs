using Consume.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Consume.Models;
using Newtonsoft.Json;
namespace Consume.Controllers
{
    public class TeamController : Controller
    {
        string Baseurl = "https://localhost:5001/";
        public async Task<IActionResult> IndexAsync()
        {
            List<Team> TeamInfo = new List<Team>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/TeamDetails/");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    TeamInfo = JsonConvert.DeserializeObject<List<Team>>(EmpResponse);
                }
                //returning the employee list to view
                return View(TeamInfo);
            }
        }
    }
}
