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
    class RepasPresenter
    {
        // ناخد نسخة من interface
        IRepas irepas;

        // تاخد instance 
        RepasModel repasModel = new RepasModel();
        // الفائدة من كونسركثور اول ما يتم استدعاء الكلاص هادي اول كود يتنفد هو كوسيكثور
        public RepasPresenter(IRepas view)
        {
            this.irepas = view;
        }
        private void connectBetweenModelInterface()
        {
            repasModel.IdRepas = irepas.IdRepas;
            repasModel.DesRepas = irepas.DesRepas;
            
        }
        public bool RepasInsert()
        {
            connectBetweenModelInterface();
            bool check =  RepasService.repasInsert(repasModel.IdRepas,repasModel.DesRepas);
            getAllData();
            AutoNumber();
            return check;
        }

        // دالة التحدبث

        public bool RepasUpdate()
        {
            connectBetweenModelInterface();
            bool check = RepasService.repasUpdate(repasModel.IdRepas, repasModel.DesRepas);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة الحدف
        public bool RepasDelete()
        {
            connectBetweenModelInterface();
            bool check = RepasService.repasDelete(repasModel.IdRepas);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة حدف الكل
        public bool RepasDeleteAll()
        {
            connectBetweenModelInterface();
            bool check = RepasService.repasDeleteAll();
            getAllData();
            AutoNumber();
            return check;
        }

        public void ClearFields()
        {
            //connectBetweenModelInterface();
            irepas.IdRepas= 0;
            irepas.DesRepas = "";
            
        }
        // دالة select
        public void getAllData()
        {
            //connectBetweenModelInterface();
            irepas.dataGridView = RepasService.getAllData();
            ClearFields();
        }
        public void AutoNumber()
        {
            string test = (RepasService.getMaxID().Rows[0][0]).ToString();
            if (test == null || test == "")
            {
                irepas.IdRepas = 1;
            }
            else
            {
                irepas.IdRepas = Convert.ToInt32(RepasService.getMaxID().Rows[0][0]) + 1;
            }
            irepas.DesRepas = "";

            irepas.btnSave = false;
            irepas.btnDelete = false;
            irepas.btnDeleteAll = false;
            irepas.btnNew = true;

        }
        public void getRow(int row)
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = RepasService.getAllData();

            irepas.IdRepas = Convert.ToInt32(tbl.Rows[row][0]);
            irepas.DesRepas = Convert.ToString(tbl.Rows[row][1]);


            irepas.btnSave = true;
            irepas.btnDelete = true;
            irepas.btnDeleteAll = true;
            irepas.btnNew = false;
        }
        public DataTable getLastRow()
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = RepasService.getLastRow();
            return tbl;
        }
    }

}

