using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class Test2Controller : Controller
    {
        // GET: Test2
        public ActionResult Index()
        {
            string greeting;
            DateTime dt = DateTime.Now;
            int h = dt.Hour;
            if (h < 12)
            {
                greeting = "早啊";
            }
            else
            {
                greeting = "好啊";
            }

           
            ViewBag.greeting = greeting;

            Employee emp = new Employee();
            emp.Name = "头牌啊红";
            emp.Salary = 20000;
            //ViewBag.Employee = emp;


            Customer cus = new Customer();
            cus.CustomerName = "明世隐";
            //cus.CustomerAddress = "峡谷栓狗";
            //ViewBag.Customer = cus;



            CustomerEmployeeViewModel cuvm = new CustomerEmployeeViewModel();
            cuvm.EmployeeName = emp.Name;
            cuvm.EmployeeSalary = emp.Salary;
            cuvm.CustomerName = cus.CustomerName;
            //cuvm.CustomerHobby = cus.CustomerAddress;


            return View(cuvm);

        }
    }
}