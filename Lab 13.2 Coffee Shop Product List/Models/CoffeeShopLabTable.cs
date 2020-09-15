using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Lab_13._2_Coffee_Shop_Product_List.Models
{
    [Table("CoffeeShopLabTable")]
    public class CoffeeShopLabTable
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string Category { get; set; }
    }
    public class DAL
    {
        public static CoffeeShopLabTable AddProduct(string _name, decimal _price, string _description, string _category)
        {
            // Create the new Product instance
            CoffeeShopLabTable prod = new CoffeeShopLabTable() { Name = _name, Price = _price, Description = _description, Category = _category };
            //Save it to the database
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=CoffeeShopLab;user id=testuser;password=abc123");
            long _id = db.Insert<CoffeeShopLabTable>(prod);
            //Set the id column of the instance
            prod.id = _id;
            //Return the instance
            return prod;
        }
        //Read
        public static CoffeeShopLabTable Read(long _id)
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=CoffeeShopLab;user id=testuser;password=abc123");
            CoffeeShopLabTable prod = db.Get<CoffeeShopLabTable>(_id);
            return prod; 
        }
        public static List<CoffeeShopLabTable> Read()
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=CoffeeShopLab;user id=testuser;password=abc123");
            List<CoffeeShopLabTable> prods = db.GetAll<CoffeeShopLabTable>().ToList();
            return prods;
        }
        //Delete
        public static void Delete(long _id)
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=CoffeeShopLab;user id=testuser;password=abc123");
            db.Delete(new CoffeeShopLabTable() { id = _id });
        }
        //Update
        public void Save()
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=CoffeeShopLab;user id=testuser;password=abc123");
            db.Update(this);
        }
    }
}
