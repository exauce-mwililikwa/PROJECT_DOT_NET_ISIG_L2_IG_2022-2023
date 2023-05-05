using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication5.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class StudentController : Controller
    {
     static IList<Student> listeEdutiant = new List<Student> { 
     new Student {nom="MUHINDO",postNom="MALEANI",sexe="M" },
     new Student {nom="KITO",postNom="BUTANDA",sexe="F" },
     new Student {nom="MUHINDO",postNom="KISUBA",sexe="M" },
     new Student {nom="ENGIKASI",postNom="DEBORAH",sexe="F" },
     new Student {nom="IRAGI",postNom="KATORO",sexe="M" },
     };
           


        public IActionResult Index()
        {
            ViewData["student"] = listeEdutiant;
            return View();
        }
    }
}
