using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Lab_13._2_Coffee_Shop_Product_List.Models;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Lab_13._2_Coffee_Shop_Product_List.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View(DAL.Read());
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(string name, decimal price, string description, string category)
        {
            DAL.AddProduct(name, price, description, category);
            return RedirectToAction("Index", "Admin");
        }
        [HttpPost]
        public IActionResult DeleteProduct(long id)
        {
            return View(id);
        }
        [HttpPost]
        public IActionResult UpdateProduct(long id)
        {
            return View(id);
        }
    }
}
