using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Resto.Logic.Services
{
    class EtablissementService
    {
        // methoud insert
        public static bool etablissementInsert(int IdEtablissement, string Code, string Designation, string AmirSarf,
            string Gerant, string Grade, string Adresse, string Commune, string Daira, string Wilaya,
            string Telephone, string CCP, string CompteTresor)
        {
            return DBHelper.exceutedata("ETABLISSEMENTINSERT", () => EtablissementParameterInsert(IdEtablissement,Code, Designation, 
            AmirSarf,Gerant, Grade, Adresse, Commune, Daira, Wilaya,Telephone, CCP, CompteTresor, DBHelper.command));
            
        }
        private static void EtablissementParameterInsert(int IdEtablissement,string Code, string Designation, string AmirSarf,
            string Gerant, string Grade, string Adresse, string Commune, string Daira, string Wilaya,
            string Telephone,string CCP,string CompteTresor,SqlCommand command)
        {
            command.Parameters.Add("@IdEtablissement", SqlDbType.Int).Value = IdEtablissement;
            command.Parameters.Add("@Code", SqlDbType.NVarChar).Value = Code;
            command.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Designation;
            command.Parameters.Add("@AmirSarf", SqlDbType.NVarChar).Value = AmirSarf;
            command.Parameters.Add("@Gerant", SqlDbType.NVarChar).Value = Gerant;
            command.Parameters.Add("@Grade", SqlDbType.NVarChar).Value = Grade;
            command.Parameters.Add("@Adresse", SqlDbType.NVarChar).Value = Adresse;
            command.Parameters.Add("@Commune", SqlDbType.NVarChar).Value = Commune;
            command.Parameters.Add("@Daira", SqlDbType.NVarChar).Value = Daira;
            command.Parameters.Add("@Wilaya", SqlDbType.NVarChar).Value = Wilaya;
            command.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = Telephone;
            command.Parameters.Add("@CCP", SqlDbType.NVarChar).Value = CCP;
            command.Parameters.Add("@CompteTresor", SqlDbType.NVarChar).Value = CompteTresor;
        }
        // methoud delete from
        public static bool etablissementDelete(int IdEtablissement)
        {
            return DBHelper.exceutedata("ETABLISSEMENTDELETE", () => EtablissementParameterDelete(IdEtablissement, DBHelper.command));
            
        }
        private static void EtablissementParameterDelete(int IdEtablissement, SqlCommand command)
        {
            command.Parameters.Add("@IdEtablissement", SqlDbType.Int).Value = IdEtablissement;
            
        }
        // دالة التحديث
        public static bool etablissementUpdate(int IdEtablissement,string Code, string Designation, string AmirSarf,
            string Gerant, string Grade, string Adresse, string Commune, string Daira, string Wilaya,
            string Telephone, string CCP, string CompteTresor)
        {
            return DBHelper.exceutedata("ETABLISSEMENTUPDATE", () => EtablissementParameterUpdate(IdEtablissement,Code, Designation,
            AmirSarf, Gerant, Grade, Adresse, Commune, Daira, Wilaya, Telephone, CCP, CompteTresor, DBHelper.command));
            
        }
        private static void EtablissementParameterUpdate(int IdEtablissement,string Code, string Designation, string AmirSarf,
            string Gerant, string Grade, string Adresse, string Commune, string Daira, string Wilaya,
            string Telephone, string CCP, string CompteTresor, SqlCommand command)
        {
            command.Parameters.Add("@IdEtablissement", SqlDbType.Int).Value = IdEtablissement;
            command.Parameters.Add("@Code", SqlDbType.NVarChar).Value = Code;
            command.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Designation;
            command.Parameters.Add("@AmirSarf", SqlDbType.NVarChar).Value = AmirSarf;
            command.Parameters.Add("@Gerant", SqlDbType.NVarChar).Value = Gerant;
            command.Parameters.Add("@Grade", SqlDbType.NVarChar).Value = Grade;
            command.Parameters.Add("@Adresse", SqlDbType.NVarChar).Value = Adresse;
            command.Parameters.Add("@Commune", SqlDbType.NVarChar).Value = Commune;
            command.Parameters.Add("@Daira", SqlDbType.NVarChar).Value = Daira;
            command.Parameters.Add("@Wilaya", SqlDbType.NVarChar).Value = Wilaya;
            command.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = Telephone;
            command.Parameters.Add("@CCP", SqlDbType.NVarChar).Value = CCP;
            command.Parameters.Add("@CompteTresor", SqlDbType.NVarChar).Value = CompteTresor;
        }

        // methoud delete all
        public static bool etablissementDeleteAll()
        {
            return DBHelper.exceutedata("ETABLISSEMENTDELETEALL", () => EtablissementParameterDeleteAll());

        }
        private static void EtablissementParameterDeleteAll()
        {
           

        }
        static public DataTable getAllData()
        {
            return DBHelper.getData("ETABLISSEMENTGETALL", () => { });
        }
        // method get all data to get last row in table
        static public DataTable getLastRow()
        {
            return DBHelper.getData("ETABLISSEMENTGETLASTROW", () => { });
        }
        // method get all data to get max id in table
        static public DataTable getMaxID()
        {
            return DBHelper.getData("ETABLISSEMENTMAXID", () => { });
        }
    }
}
