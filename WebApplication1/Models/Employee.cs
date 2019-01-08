using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key] 
        public int Employeeld
        {
            get;
            set;
        }

        [Required(ErrorMessage ="请输入员工姓名")]
        [StringLength(3,ErrorMessage ="字符串长度不能少于3")]
        public string Name
        {
            get;
            set;
        }

        public int Salary
        {
            get;
            set;
        }
    }
}