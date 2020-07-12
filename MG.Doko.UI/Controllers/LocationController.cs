using MG.Doko.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MG.Doko.UI.Controllers
{
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<EmployeeLocation> employeeList = new List<EmployeeLocation>();

            var client = _httpClientFactory.CreateClient("api");

            var response = client.GetAsync("location/getallemployeelocations");

            var apiResponse = response.Result.Content.ReadAsStringAsync();

            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                employeeList = JsonConvert.DeserializeObject<List<EmployeeLocation>>(apiResponse.Result);
            }
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult Create(string applicationUserId)
        {
            var model = new LocationCreate();
            if (applicationUserId != null)
            {
                model.ApplicationUserId = applicationUserId;
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(LocationCreate viewModel)
        {
            var client = _httpClientFactory.CreateClient("api");

            var content = new StringContent(JsonConvert.SerializeObject(viewModel), System.Text.Encoding.UTF8, "application/json");
            //client.DefaultRequestHeaders
            //      .Accept
            //      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(""))

            var result = await client.PostAsync("location", content);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(LocationEdit viewModel)
        {
            var model = new LocationEdit();
            model.ApplicationUserId = viewModel.ApplicationUserId;
            model.CurrentLocation = viewModel.CurrentLocation;

            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditPost(LocationEdit viewModel)
        {
            var client = _httpClientFactory.CreateClient("api");

            var content = new JsonPatchDocument<LocationEdit>();
            content.Replace(e => e.CurrentLocation, viewModel.CurrentLocation);

            var serializeItemToUpdate = JsonConvert.SerializeObject(content);
            var response = await client.PatchAsync("location/UpdateEmployeeLocation/" + viewModel.ApplicationUserId, new StringContent(serializeItemToUpdate, System.Text.Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}