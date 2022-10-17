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
    class ProduitPresenter
    {
        // ناخد نسخة من interface
        IProduit iproduit;

        // تاخد instance 
        ProduitModel produitModel = new ProduitModel();
        // الفائدة من كونسركثور اول ما يتم استدعاء الكلاص هادي اول كود يتنفد هو كوسيكثور
        public ProduitPresenter(IProduit view)
        {
            this.iproduit = view;
        }
        private void connectBetweenModelInterface()
        {
            produitModel.IdProduit = iproduit.IdProduit;
            produitModel.DesProduit = iproduit.DesProduit;
            produitModel.QuantStock = iproduit.QuantStock;
            produitModel.PrixAchat = iproduit.PrixAchat;
            
        }
        public bool ProduitInsert()
        {
            connectBetweenModelInterface();
            bool check =  ProduitService.produitInsert(produitModel.IdProduit, produitModel.DesProduit, produitModel.QuantStock,
               produitModel.PrixAchat);
            getAllData();
            AutoNumber();
            return check;
        }

        // دالة التحدبث

        public bool ProduitUpdate()
        {
            connectBetweenModelInterface();
            bool check = ProduitService.produitUpdate(produitModel.IdProduit, produitModel.DesProduit, produitModel.QuantStock,
               produitModel.PrixAchat);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة الحدف
        public bool ProduitDelete()
        {
            connectBetweenModelInterface();
            bool check = ProduitService.produitDelete(produitModel.IdProduit);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة حدف الكل
        public bool ProduitDeleteAll()
        {
            connectBetweenModelInterface();
            bool check = ProduitService.produitDeleteAll();
            getAllData();
            AutoNumber();
            return check;
        }

        public void ClearFields()
        {
            //connectBetweenModelInterface();
            iproduit.IdProduit= 0;
            iproduit.DesProduit = "";
            iproduit.QuantStock = 0;
            iproduit.PrixAchat = 0;
           
        }
        // دالة select
        public void getAllData()
        {
            //connectBetweenModelInterface();
            iproduit.dataGridView = ProduitService.getAllData();
            ClearFields();
        }
        public void AutoNumber()
        {
            string test = (ProduitService.getMaxID().Rows[0][0]).ToString();
            if (test == null || test == "")
            {
                iproduit.IdProduit = 1;
            }
            else
            {
                iproduit.IdProduit = Convert.ToInt32(ProduitService.getMaxID().Rows[0][0]) + 1;
            }
            //iproduit.IdProduit = 0;
            iproduit.DesProduit = "";
            iproduit.QuantStock = 0;
            iproduit.PrixAchat = 0;
            iproduit.btnSave = false;
            iproduit.btnDelete = false;
            iproduit.btnDeleteAll = false;
            iproduit.btnNew = true;

        }
        public void getRow(int row)
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = ProduitService.getAllData();

            iproduit.IdProduit = Convert.ToInt32(tbl.Rows[row][0]);
            iproduit.DesProduit = Convert.ToString(tbl.Rows[row][1]);
            iproduit.QuantStock = Convert.ToInt32(tbl.Rows[row][2]);
            iproduit.PrixAchat = Convert.ToInt32(tbl.Rows[row][3]);

            iproduit.btnSave = false;
            iproduit.btnDelete = false;
            iproduit.btnDeleteAll = false;
            iproduit.btnNew = true;
        }
        public DataTable getLastRow()
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = ProduitService.getLastRow();
            return tbl;
        }
    }

}

