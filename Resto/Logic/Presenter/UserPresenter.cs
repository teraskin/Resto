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
    class UserPresenter
    {
        // ناخد نسخة من interface
        IUser iuser;

        // تاخد instance 
        UserModel userModel = new UserModel();
        // الفائدة من كونسركثور اول ما يتم استدعاء الكلاص هادي اول كود يتنفد هو كوسيكثور
        public UserPresenter(IUser view)
        {
            this.iuser = view;
        }
        private void connectBetweenModelInterface()
        {
            userModel.IdUser = iuser.IdUser;
            userModel.Username = iuser.Username;
            userModel.Pass = iuser.Pass;


        }
        public bool UserInsert()
        {
            connectBetweenModelInterface();
            bool check = UserService.userInsert(userModel.IdUser, userModel.Username, userModel.Pass);
            getAllData();
            AutoNumber();
            return check;
        }

        // دالة التحدبث

        public bool UserUpdate()
        {
            connectBetweenModelInterface();
            bool check = UserService.userUpdate(userModel.IdUser, userModel.Username, userModel.Pass);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة الحدف
        public bool UserDelete()
        {
            connectBetweenModelInterface();
            bool check = UserService.userDelete(userModel.IdUser);
            getAllData();
            AutoNumber();
            return check;
        }
        // دالة حدف الكل
        public bool UserDeleteAll()
        {
            connectBetweenModelInterface();
            bool check = UserService.userDeleteAll();
            getAllData();
            AutoNumber();
            return check;
        }

        public void ClearFields()
        {
            //connectBetweenModelInterface();
            iuser.IdUser= 0;
            iuser.Username = "";
            iuser.Pass = "";
            
        }
        // دالة select
        public void getAllData()
        {
            //connectBetweenModelInterface();
            iuser.dataGridView = UserService.getAllData();
            ClearFields();
        }
        public void AutoNumber()
        {
            string test = (UserService.getMaxID().Rows[0][0]).ToString();
            if (test == null || test == "")
            {
                iuser.IdUser = 1;
            }
            else
            {
                iuser.IdUser = Convert.ToInt32(UserService.getMaxID().Rows[0][0]) + 1;
            }
            iuser.Username = "";
            iuser.Pass = "";

            iuser.btnSave = false;
            iuser.btnDelete = false;
            iuser.btnDeleteAll = false;
            iuser.btnNew = true;

        }
        public void getRow(int row)
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = UserService.getAllData();

            iuser.IdUser = Convert.ToInt32(tbl.Rows[row][0]);
            iuser.Username = Convert.ToString(tbl.Rows[row][1]);
            iuser.Pass = Convert.ToString(tbl.Rows[row][2]);

            iuser.btnSave = true;
            iuser.btnDelete = true;
            iuser.btnDeleteAll = true;
            iuser.btnNew = false;
        }
        public DataTable getLastRow()
        {
            // نعرق طابل 
            DataTable tbl = new DataTable();
            // البيانات التي عندا وضعتاها في طابل
            tbl = UserService.getLastRow();
            return tbl;
        }
    }

}

