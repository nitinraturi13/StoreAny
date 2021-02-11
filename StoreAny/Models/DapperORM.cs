using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StoreAny.Models
{
    public static class DapperORM
    {        
        public static string connectionString = @"server=(local)\SQLEXPRESS;database=store;Integrated Security=True;";

        public static void ExecutewithoutReturn(String procedureName, DynamicParameters param = null)
        {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                   // sqlcon.Open();
                    sqlcon.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
                }
        }
        public static T ExecuteReturnScalar<T>(String procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
               // sqlcon.Open();
                return(T)Convert.ChangeType(sqlcon.Execute(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }

        public static IEnumerable<T>ReturnList<T>(String procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
               // sqlcon.Open();
                return sqlcon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
        //public PurchaseModel PurchaseRead()
        //{
        //    PurchaseModel p = new PurchaseModel();
        //    Class1 c = new Class1();
        //    List<Class1> v1;
        //    List<int> v2;
        //    using (SqlConnection sqlcon = new SqlConnection(connectionString))
        //    {
        //        string Sqlq1 = "select Id,type from Customer";
        //        string Sqlq2 = "select MenuCode from Item_list";

        //         v1 =  (List<Class1>)sqlcon.Query<Class1>(Sqlq1);
        //         v2 = (List<int>)sqlcon.Query<int>(Sqlq1);
                                
        //    }
        //    foreach(var e in v1)
        //    {
        //        if (e.type == "c")
        //            p.Customer.Add(e.id);
        //        if (e.type == "s")
        //            p.Supplier.Add(e.id);
        //    }
        //    p.ItemList = v2;
        //    return p;
        //}



    }
}