using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Resto.Logic.Services
{
    class MenuService
    {
        public static bool menuInsert(int IdMenu, string DesMenu, string DetailMenu)
        {
            return DBHelper.exceutedata("MENUINSERT", () => MenuParameterInsert(IdMenu, DesMenu, DetailMenu, DBHelper.command));

        }
        // this methoud to add insert parameter into store procedure
        private static void MenuParameterInsert(int IdMenu, string DesMenu, string DetailMenu, SqlCommand command)
        {
            command.Parameters.Add("@IdMenu", SqlDbType.Int).Value = IdMenu;
            command.Parameters.Add("@DesMenu", SqlDbType.NVarChar).Value = DesMenu;
            command.Parameters.Add("@DetailMenu", SqlDbType.NVarChar).Value = DetailMenu;
           

        }
        // methoud delete
        public static bool menuDelete(int IdMenu)
        {
            return DBHelper.exceutedata("MENUDELETE", () => MenuParameterDelete(IdMenu, DBHelper.command));

        }
        // this methoud to  delete parameter into store procedure
        private static void MenuParameterDelete(int IdMenu, SqlCommand command)
        {
            command.Parameters.Add("@IdMenu", SqlDbType.Int).Value = IdMenu;

        }
        // دالة التحديث
        public static bool menuUpdate(int IdMenu, string DesMenu, string DetailMenu)
        {
            return DBHelper.exceutedata("MENUUPDATE", () => MenuParameterUpdate(IdMenu, DesMenu, DetailMenu, DBHelper.command));

        }
        private static void MenuParameterUpdate(int IdMenu, string DesMenu, string DetailMenu, SqlCommand command)
        {
            command.Parameters.Add("@IdMenu", SqlDbType.Int).Value = IdMenu;
            command.Parameters.Add("@DesMenu", SqlDbType.NVarChar).Value = DesMenu;
            command.Parameters.Add("@DetailMenu", SqlDbType.NVarChar).Value = DetailMenu;

        }
        // methoud delete all
        public static bool menuDeleteAll()
        {
            return DBHelper.exceutedata("MENUDELETEALL", () => MenuParameterDeleteAll());

        }
        private static void MenuParameterDeleteAll()
        {


        }
        // دالة select
        static public DataTable getAllData()
        {
            return DBHelper.getData("MENUGETALL", () => { });
        }
        // method get all data to get last row in table
        static public DataTable getLastRow()
        {
            return DBHelper.getData("MENUGETLASTROW", () => { });
        }
        // method get all data to get max id in table
        static public DataTable getMaxID()
        {
            return DBHelper.getData("MENUMAXID", () => { });
        }

    }
}
