using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataModel;

namespace SareeAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            return new List<Employee>()
            {
                new Employee{code="emp101",name="Tom",gender="Male",annualsalary=1456.52,dateofbirth="2/12/1983"},
                new Employee{ code= "emp102", name= "Suzi", gender= "Female", annualsalary= 2.9, dateofbirth= "10/25/1988" },
                new Employee{ code= "emp103", name= "Benson", gender= "Male", annualsalary= 5.5, dateofbirth= "5/7/1990" },
                new Employee{ code= "emp104", name= "Fluke", gender= "Female", annualsalary= 2.5, dateofbirth= "7/2/1997" },
                new Employee{ code= "emp105", name= "8Ball", gender= "Female", annualsalary= 2.5, dateofbirth= "7/2/1997" }
            };
        }
        public Employee Get(string id)
        {
            var emp = new List<Employee>()
            {
                new Employee{code="emp101",name="Tom",gender="Male",annualsalary=1456.52,dateofbirth="2/12/1983"},
                new Employee{ code= "emp102", name= "Suzi", gender= "Female", annualsalary= 2.9, dateofbirth= "10/25/1988" },
                new Employee{ code= "emp103", name= "Benson", gender= "Male", annualsalary= 5.5, dateofbirth= "5/7/1990" },
                new Employee{ code= "emp104", name= "Fluke", gender= "Female", annualsalary= 2.5, dateofbirth= "7/2/1997" },
                new Employee{ code= "emp105", name= "8Ball", gender= "Female", annualsalary= 2.5, dateofbirth= "7/2/1997" }
            };
            return emp.FirstOrDefault(m => m.code == id);
        }
    }
}
