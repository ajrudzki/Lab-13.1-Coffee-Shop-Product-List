using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Lab_13._2_Coffee_Shop_Product_List.Models;

namespace Lab_13._2_Coffee_Shop_Product_List.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=CoffeeShopLab;user id=testuser;password=abc123");
            db.Open();

            List<CoffeeShopLabTable> cslt = db.Query<CoffeeShopLabTable>("select * from CoffeeShopLabTable").AsList<CoffeeShopLabTable>();

            db.Close();

            return View(cslt);
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
