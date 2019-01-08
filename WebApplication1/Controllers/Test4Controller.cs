using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;
using WebApplication1.DataAccessLayer;

namespace WebApplication1.Controllers
{
    public class Test4Controller : Controller
    {
        // GET: Test4
        public ActionResult Index()
        {

            EmployeeListViewModel eLVM = new EmployeeListViewModel();
            //实例化员工信息业务层
            EmployeeBusinessLayer eBL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listE = eBL.GetEmployee();
            eLVM.EmployeeListView = getEmpVmlist(listE);
            eLVM.UserName = getUserName();
            eLVM.Greeting = getGreetomg();

            return View(eLVM);
        }

        public ActionResult CreateEmployee()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee e,string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                //case "保存":
                //    return Content("姓名：" + e.Name + "，工资：" + e.Salary);
                //case "取消":
                //    return RedirectToAction("Index");
                case "保存":
                    {
                        if (ModelState.IsValid)
                        {
                            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                            //empBal.SaveEmployee(e);
                            empBal.Add(e);
                            return RedirectToAction("Index");
                        }
                       else
                        {
                            return View("CreateEmployee");
                        }
                  
                    }
                case "取消":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
            //return (e.Name + e.Salary);
            //return new RedirectResult("Index");

        }

        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            empBal.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Updatep(int id)
        {
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            Employee query = empBal.Query(id);
            return View(query);

        }

        [HttpPost]
        public ActionResult Updatep(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "更新":
                    {
                        if (ModelState.IsValid)
                        {
                            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                            empBal.Update(e);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return View("Updatep");
                        }

                    }
                case "取消":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();

        }


        public ActionResult Select(string name)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            var qu= ebl.Query(name);
            EmployeeListViewModel eLVM = new EmployeeListViewModel();
            eLVM.EmployeeListView = getEmpVmlist(qu);
            eLVM.UserName = getUserName();
            eLVM.Greeting = getGreetomg();

            return View("Index",eLVM);
            
        }
  


        [NonAction]
        List<EmployeeViewModel> getEmpVmlist(List<Employee> listE)
        {
           
            //员工原始数据加工后的视图数据列表，当前状态是空的
            var listEVM = new List<EmployeeViewModel>();
            //通过循环遍历员工原始数据数组，将数据一个一个的转换，并加入
            foreach (var item in listE)
            {
                EmployeeViewModel eVMObj = new EmployeeViewModel();
                eVMObj.EmployeeId = item.Employeeld;
                eVMObj.EmployeeName = item.Name;
                eVMObj.EmployeeSalary = item.Salary.ToString("C");
                if (item.Salary > 10000)
                {
                    eVMObj.EmployeeGrade = "土豪";
                }
                else
                {
                    eVMObj.EmployeeGrade = "屌丝";
                }
                listEVM.Add(eVMObj);
            }
            return listEVM;
        }


        [NonAction]
        string getGreetomg()
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
            return greeting;
        }


        [NonAction]
        string getUserName()
        {
            string username = "管理员阿香";
            return username;
        }

       

        

    }

}