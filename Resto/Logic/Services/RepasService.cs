using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Resto.Logic.Services
{
    class RepasService
    {
        public static bool repasInsert(int IdRepas, string DesRepas)
        {
            return DBHelper.exceutedata("REPASINSERT", () => RepasParameterInsert(IdRepas, DesRepas, DBHelper.command));

        }
        // this methoud to add insert parameter into store procedure
        private static void RepasParameterInsert(int IdRepas, string DesRepas, SqlCommand command)
        {
            command.Parameters.Add("@IdRepas", SqlDbType.Int).Value = IdRepas;
            command.Parameters.Add("@DesRepas", SqlDbType.NVarChar).Value = DesRepas;
        }
        // methoud delete
        public static bool repasDelete(int IdRepas)
        {
            return DBHelper.exceutedata("REPASDELETE", () => RepasParameterDelete(IdRepas, DBHelper.command));

        }
        // this methoud to  delete parameter into store procedure
        private static void RepasParameterDelete(int IdRepas, SqlCommand command)
        {
            command.Parameters.Add("@IdRepas", SqlDbType.Int).Value = IdRepas;

        }
        // دالة التحديث
        public static bool repasUpdate(int IdRepas, string DesRepas)
        {
            return DBHelper.exceutedata("REPASUPDATE", () => RepasParameterUpdate(IdRepas, DesRepas, DBHelper.command));

        }
        private static void RepasParameterUpdate(int IdRepas, string DesRepas, SqlCommand command)
        {
            command.Parameters.Add("@IdRepas", SqlDbType.Int).Value = IdRepas;
            command.Parameters.Add("@DesRepas", SqlDbType.NVarChar).Value = DesRepas;
        }
        // methoud delete all
        public static bool repasDeleteAll()
        {
            return DBHelper.exceutedata("REPASDELETEALL", () => RepasParameterDeleteAll());

        }
        private static void RepasParameterDeleteAll()
        {


        }
        // دالة select
        static public DataTable getAllData()
        {
            return DBHelper.getData("REPASGETALL", () => { });
        }
        // method get all data to get last row in table
        static public DataTable getLastRow()
        {
            return DBHelper.getData("REPASGETLASTROW", () => { });
        }
        // method get all data to get max id in table
        static public DataTable getMaxID()
        {
            return DBHelper.getData("REPASMAXID", () => { });
        }

    }
}
