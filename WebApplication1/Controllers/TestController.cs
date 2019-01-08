using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string GetString()
        {
            return "你好,MVC!";
        }


        public Customer getCustomer()
        {
            Customer ct = new Customer();
            ct.CustomerName = "abc";
            //ct.CustomerAddress = "def";
            return ct;
        }

        public ActionResult GetView()
        {
            string greeting;
            DateTime dt = DateTime.Now;
            int h = dt.Hour;
            if (h < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "好";
            }

            //ViewData["greeting"] = greeting;
            ViewBag.greeting = greeting;
            Employee emp = new Employee();
            emp.Name = "李二狗";
            emp.Salary = 20000;
            //ViewData["Employee"] = emp;
            ViewBag.Employee = emp;
            return View("MyView",emp);
           
        }

    }
}