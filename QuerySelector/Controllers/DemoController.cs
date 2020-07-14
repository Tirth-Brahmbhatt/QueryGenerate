using QuerySelector.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuerySelector.Controllers
{
    public class DemoController : Controller
    {
        private readonly string connectionstring = ConfigurationManager.ConnectionStrings["MyString"].ConnectionString;
        // GET: Demo
        public ActionResult Index()
        {
            return View();
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
                    
                    MyClass add = new MyClass();
                    for (int i = 0 ; i < rdr.FieldCount; i++)
                    {
                        if (rdr.GetName(i).Equals("StockId") )
                        {
                            add.ProductId = Convert.ToInt32(rdr["StockId"]);
                        }

                        else if (rdr.GetName(i).Equals("ProductId"))
                        {
                            add.ProductId = Convert.ToInt32(rdr["ProductId"]);
                        }
                        else if (rdr.GetName(i).Equals("ProductQty"))
                        {
                            add.ProductQty = Convert.ToInt32(rdr["ProductQty"]);
                        }
                        else if (rdr.GetName(i).Equals("Productprice"))
                        {
                            add.Productprice = Convert.ToInt32(rdr["Productprice"]);
                        }
                        else if (rdr.GetName(i).Equals("StockDate"))
                        {
                            add.StockDate = Convert.ToDateTime(rdr["StockDate"]);
                        }
                        else if (rdr.GetName(i).Equals("ProductName"))
                        {
                            add.ProductName = Convert.ToString(rdr["ProductName"]);
                        }
                        else if (rdr.GetName(i).Equals("ProductType"))
                        {
                            add.ProductType = Convert.ToString(rdr["ProductType"]);
                        }
                        else
                        {
                            add.ProductManufacture = Convert.ToString(rdr["ProductManufacture"]);
                        }


                    }
                   
                    lists.Add(add);
                }


            }


            return Json(lists, JsonRequestBehavior.AllowGet);



        }

        public JsonResult Alldone(string selectCol, string ColName, string myWhere, string order ,string GrpBy)
        {
            List<MyClass> lists = new List<MyClass>();
            {
                string scol = selectCol;
                string col = ColName;
                string cond = myWhere;
                string morder = order;
                string gBy = GrpBy;
                SqlConnection conn = new SqlConnection(connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("GrpBy", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@colName", scol);
                cmd.Parameters.AddWithValue("@tableName", col);
                cmd.Parameters.AddWithValue("@whereClause", cond);
                cmd.Parameters.AddWithValue("@order", morder);
                cmd.Parameters.AddWithValue("@grpb", gBy);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    MyClass add = new MyClass();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        if (rdr.GetName(i).Equals("StockId"))
                        {
                            add.ProductId = Convert.ToInt32(rdr["StockId"]);
                        }

                        else if (rdr.GetName(i).Equals("ProductId"))
                        {
                            add.ProductId = Convert.ToInt32(rdr["ProductId"]);
                        }
                        else if (rdr.GetName(i).Equals("ProductQty"))
                        {
                            add.ProductQty = Convert.ToInt32(rdr["ProductQty"]);
                        }
                        else if (rdr.GetName(i).Equals("Productprice"))
                        {
                            add.Productprice = Convert.ToInt32(rdr["Productprice"]);
                        }
                        else if (rdr.GetName(i).Equals("StockDate"))
                        {
                            add.StockDate = Convert.ToDateTime(rdr["StockDate"]);
                        }
                        else if (rdr.GetName(i).Equals("ProductName"))
                        {
                            add.ProductName = Convert.ToString(rdr["ProductName"]);
                        }
                        else if (rdr.GetName(i).Equals("ProductType"))
                        {
                            add.ProductType = Convert.ToString(rdr["ProductType"]);
                        }
                        else
                        {
                            add.ProductManufacture = Convert.ToString(rdr["ProductManufacture"]);
                        }


                    }

                    lists.Add(add);
                }


            }


            return Json(lists, JsonRequestBehavior.AllowGet);



        }
    }
}
