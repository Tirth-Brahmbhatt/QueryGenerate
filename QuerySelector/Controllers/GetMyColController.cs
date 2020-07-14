using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data.SqlClient;
using QuerySelector.Models;


namespace QuerySelector.Controllers
{
    public class GetMyColController : ApiController
    {
        private string connectionstring = ConfigurationManager.ConnectionStrings["MyString"].ConnectionString;

        [Route("api/GetMyCol/GetAllRow/")]
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetAllRow()
        {
            List<Stock> li = new List<Stock>();
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Fetch_Col", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Column", "Productprice");
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Stock ad = new Stock
                    {

                        Productprice = Convert.ToInt32(rdr.GetValue(0).ToString())
                    };

                    li.Add(ad);
                }


            }

            return Ok(li);
        }
        [Route("api/GetMyCol/GetColData/{col_name}")]
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetColData([FromUri] string col_name)
        {
            List<Stock> li = new List<Stock>();
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Fetch_Col", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@col_name", col_name);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        {
                            Stock ad = new Stock()
                            {

                                StockId = Convert.ToInt32(rdr.GetValue(0).ToString()),
                                ProductId = Convert.ToInt32(rdr.GetValue(1).ToString()),
                                ProductQty = Convert.ToInt32(rdr.GetValue(2).ToString()),
                                Productprice = Convert.ToInt32(rdr.GetValue(3).ToString()),
                                StockDate = Convert.ToDateTime(rdr.GetValue(4).ToString())


                            };
                        li.Add(ad);
                        }

                    }
                

            }

            return Ok(li);
        }
        [Route("api/GetMyCol/GetAllData/")]
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult GetAllData([FromBody] string myWhere)
        {
            List<Stock> li = new List<Stock>();
            {
                string cond = myWhere;
                SqlConnection conn = new SqlConnection(connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Demo_proc", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@whereClause", cond);
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


            }

            return Ok(li);
        }

        [Route("api/GetMyCol/Data_We/")]
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Data_We([FromBody] string ColName, string myWhere)
        {
            List<Stock> li = new List<Stock>();
            {
                string col = "Stock";
                string cond = myWhere;
                SqlConnection conn = new SqlConnection(connectionstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Final_Where", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tableName", col);
                cmd.Parameters.AddWithValue("@whereClause", cond);
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


            }

            return Ok(li);
        }
    }

}


