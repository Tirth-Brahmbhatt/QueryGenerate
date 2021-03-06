﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuerySelector.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class InventoryEntities : DbContext
    {
        public InventoryEntities()
            : base("name=InventoryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
    
        public virtual ObjectResult<Select_Table_Result> Select_Table(string tableName)
        {
            var tableNameParameter = tableName != null ?
                new ObjectParameter("tableName", tableName) :
                new ObjectParameter("tableName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Select_Table_Result>("Select_Table", tableNameParameter);
        }
    
        public virtual int Select_Col(string columnname)
        {
            var columnnameParameter = columnname != null ?
                new ObjectParameter("columnname", columnname) :
                new ObjectParameter("columnname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Select_Col", columnnameParameter);
        }
    
        public virtual ObjectResult<Get_Col1_Result> Get_Col1(string column)
        {
            var columnParameter = column != null ?
                new ObjectParameter("Column", column) :
                new ObjectParameter("Column", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Get_Col1_Result>("Get_Col1", columnParameter);
        }
    
        public virtual ObjectResult<Get_Col_Result> Get_Col(string columnname)
        {
            var columnnameParameter = columnname != null ?
                new ObjectParameter("columnname", columnname) :
                new ObjectParameter("columnname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Get_Col_Result>("Get_Col", columnnameParameter);
        }
    
        public virtual ObjectResult<Fetch_Col_Result> Fetch_Col(string column)
        {
            var columnParameter = column != null ?
                new ObjectParameter("Column", column) :
                new ObjectParameter("Column", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Fetch_Col_Result>("Fetch_Col", columnParameter);
        }
    
        public virtual ObjectResult<Where_Cond_Result> Where_Cond(string iD)
        {
            var iDParameter = iD != null ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Where_Cond_Result>("Where_Cond", iDParameter);
        }
    
        public virtual int Fetch_Col1(string column)
        {
            var columnParameter = column != null ?
                new ObjectParameter("Column", column) :
                new ObjectParameter("Column", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Fetch_Col1", columnParameter);
        }
    
        public virtual int Final_Query(string columnName, string var, string data)
        {
            var columnNameParameter = columnName != null ?
                new ObjectParameter("ColumnName", columnName) :
                new ObjectParameter("ColumnName", typeof(string));
    
            var varParameter = var != null ?
                new ObjectParameter("var", var) :
                new ObjectParameter("var", typeof(string));
    
            var dataParameter = data != null ?
                new ObjectParameter("data", data) :
                new ObjectParameter("data", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Final_Query", columnNameParameter, varParameter, dataParameter);
        }
    
        public virtual ObjectResult<Demo_proc_Result> Demo_proc(string whereClause)
        {
            var whereClauseParameter = whereClause != null ?
                new ObjectParameter("whereClause", whereClause) :
                new ObjectParameter("whereClause", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Demo_proc_Result>("Demo_proc", whereClauseParameter);
        }
    
        public virtual int Demo_whe(string var)
        {
            var varParameter = var != null ?
                new ObjectParameter("var", var) :
                new ObjectParameter("var", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Demo_whe", varParameter);
        }
    
        public virtual ObjectResult<SelectCol1_Result> SelectCol1(string tableName)
        {
            var tableNameParameter = tableName != null ?
                new ObjectParameter("tableName", tableName) :
                new ObjectParameter("tableName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectCol1_Result>("SelectCol1", tableNameParameter);
        }
    
        public virtual int AllJoin(string colName, string tableName, string whereClause)
        {
            var colNameParameter = colName != null ?
                new ObjectParameter("colName", colName) :
                new ObjectParameter("colName", typeof(string));
    
            var tableNameParameter = tableName != null ?
                new ObjectParameter("tableName", tableName) :
                new ObjectParameter("tableName", typeof(string));
    
            var whereClauseParameter = whereClause != null ?
                new ObjectParameter("whereClause", whereClause) :
                new ObjectParameter("whereClause", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AllJoin", colNameParameter, tableNameParameter, whereClauseParameter);
        }
    
        public virtual int AllOne(string colName, string tableName, string whereClause)
        {
            var colNameParameter = colName != null ?
                new ObjectParameter("colName", colName) :
                new ObjectParameter("colName", typeof(string));
    
            var tableNameParameter = tableName != null ?
                new ObjectParameter("tableName", tableName) :
                new ObjectParameter("tableName", typeof(string));
    
            var whereClauseParameter = whereClause != null ?
                new ObjectParameter("whereClause", whereClause) :
                new ObjectParameter("whereClause", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AllOne", colNameParameter, tableNameParameter, whereClauseParameter);
        }
    }
}
