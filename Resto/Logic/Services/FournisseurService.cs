using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Resto.Logic.Services
{
    class FournisseurService
    {
        public static bool fournisseurInsert(int IdFournisseur, string NomFournisseur, string Activite, string NumRegistre,
            string NumFiscal, string Adresse, string Telephone)
        {
            return DBHelper.exceutedata("FOURNISSEURINSERT", () => FournisseurParameterInsert(IdFournisseur, NomFournisseur, Activite,
            NumRegistre, NumFiscal, Adresse, Telephone, DBHelper.command));

        }
        // this methoud to add insert parameter into store procedure
        private static void FournisseurParameterInsert(int IdFournisseur, string NomFournisseur, string Activite, string NumRegistre,
            string NumFiscal, string Adresse, string Telephone, SqlCommand command)
        {
            command.Parameters.Add("@IdFournisseur", SqlDbType.Int).Value = IdFournisseur;
            command.Parameters.Add("@NomFournisseur", SqlDbType.NVarChar).Value = NomFournisseur;
            command.Parameters.Add("@Activite", SqlDbType.NVarChar).Value = Activite;
            command.Parameters.Add("@NumRegistre", SqlDbType.NVarChar).Value = NumRegistre;
            command.Parameters.Add("@NumFiscal", SqlDbType.NVarChar).Value = NumFiscal;
            command.Parameters.Add("@Adresse", SqlDbType.NVarChar).Value = Adresse;
            command.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = Telephone;

        }
        // methoud delete
        public static bool fournisseurDelete(int id)
        {
            return DBHelper.exceutedata("FournisseurDelete", () => FournisseurParameterDelete(id, DBHelper.command));

        }
        // this methoud to  delete parameter into store procedure
        private static void FournisseurParameterDelete(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

        }
        // دالة التحديث
        public static bool fournisseurUpdate(int IdFournisseur, string NomFournisseur, string Activite, string NumRegistre,
            string NumFiscal, string Adresse, string Telephone)
        {
            return DBHelper.exceutedata("FOURNISSEURUPDATE", () => FournisseurParameterUpdate(IdFournisseur, NomFournisseur, Activite,
            NumRegistre, NumFiscal, Adresse, Telephone, DBHelper.command));

        }
        private static void FournisseurParameterUpdate(int IdFournisseur, string NomFournisseur, string Activite, string NumRegistre,
            string NumFiscal, string Adresse, string Telephone, SqlCommand command)
        {
            command.Parameters.Add("@IdFournisseur", SqlDbType.Int).Value = IdFournisseur;
            command.Parameters.Add("@NomFournisseur", SqlDbType.NVarChar).Value = NomFournisseur;
            command.Parameters.Add("@Activite", SqlDbType.NVarChar).Value = Activite;
            command.Parameters.Add("@NumRegistre", SqlDbType.NVarChar).Value = NumRegistre;
            command.Parameters.Add("@NumFiscal", SqlDbType.NVarChar).Value = NumFiscal;
            command.Parameters.Add("@Adresse", SqlDbType.NVarChar).Value = Adresse;
            command.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = Telephone;
            
        }
        // methoud delete all
        public static bool fournisseurDeleteAll()
        {
            return DBHelper.exceutedata("FOURNISSEURDELETEALL", () => FournisseurParameterDeleteAll());

        }
        private static void FournisseurParameterDeleteAll()
        {


        }

        public static DataTable getAllData()
        {
            return DBHelper.getData("FOURNISSEURGETALL", () => { });
        }
    }
}
