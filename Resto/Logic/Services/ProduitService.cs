using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Resto.Logic.Services
{
    class ProduitService
    {
        public static bool produitInsert(int IdProduit, string DesProduit, float QuantStock, float PrixAchat)
        {
            return DBHelper.exceutedata("PRODUITINSERT", () => ProduitParameterInsert(IdProduit, DesProduit, QuantStock,
            PrixAchat, DBHelper.command));

        }
        // this methoud to add insert parameter into store procedure
        private static void ProduitParameterInsert(int IdProduit, string DesProduit, float QuantStock, float PrixAchat, SqlCommand command)
        {
            command.Parameters.Add("@IdProduit", SqlDbType.Int).Value = IdProduit;
            command.Parameters.Add("@DesProduit", SqlDbType.NVarChar).Value = DesProduit;
            command.Parameters.Add("@QuantStock", SqlDbType.Float).Value = QuantStock;
            command.Parameters.Add("@PrixAchat", SqlDbType.Float).Value = PrixAchat;
        }
        // methoud delete
        public static bool produitDelete(int IdProduit)
        {
            return DBHelper.exceutedata("PRODUITDELETE", () => ProduitParameterDelete(IdProduit, DBHelper.command));

        }
        // this methoud to  delete parameter into store procedure
        private static void ProduitParameterDelete(int IdProduit, SqlCommand command)
        {
            command.Parameters.Add("@IdProduit", SqlDbType.Int).Value = IdProduit;

        }
        // دالة التحديث
        public static bool produitUpdate(int IdProduit, string DesProduit, float QuantStock, float PrixAchat)
        {
            return DBHelper.exceutedata("PRODUITUPDATE", () => ProduitParameterUpdate(IdProduit, DesProduit, QuantStock,
            PrixAchat, DBHelper.command));

        }
        private static void ProduitParameterUpdate(int IdProduit, string DesProduit, float QuantStock, float PrixAchat, SqlCommand command)
        {
            command.Parameters.Add("@IdProduit", SqlDbType.Int).Value = IdProduit;
            command.Parameters.Add("@DesProduit", SqlDbType.NVarChar).Value = DesProduit;
            command.Parameters.Add("@QuantStock", SqlDbType.Float).Value = QuantStock;
            command.Parameters.Add("@PrixAchat", SqlDbType.Float).Value = PrixAchat;

        }
        // methoud delete all
        public static bool produitDeleteAll()
        {
            return DBHelper.exceutedata("PRODUITDELETEALL", () => ProduitParameterDeleteAll());

        }
        private static void ProduitParameterDeleteAll()
        {


        }
        // دالة select
        static public DataTable getAllData()
        {
            return DBHelper.getData("PRODUITGETALL", () => { });
        }
        // method get all data to get last row in table
        static public DataTable getLastRow()
        {
            return DBHelper.getData("PRODUITGETLASTROW", () => { });
        }
        // method get all data to get max id in table
        static public DataTable getMaxID()
        {
            return DBHelper.getData("PRODUITMAXID", () => { });
        }

    }
}
