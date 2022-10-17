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
    class MenuPresenter
    {
        // ناخد نسخة من interface
        IMenu imenu;

        // تاخد instance 
        MenuModel menuModel = new MenuModel();
        // الفائدة من كونسركثور اول ما يتم استدعاء الكلاص هادي اول كود يتنفد هو كوسيكثور
        public MenuPresenter(IMenu view)
        {
            this.imenu = view;
        }
        private void connectBetweenModelInterface()
        {
            menuModel.IdMenu = imenu.IdMenu;
            menuModel.DesMenu = imenu.DesMenu;
            menuModel.DetailMenu = imenu.DetailMenu;


        }
        public bool MenuInsert()
        {
            connectBetweenModelInterface();
            bool check = MenuService.menuInsert(menuModel.IdMenu,menuModel.DesMenu,menuModel.DetailMenu);
            getAllData();
            AutoNumber();
            return check;
        }

        // دالة التحدبث

        public bool MenuUpdate()
        {
            connectBetweenModelInterface();
            bool check = MenuService.menuUpdate(menuModel.IdMenu, menuModel.DesMenu, menuModel.DetailMenu);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة الحدف
        public bool MenuDelete()
        {
            connectBetweenModelInterface();
            bool check = MenuService.menuDelete(menuModel.IdMenu);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة حدف الكل
        public bool MenuDeleteAll()
        {
            connectBetweenModelInterface();
            bool check = MenuService.menuDeleteAll();
            getAllData();
            AutoNumber();
            return check;
        }

        public void ClearFields()
        {
            //connectBetweenModelInterface();
            imenu.IdMenu= 0;
            imenu.DesMenu = "";
            imenu.DetailMenu = "";
            
        }
        // دالة select
        public void getAllData()
        {
            //connectBetweenModelInterface();
            imenu.dataGridView = MenuService.getAllData();
            ClearFields();
        }
        public void AutoNumber()
        {
            string test = (MenuService.getMaxID().Rows[0][0]).ToString();
            if (test == null || test == "")
            {
                imenu.IdMenu = 1;
            }
            else
            {
                imenu.IdMenu = Convert.ToInt32(MenuService.getMaxID().Rows[0][0]) + 1;
            }
            imenu.DesMenu = "";
            imenu.DetailMenu = "";

            imenu.btnSave = false;
            imenu.btnDelete = false;
            imenu.btnDeleteAll = false;
            imenu.btnNew = true;

        }
        public void getRow(int row)
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = MenuService.getAllData();

            imenu.IdMenu = Convert.ToInt32(tbl.Rows[row][0]);
            imenu.DesMenu = Convert.ToString(tbl.Rows[row][1]);
            imenu.DetailMenu = Convert.ToString(tbl.Rows[row][2]);

            imenu.btnSave = true;
            imenu.btnDelete = true;
            imenu.btnDeleteAll = true;
            imenu.btnNew = false;
        }
        public DataTable getLastRow()
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = MenuService.getLastRow();
            return tbl;
        }
    }

}

