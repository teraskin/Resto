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
    class PlatPresenter
    {
        // ناخد نسخة من interface
        IPlat iplat;

        // تاخد instance 
        PlatModel platModel = new PlatModel();
        // الفائدة من كونسركثور اول ما يتم استدعاء الكلاص هادي اول كود يتنفد هو كوسيكثور
        public PlatPresenter(IPlat view)
        {
            this.iplat = view;
        }
        private void connectBetweenModelInterface()
        {
            platModel.IdPlat = iplat.IdPlat;
            platModel.DesPlat = iplat.DesPlat;                
            
        }
        public bool PlatInsert()
        {
            connectBetweenModelInterface();
            bool check =  PlatService.platInsert(platModel.IdPlat, platModel.DesPlat);
            getAllData();
            AutoNumber();
            return check;
        }

        // دالة التحدبث

        public bool PlatUpdate()
        {
            connectBetweenModelInterface();
            bool check = PlatService.platUpdate(platModel.IdPlat, platModel.DesPlat);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة الحدف
        public bool CategoryDelete()
        {
            connectBetweenModelInterface();
            bool check = PlatService.platDelete(platModel.IdPlat);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة حدف الكل
        public bool PlatDeleteAll()
        {
            connectBetweenModelInterface();
            bool check = PlatService.platDeleteAll();
            getAllData();
            AutoNumber();
            return check;
        }

        public void ClearFields()
        {
            //connectBetweenModelInterface();
            iplat.IdPlat= 0;
            iplat.DesPlat = "";
                  
        }
        // دالة select
        public void getAllData()
        {
            //connectBetweenModelInterface();
            iplat.dataGridView = PlatService.getAllData();
            ClearFields();
        }
        public void AutoNumber()
        {
            string test = (PlatService.getMaxID().Rows[0][0]).ToString();
            if (test == null || test == "")
            {
                iplat.IdPlat = 1;
            }
            else
            {
                iplat.IdPlat = Convert.ToInt32(PlatService.getMaxID().Rows[0][0]) + 1;
            }
            iplat.DesPlat = "";

            iplat.btnSave = false;
            iplat.btnDelete = false;
            iplat.btnDeleteAll = false;
            iplat.btnNew = true;

        }
        public void getRow(int row)
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = PlatService.getAllData();

            iplat.IdPlat = Convert.ToInt32(tbl.Rows[row][0]);
            iplat.DesPlat = Convert.ToString(tbl.Rows[row][1]);


            iplat.btnSave = true;
            iplat.btnDelete = true;
            iplat.btnDeleteAll = true;
            iplat.btnNew = false;
        }
        public DataTable getLastRow()
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = PlatService.getLastRow();
            return tbl;
        }
    }

}

