using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebApiCRUD.Models;

namespace WebApiCRUD.Controllers
{
    public class HomeApiController : ApiController
    {
        RehanDBEntities1 db= new RehanDBEntities1();
        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult DetailsApi( int id)
        {
            var emp = db.Employees.Where(model => model.EmpId== id).FirstOrDefault();
            return Ok(emp);
        }
        [HttpPost]
        public IHttpActionResult Insert( Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(Employee e)
        {
            db.Entry(e).State = EntityState.Modified;
            db.SaveChangesAsync();
           //var emp = db.Employees.Where(model=>model.EmpId==e.EmpId).FirstOrDefault();
           // if(emp!=null)
           // {
           //     emp.EmpId = e.EmpId;
           //     emp.EmpName = e.EmpName;
           //     emp.Salary= e.Salary;
           //     emp.Job = e.Job;   
           //     emp.Dname = e.Dname;
           //     db.SaveChangesAsync();
           // }
           // else
           // {
           //     return NotFound();
           // }
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var emp = db.Employees.Where(model => model.EmpId == id).FirstOrDefault();
            db.Entry(emp).State = EntityState.Deleted;
            db.SaveChangesAsync();
            return Ok();
        }
    }
}
