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
    class FournisseurPresenter
    {
        // ناخد نسخة من interface
        IFournisseur ifournisseur;

        // تاخد instance 
        FournisseurModel fournisseurModel = new FournisseurModel();
        // الفائدة من كونسركثور اول ما يتم استدعاء الكلاص هادي اول كود يتنفد هو كوسيكثور
        public FournisseurPresenter(IFournisseur view)
        {
            this.ifournisseur = view;
        }
        private void connectBetweenModelInterface()
        {
            fournisseurModel.IdFournisseur = ifournisseur.IdFournisseur;
            fournisseurModel.NomFournisseur = ifournisseur.NomFournisseur;
            fournisseurModel.Activite = ifournisseur.Activite;
            fournisseurModel.NumRegistre = ifournisseur.NumRegistre;
            fournisseurModel.NumFiscal = ifournisseur.NumFiscal;
            fournisseurModel.Adresse = ifournisseur.Adresse;
            fournisseurModel.Telephone = ifournisseur.Telephone;
        }
        public bool FournisseurInsert()
        {
            connectBetweenModelInterface();
            bool check =  FournisseurService.fournisseurInsert(fournisseurModel.IdFournisseur, fournisseurModel.NomFournisseur, fournisseurModel.Activite,
               fournisseurModel.NumRegistre, fournisseurModel.NumFiscal, fournisseurModel.Adresse, fournisseurModel.Telephone);
            getAllData();
            AutoNumber();
            return check;
        }

        // دالة التحدبث

        public bool FournisseurUpdate()
        {
            connectBetweenModelInterface();
            bool check = FournisseurService.fournisseurUpdate(fournisseurModel.IdFournisseur, fournisseurModel.NomFournisseur, fournisseurModel.Activite,
               fournisseurModel.NumRegistre, fournisseurModel.NumFiscal, fournisseurModel.Adresse, fournisseurModel.Telephone);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة الحدف
        public bool FournisseurDelete()
        {
            connectBetweenModelInterface();
            bool check = FournisseurService.fournisseurDelete(fournisseurModel.IdFournisseur);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة حدف الكل
        public bool FournisseurDeleteAll()
        {
            connectBetweenModelInterface();
            bool check = FournisseurService.fournisseurDeleteAll();
            getAllData();
            AutoNumber();
            return check;
        }

        public void ClearFields()
        {
            //connectBetweenModelInterface();
            ifournisseur.IdFournisseur= 0;
            ifournisseur.NomFournisseur= "";
            ifournisseur.Activite = "";
            ifournisseur.NumRegistre = "";
            ifournisseur.NumFiscal = "";
            ifournisseur.Adresse = "";
            ifournisseur.Telephone = "";
           
        }
        // دالة select
        public void getAllData()
        {
            //connectBetweenModelInterface();
            ifournisseur.dataGridView = FournisseurService.getAllData();
            ClearFields();
        }
        public void AutoNumber()
        {
            string test = (FournisseurService.getMaxID().Rows[0][0]).ToString();
            if (test == null || test == "")
            {
                ifournisseur.IdFournisseur = 1;
            }
            else
            {
                ifournisseur.IdFournisseur = Convert.ToInt32(FournisseurService.getMaxID().Rows[0][0]) + 1;
            }
            ifournisseur.NomFournisseur = "";
            ifournisseur.Activite = "";
            ifournisseur.NumRegistre = "";
            ifournisseur.NumFiscal = "";
            ifournisseur.Adresse = "";
            ifournisseur.Telephone = "";
            ifournisseur.btnSave = false;
            ifournisseur.btnDelete = false;
            ifournisseur.btnDeleteAll = false;
            ifournisseur.btnNew = true;

        }
        public void getRow(int row)
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = FournisseurService.getAllData();

            ifournisseur.IdFournisseur = Convert.ToInt32(tbl.Rows[row][0]);
            ifournisseur.NomFournisseur = Convert.ToString(tbl.Rows[row][1]);
            ifournisseur.Activite = Convert.ToString(tbl.Rows[row][2]);
            ifournisseur.NumRegistre = Convert.ToString(tbl.Rows[row][3]);
            ifournisseur.NumFiscal = Convert.ToString(tbl.Rows[row][4]);
            ifournisseur.Adresse = Convert.ToString(tbl.Rows[row][5]);
            ifournisseur.Telephone =  Convert.ToString(tbl.Rows[row][6]);

            ifournisseur.btnSave = true;
            ifournisseur.btnDelete = true;
            ifournisseur.btnDeleteAll = true;
            ifournisseur.btnNew = false;
        }
        public DataTable getLastRow()
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = FournisseurService.getLastRow();
            return tbl;
        }
    }

}

