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
        [HttpGet]
        public IActionResult Index()
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=[Coffee Shop Lab];user id=testuser;password=abc123");
            db.Open();

            List<CoffeeShopLabTable> cslt = db.Query<CoffeeShopLabTable>("select * from Name").AsList<CoffeeShopLabTable>();

            db.Close();

            return View(cslt);
        }
        [HttpPost]
        public IActionResult Detail(int id, string Name, string Description, decimal Price, string Category )
        {
            CoffeeShopLabTable menu = new CoffeeShopLabTable()
            {
                id = id,
                Name = Name,
                Description = Description,
                Price = Price,
                Category = Category
            };
            return View(menu);
        }
    }
}
//id, name, 