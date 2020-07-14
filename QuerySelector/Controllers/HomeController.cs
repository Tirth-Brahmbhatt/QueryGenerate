using QuerySelector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;

namespace QuerySelector.Controllers
{

    public class HomeController : Controller
    {

        private string connectionstring = ConfigurationManager.ConnectionStrings["MyString"].ConnectionString;

        public ActionResult Index()
        {

            return View();
        }


        [HttpGet]
        public JsonResult MyProcedure()
        {
            using (InventoryEntities entities = new InventoryEntities())
            {
                string whereclause = "ProductQty >= 5";
                var data = entities.Stocks.SqlQuery("[dbo].[Demo_proc] @whereClause", new SqlParameter("whereClause", whereclause)).ToList();

                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult WhereCondition(string ColName, string myWhere)
        {
            List<Stock> li = new List<Stock>();
            List<Product> la = new List<Product>();
            {
                string col = ColName;
                string cond = myWhere;
                SqlConnection conn = new SqlConnection(connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Final_Where", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tableName", col);
                cmd.Parameters.AddWithValue("@whereClause", cond);
                if (col == "stock")
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Stock ad = new Stock
                        {
                            StockId = Convert.ToInt32(rdr.GetValue(0).ToString()),
                            ProductId = Convert.ToInt32(rdr.GetValue(1).ToString()),
                            ProductQty = Convert.ToInt32(rdr.GetValue(2).ToString()),
                            Productprice = Convert.ToInt32(rdr.GetValue(3).ToString()),
                            StockDate = Convert.ToDateTime(rdr.GetValue(4).ToString())
                        };

                        li.Add(ad);
                    }
                    return Json(li, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Product ad = new Product
                        {
                            ProductId = Convert.ToInt32(rdr.GetValue(0).ToString()),
                            ProductName = (rdr.GetValue(1).ToString()),
                            ProductType = (rdr.GetValue(2).ToString()),
                            ProductManufacture = (rdr.GetValue(3).ToString()),

                        };

                        la.Add(ad);
                    }
                    return Json(la, JsonRequestBehavior.AllowGet);
                }
            }



        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult AllInOne(string selectCol, string ColName, string myWhere)
        {
            List<MyClass> lists = new List<MyClass>();
            {
                string scol = selectCol;
                string col = ColName;
                string cond = myWhere;
                SqlConnection conn = new SqlConnection(connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("AllJoin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@colName", scol);
                cmd.Parameters.AddWithValue("@tableName", col);
                cmd.Parameters.AddWithValue("@whereClause", cond);
                SqlDataReader Srdr = cmd.ExecuteReader();
                while(Srdr.Read())
                {
                    MyClass add = new MyClass()
                    {

                        ProductId = Convert.ToInt32(Srdr.GetValue(0).ToString()),
                        ProductQty = Convert.ToInt32(Srdr.GetValue(1).ToString()),
                        Productprice = Convert.ToInt64(Srdr.GetValue(2).ToString()),
                        StockDate = Convert.ToDateTime(Srdr.GetValue(3).ToString()),
                        ProductName = Srdr.GetValue(4).ToString(),
                        ProductType = Srdr.GetValue(5).ToString(),
                        ProductManufacture = Srdr.GetValue(6).ToString()



                    };


                    lists.Add(add);
                }


            }


            return Json(lists, JsonRequestBehavior.AllowGet);



        }

        public JsonResult MyProc(string selectCol, string ColName, string myWhere, string order)
        {
            List<MyClass> lists = new List<MyClass>();
            {
                string scol = selectCol;
                string col = ColName;
                string cond = myWhere;
                string morder = order; 
                SqlConnection conn = new SqlConnection(connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("JoinWithS", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@colName", scol);
                cmd.Parameters.AddWithValue("@tableName", col);
                cmd.Parameters.AddWithValue("@whereClause", cond);
                cmd.Parameters.AddWithValue("@order", morder);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MyClass add = new MyClass()
                    {

                        ProductId = Convert.ToInt32(rdr.GetValue(0).ToString()),
                        ProductQty = Convert.ToInt32(rdr.GetValue(1).ToString()),
                        Productprice = Convert.ToInt64(rdr.GetValue(2).ToString()),
                        StockDate = Convert.ToDateTime(rdr.GetValue(3).ToString()),
                        ProductName = (rdr.GetValue(4).ToString()),
                        ProductType = (rdr.GetValue(5).ToString()),
                        ProductManufacture = (rdr.GetValue(6).ToString())



                    };


                    lists.Add(add);
                }


            }


            return Json(lists, JsonRequestBehavior.AllowGet);



        }
    }
}