using Resto.Logic.Services;
using Resto.Models;
using Resto.Views.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Logic.Presenter
{
    class EtablissementPresenter
    {
        // // ناخد نسخة من IEtablissement
        IEtablissement ietablissement;
        // تاخد instance 
        EtablissementModel etabModel = new EtablissementModel();

        // الفائدة من كونسركثور اول ما يتم استدعاء الكلاص هادي اول كود يتنفد هو كوسيكثور
         public EtablissementPresenter(IEtablissement view)
        {
            this.ietablissement = view;
        }

        private void connectBetweenModelInterface()
        {
            etabModel.IdEtablissement = ietablissement.IdEtablissement;
            etabModel.Code = ietablissement.Code;
            etabModel.Designation = ietablissement.Designation;
            etabModel.AmirSarf = ietablissement.AmirSarf;
            etabModel.Gerant = ietablissement.Gerant;
            etabModel.Grade = ietablissement.Grade;
            etabModel.Adresse = ietablissement.Adresse;
            etabModel.Commune = ietablissement.Commune;
            etabModel.Daira = ietablissement.Daira;
            etabModel.Wilaya = ietablissement.Wilaya;
            etabModel.Telephone = ietablissement.Telephone;
            etabModel.CCP = ietablissement.CCP;
            etabModel.CompteTresor = ietablissement.CompteTresor;
        }

        public bool EtabInsert()
        {
            connectBetweenModelInterface();
            bool check= EtablissementService.etablissementInsert(etabModel.IdEtablissement, etabModel.Code, etabModel.Designation,
               etabModel.AmirSarf, etabModel.Gerant, etabModel.Grade, etabModel.Adresse, etabModel.Commune, etabModel.Daira,
               etabModel.Wilaya, etabModel.Telephone, etabModel.CCP, etabModel.CompteTresor);
            getAllData();
            AutoNumber();
            return check;
        }

        // دالة التحدبث

        public bool EtabUpdate()
        {
            connectBetweenModelInterface();
            bool check = EtablissementService.etablissementUpdate(etabModel.IdEtablissement, etabModel.Code, etabModel.Designation,
               etabModel.AmirSarf, etabModel.Gerant, etabModel.Grade, etabModel.Adresse, etabModel.Commune, etabModel.Daira,
               etabModel.Wilaya, etabModel.Telephone, etabModel.CCP, etabModel.CompteTresor);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة الحدف
        public bool EtabDelete()
        {
            connectBetweenModelInterface();
            bool check = EtablissementService.etablissementDelete(etabModel.IdEtablissement);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة حدف الكل
        public bool EtabDeleteAll()
        {
            connectBetweenModelInterface();
            bool check = EtablissementService.etablissementDeleteAll();
            getAllData();
            AutoNumber();
            return check;
        }

        public void ClearFields()
        {
           // connectBetweenModelInterface();
            ietablissement.IdEtablissement = 0;
            ietablissement.Code = "";
            ietablissement.Designation = "";
            ietablissement.AmirSarf = "";
            ietablissement.Gerant = "";
            ietablissement.Grade = "";
            ietablissement.Adresse = "";
            ietablissement.Commune = "";
            ietablissement.Daira = "";
            ietablissement.Wilaya = "";
            ietablissement.Telephone = "";
            ietablissement.CCP = "";
            ietablissement.CompteTresor = "";
        }
        // دالة select
        public void getAllData()
        {
            //connectBetweenModelInterface();
            ietablissement.dataGridView = EtablissementService.getAllData();
            ClearFields();
        }
        public void AutoNumber()
        {
            string test = (EtablissementService.getMaxID().Rows[0][0]).ToString();
            if (test == null || test == "")
            {
                ietablissement.IdEtablissement = 1;
            }
            else
            {
                ietablissement.IdEtablissement = Convert.ToInt32(EtablissementService.getMaxID().Rows[0][0]) + 1;
            }
            ietablissement.Code = "";
            ietablissement.Designation = "";
            ietablissement.AmirSarf = "";
            ietablissement.Gerant = "";
            ietablissement.Grade = "";
            ietablissement.Adresse = "";
            ietablissement.Commune = "";
            ietablissement.Daira = "";
            ietablissement.Wilaya = "";
            ietablissement.Telephone = "";
            ietablissement.CCP = "";
            ietablissement.CompteTresor = "";

            ietablissement.btnSave = false;
            ietablissement.btnDelete = false;
            ietablissement.btnDeleteAll = false;
            ietablissement.btnNew = true;

        }
        public void getRow(int row)
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = EtablissementService.getAllData();

            ietablissement.IdEtablissement = Convert.ToInt32(tbl.Rows[row][0]);
            ietablissement.Code = Convert.ToString(tbl.Rows[row][1]);
            ietablissement.Designation = Convert.ToString(tbl.Rows[row][2]);
            ietablissement.AmirSarf = Convert.ToString(tbl.Rows[row][3]);
            ietablissement.Gerant = Convert.ToString(tbl.Rows[row][4]);
            ietablissement.Grade = Convert.ToString(tbl.Rows[row][5]);
            ietablissement.Adresse = Convert.ToString(tbl.Rows[row][6]);
            ietablissement.Commune = Convert.ToString(tbl.Rows[row][7]);
            ietablissement.Daira = Convert.ToString(tbl.Rows[row][8]);
            ietablissement.Wilaya = Convert.ToString(tbl.Rows[row][9]);
            ietablissement.Telephone = Convert.ToString(tbl.Rows[row][10]);
            ietablissement.CCP = Convert.ToString(tbl.Rows[row][11]);
            ietablissement.CompteTresor = Convert.ToString(tbl.Rows[row][12]);

            ietablissement.btnSave = true;
            ietablissement.btnDelete = true;
            ietablissement.btnDeleteAll = true;
            ietablissement.btnNew = false;

        }
        public DataTable getLastRow()
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = EtablissementService.getLastRow();
            return tbl;
        }
    }
    
}
