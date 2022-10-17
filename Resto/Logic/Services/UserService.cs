using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Resto.Logic.Services
{
    class UserService
    {
        public static bool userInsert(int IdUser, string Username, string Pass)
        {
            return DBHelper.exceutedata("USERINSERT", () => UserParameterInsert(IdUser, Username, Pass, DBHelper.command));

        }
        // this methoud to add insert parameter into store procedure
        private static void UserParameterInsert(int IdUser, string Username, string Pass, SqlCommand command)
        {
            command.Parameters.Add("@IdUser", SqlDbType.Int).Value = IdUser;
            command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username;
            command.Parameters.Add("@Pass", SqlDbType.NVarChar).Value = Pass;
           

        }
        // methoud delete
        public static bool userDelete(int IdUser)
        {
            return DBHelper.exceutedata("USERDELETE", () => UserParameterDelete(IdUser, DBHelper.command));

        }
        // this methoud to  delete parameter into store procedure
        private static void UserParameterDelete(int IdUser, SqlCommand command)
        {
            command.Parameters.Add("@IdUser", SqlDbType.Int).Value = IdUser;

        }
        // دالة التحديث
        public static bool userUpdate(int IdUser, string Username, string Pass)
        {
            return DBHelper.exceutedata("USERUPDATE", () => UserParameterUpdate(IdUser, Username, Pass, DBHelper.command));

        }
        private static void UserParameterUpdate(int IdUser, string Username, string Pass, SqlCommand command)
        {
            command.Parameters.Add("@IdUser", SqlDbType.Int).Value = IdUser;
            command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username;
            command.Parameters.Add("@Pass", SqlDbType.NVarChar).Value = Pass;

        }
        // methoud delete all
        public static bool userDeleteAll()
        {
            return DBHelper.exceutedata("USERDELETEALL", () => UserParameterDeleteAll());

        }
        private static void UserParameterDeleteAll()
        {


        }
        // دالة select
        static public DataTable getAllData()
        {
            return DBHelper.getData("USERGETALL", () => { });
        }
        // method get all data to get last row in table
        static public DataTable getLastRow()
        {
            return DBHelper.getData("USERGETLASTROW", () => { });
        }
        // method get all data to get max id in table
        static public DataTable getMaxID()
        {
            return DBHelper.getData("USERMAXID", () => { });
        }

    }
}
