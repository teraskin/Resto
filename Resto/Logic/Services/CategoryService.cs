using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Resto.Logic.Services
{
    class CategoryService
    {
        public static bool categoryInsert(int IdCategorie, string DesCategorie)
        {
            return DBHelper.exceutedata("CATEGORIEINSERT", () => CategoryParameterInsert(IdCategorie, DesCategorie, DBHelper.command));

        }
        // this methoud to add insert parameter into store procedure
        private static void CategoryParameterInsert(int IdCategorie, string DesCategorie, SqlCommand command)
        {
            command.Parameters.Add("@IdCategorie", SqlDbType.Int).Value = IdCategorie;
            command.Parameters.Add("@DesCategorie", SqlDbType.NVarChar).Value = DesCategorie;
            
        }
        // methoud delete
        public static bool categoryDelete(int IdCategorie)
        {
            return DBHelper.exceutedata("CATEGORIEDELETE", () => categoryParameterDelete(IdCategorie, DBHelper.command));

        }
        // this methoud to  delete parameter into store procedure
        private static void categoryParameterDelete(int IdCategorie, SqlCommand command)
        {
            command.Parameters.Add("@IdCategorie", SqlDbType.Int).Value = IdCategorie;

        }
        // دالة التحديث
        public static bool categoryUpdate(int IdCategorie, string DesCategorie)
        {
            return DBHelper.exceutedata("CATEGORIEUPDATE", () => CategoryParameterUpdate(IdCategorie, DesCategorie, DBHelper.command));

        }
        private static void CategoryParameterUpdate(int IdCategorie, string DesCategorie, SqlCommand command)
        {
            command.Parameters.Add("@IdCategorie", SqlDbType.Int).Value = IdCategorie;
            command.Parameters.Add("@DesCategorie", SqlDbType.NVarChar).Value = DesCategorie;
            
            
        }
        // methoud delete all
        public static bool categoryDeleteAll()
        {
            return DBHelper.exceutedata("CATEGORIEDELETEALL", () => CategoryParameterDeleteAll());

        }
        private static void CategoryParameterDeleteAll()
        {


        }
        // دالة select
        static public DataTable getAllData()
        {
            return DBHelper.getData("CATEGORIEGETALL", () => { });
        }
        // method get all data to get last row in table
        static public DataTable getLastRow()
        {
            return DBHelper.getData("CATEGORIEGETLASTROW", () => { });
        }
        // method get all data to get max id in table
        static public DataTable getMaxID()
        {
            return DBHelper.getData("CATEGORIEMAXID", () => { });
        }

    }
}
