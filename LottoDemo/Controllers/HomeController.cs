using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LottoDemo.Models;
using System.Data;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;

namespace LottoDemo.Controllers;

public class HomeController : Controller
{
    
    readonly string baseURL = "https://data.api.thelott.com/sales/vmax/web/data/lotto/";
    readonly string opendraw = "opendraws";

    

    public async Task<IActionResult> Index()  {
                  

        var postData = new PostData
        {
            CompanyId = "GoldenCasket",
            MaxDrawCount = 20,
            OptionalProductFilter =  new List<string> { "TattsLotto", "Powerball", "OzLotto" }
            
        };
        LottoResponse lotteryresponse = new LottoResponse();

        using ( var client = new HttpClient())
        {

            //calling the lotto API for open draws  
            client.BaseAddress = new Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Clear();           
            var json = JsonConvert.SerializeObject(postData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(opendraw, content).Result;
           
           
            if(response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;


                lotteryresponse = JsonConvert.DeserializeObject<LottoResponse>(results);
            }
            else
            {
                Console.WriteLine("Error:" + response.StatusCode);
            }

            ViewData.Model = lotteryresponse;
        }


            return View();
            
    }

   

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

