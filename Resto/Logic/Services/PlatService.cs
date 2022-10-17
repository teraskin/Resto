using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Resto.Logic.Services
{
    class PlatService
    {
        public static bool platInsert(int IdPlat, string DesPlat)
        {
            return DBHelper.exceutedata("PLATINSERT", () => PlatParameterInsert(IdPlat, DesPlat, DBHelper.command));

        }
        // this methoud to add insert parameter into store procedure
        private static void PlatParameterInsert(int IdPlat, string DesPlat, SqlCommand command)
        {
            command.Parameters.Add("@IdPlat", SqlDbType.Int).Value = IdPlat;
            command.Parameters.Add("@DesPlat", SqlDbType.NVarChar).Value = DesPlat;
            
        }
        // methoud delete
        public static bool platDelete(int IdPlat)
        {
            return DBHelper.exceutedata("PLATDELETE", () => PlatParameterDelete(IdPlat, DBHelper.command));

        }
        // this methoud to  delete parameter into store procedure
        private static void PlatParameterDelete(int IdPlat, SqlCommand command)
        {
            command.Parameters.Add("@IdPlat", SqlDbType.Int).Value = IdPlat;

        }
        // دالة التحديث
        public static bool platUpdate(int IdPlat, string DesPlat)
        {
            return DBHelper.exceutedata("PLATUPDATE", () => PlatParameterUpdate(IdPlat, DesPlat, DBHelper.command));

        }
        private static void PlatParameterUpdate(int IdPlat, string DesPlat, SqlCommand command)
        {
            command.Parameters.Add("@IdPlat", SqlDbType.Int).Value = IdPlat;
            command.Parameters.Add("@DesPlat", SqlDbType.NVarChar).Value = DesPlat;
            
            
        }
        // methoud delete all
        public static bool platDeleteAll()
        {
            return DBHelper.exceutedata("PLATDELETEALL", () => PlatParameterDeleteAll());

        }
        private static void PlatParameterDeleteAll()
        {


        }
        // دالة select
        static public DataTable getAllData()
        {
            return DBHelper.getData("PLATGETALL", () => { });
        }
        // method get all data to get last row in table
        static public DataTable getLastRow()
        {
            return DBHelper.getData("PLATGETLASTROW", () => { });
        }
        // method get all data to get max id in table
        static public DataTable getMaxID()
        {
            return DBHelper.getData("PLATMAXID", () => { });
        }

    }
}
