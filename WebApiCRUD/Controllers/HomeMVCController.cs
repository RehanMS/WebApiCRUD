using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Mvc;
using WebApiCRUD.Models;

namespace WebApiCRUD.Controllers
{
    public class HomeMVCController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            client.BaseAddress = new Uri("http://localhost:50531/api/HomeApi");
            var response = client.GetAsync("HomeApi");
            response.Wait();

            var  test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                employees = display.Result;
            }
            return View(employees);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            client.BaseAddress = new Uri("http://localhost:50531/api/HomeApi");
            var response = client.PostAsJsonAsync<Employee>("HomeApi", emp);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }
        [HttpGet]
        public ActionResult Details( int id)
        {
            Employee emp = null;
            client.BaseAddress = new Uri("http://localhost:50531/api/HomeApi");
            var response = client.GetAsync("HomeApi?id=" +id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                emp = display.Result;
            }
            return View(emp);
        }
        public ActionResult Edit(int id)
        {
            Employee emp = null;
            client.BaseAddress = new Uri("http://localhost:50531/api/HomeApi");
            var response = client.GetAsync("HomeApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                emp = display.Result;
            }
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            client.BaseAddress = new Uri("http://localhost:50531/api/HomeApi");
            var response = client.PutAsJsonAsync<Employee>("HomeApi",e);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        public ActionResult Delete( int id)
        {
            Employee emp = null;
            client.BaseAddress = new Uri("http://localhost:50531/api/HomeApi");
            var response = client.GetAsync("HomeApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                emp = display.Result;
            }
            return View(emp);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed( int id)
        {
            client.BaseAddress = new Uri("http://localhost:50531/api/HomeApi");
            var response = client.DeleteAsync("HomeApi/"+id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}