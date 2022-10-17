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
    class CategoryPresenter
    {
        // ناخد نسخة من interface
        ICategory icategory;

        // تاخد instance 
        CategoryModel categoryModel = new CategoryModel();
        // الفائدة من كونسركثور اول ما يتم استدعاء الكلاص هادي اول كود يتنفد هو كوسيكثور
        public CategoryPresenter(ICategory view)
        {
            this.icategory = view;
        }
        private void connectBetweenModelInterface()
        {
            categoryModel.IdCategorie = icategory.IdCategorie;
            categoryModel.DesCategorie = icategory.DesCategorie;
            
        }
        public bool CategoryInsert()
        {
            connectBetweenModelInterface();
            bool check =  CategoryService.categoryInsert(categoryModel.IdCategorie, categoryModel.DesCategorie);
            getAllData();
            AutoNumber();
            return check;
        }

        // دالة التحدبث

        public bool CategoryUpdate()
        {
            connectBetweenModelInterface();
            bool check = CategoryService.categoryUpdate(categoryModel.IdCategorie, categoryModel.DesCategorie);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة الحدف
        public bool CategoryDelete()
        {
            connectBetweenModelInterface();
            bool check = CategoryService.categoryDelete(categoryModel.IdCategorie);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة حدف الكل
        public bool CategoryDeleteAll()
        {
            connectBetweenModelInterface();
            bool check = CategoryService.categoryDeleteAll();
            getAllData();
            AutoNumber();
            return check;
        }

        public void ClearFields()
        {
            //connectBetweenModelInterface();
            icategory.IdCategorie= 0;
            icategory.DesCategorie = "";
                  
        }
        // دالة select
        public void getAllData()
        {
            //connectBetweenModelInterface();
            icategory.dataGridView = CategoryService.getAllData();
            ClearFields();
        }
        public void AutoNumber()
        {
            string test = (CategoryService.getMaxID().Rows[0][0]).ToString();
            if (test == null || test == "")
            {
                icategory.IdCategorie = 1;
            }
            else
            {
                icategory.IdCategorie = Convert.ToInt32(CategoryService.getMaxID().Rows[0][0]) + 1;
            }
            icategory.DesCategorie = "";

            icategory.btnSave = false;
            icategory.btnDelete = false;
            icategory.btnDeleteAll = false;
            icategory.btnNew = true;

        }
        public void getRow(int row)
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = CategoryService.getAllData();

            icategory.IdCategorie = Convert.ToInt32(tbl.Rows[row][0]);
            icategory.DesCategorie = Convert.ToString(tbl.Rows[row][1]);


            icategory.btnSave = true;
            icategory.btnDelete = true;
            icategory.btnDeleteAll = true;
            icategory.btnNew = false;
        }
        public DataTable getLastRow()
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = CategoryService.getLastRow();
            return tbl;
        }
    }

}

