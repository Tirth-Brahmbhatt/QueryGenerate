using QuerySelector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Web.Http.Results;

namespace QuerySelector.Controllers
{
    public class GetTableDataController : ApiController
    {
        
        [Route("api/GetTableData/GetTable/{id}")]
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetTable([FromUri]string id)
        {
            InventoryEntities entities = new InventoryEntities();
            var op = entities.SelectCol1(id).ToList();
            return Ok(op);
        }


        [Route("api/GetTableData/GetName/")]
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetName()
        {
            InventoryEntities entities = new InventoryEntities();

            DbRawSqlQuery<Stock> data1 = entities.Stocks.SqlQuery("select StockId from Stock");
            return Ok(data1);

        }
        [Route("api/GetTableData/GetWhere/")]
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult GetWhere()
        {
                string wherec = "ProductQty >= 5";
                InventoryEntities entities = new InventoryEntities();
                var Getdata = entities.Stocks.SqlQuery("[dbo].[Demo_proc] @whereClause", new SqlParameter("whereClause", wherec)).ToList();

                return Ok(Getdata);
            
           
        }
        [Route("api/GetTableData/GetAll/")]
        [AllowAnonymous]
        [HttpGet]
        public List<Demo_proc_Result> GetAll()
        {

            using (InventoryEntities entities = new InventoryEntities())
            {
                string whereclause = "ProductQty >= 5";
                ///var data = entities.Stocks.SqlQuery("[dbo].[Demo_proc] @whereClause", new SqlParameter("whereClause", whereclause)).ToList();
                List<Demo_proc_Result> demo = entities.Demo_proc(whereclause).ToList<Demo_proc_Result>();
                return demo; 
            }

        }
    }
    
}
