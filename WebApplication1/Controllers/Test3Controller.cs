using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Test3Controller : Controller
    {
        // GET: Test3
        public ActionResult Index()
        {
            Employee emp = new Employee();
            emp.Name = "头牌小丽";
            emp.Salary = 20000;


            EmployeeViewModel evm = new EmployeeViewModel();
            evm.EmployeeName = emp.Name;
            evm.EmployeeSalary = emp.Salary.ToString("C");
            if (emp.Salary > 10000)
            {
                evm.EmployeeGrade = "土豪";
            }
            else
            {
                evm.EmployeeGrade = "屌丝";
            }
            //evm.UserName = "管理员阿香";


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
            //evm.Greeting = greeting;


            return View(evm);
        }
    }
}