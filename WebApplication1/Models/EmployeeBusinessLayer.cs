using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;

namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployee()
        {
            //List<Employee> employees = new List<Employee>();
            //Employee emp = new Employee();
            //emp.Name = "阿1";
            //emp.Salary = 20000;
            //employees.Add(emp);

            //emp = new Employee();
            //emp.Name = "阿2";
            //emp.Salary = 10000;
            //employees.Add(emp);


            //emp = new Employee();
            //emp.Name = "阿3";
            //emp.Salary = 2000;
            //employees.Add(emp);

            //return employees;

            //SalesERPDAL salesDal = new SalesERPDAL();
            //return salesDal.Employees.ToList();

            using (SalesERPDAL dal = new SalesERPDAL())
            {

                var list = dal.Employees.ToList();
                return list;
            }




        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }

        public Employee Query(int id)
        {
            using (var db = new SalesERPDAL())
            {
                //return db.Employees.Find(id);
                Employee emp= db.Employees.Find(id);
                return emp;
            }
        }

        public void Add(Employee e)
        {
            using (var db = new SalesERPDAL())
            {
                db.Employees.Add(e);
                db.SaveChanges();
            }
        }


        public void Update(Employee e)
        {
            using (var db = new SalesERPDAL())
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new SalesERPDAL())
            {
                Employee emp = db.Employees.Find(id);
                db.Entry(emp).State = EntityState.Deleted;  
                db.SaveChanges();
            }
        }

        public List<Employee> Query(string name)
        {
            using (var db = new SalesERPDAL())
            {
                var emp = from b in db.Employees
                               where b.Name.Contains(name)
                               select b;
                return emp.ToList();
            }
        }

    }
}