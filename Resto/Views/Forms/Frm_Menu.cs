using DevExpress.XtraEditors;
using Resto.Logic.Presenter;
using Resto.Views.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resto.Views.Forms
{
    public partial class Frm_Menu : DevExpress.XtraEditors.XtraForm, IMenu
    {
        // ناخد نسخة
        MenuPresenter menuPresenter;

        public int IdMenu { get => Convert.ToInt32(txtID.Text); set => txtID.Text = value.ToString(); }
        public string DesMenu { get => Convert.ToString(txtNumMenu.Text); set => txtNumMenu.Text = value.ToString(); }
        public string DetailMenu { get => Convert.ToString(txtDetailMenu.Text); set => txtDetailMenu.Text = value.ToString(); }
              
        public object dataGridView { get => Dgv.DataSource; set => Dgv.DataSource = value; }
        int IMenu.row { get => row; set => row = value; }
        object IMenu.btnNew { get => btnNew.Enabled; set => btnNew.Enabled = Convert.ToBoolean(value); }
        object IMenu.btnAdd { get => btnAdd.Enabled; set => btnAdd.Enabled = Convert.ToBoolean(value); }
        object IMenu.btnSave { get => btnSave.Enabled; set => btnSave.Enabled = Convert.ToBoolean(value); }
        object IMenu.btnDelete { get => btnDelete.Enabled; set => btnDelete.Enabled = Convert.ToBoolean(value); }
        object IMenu.btnDeleteAll { get => btnDeleteAll.Enabled; set => btnDeleteAll.Enabled = Convert.ToBoolean(value); }

        int row = 0;

        public Frm_Menu()
        {
            InitializeComponent();
            menuPresenter = new MenuPresenter(this);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Frm_Menu_Load(object sender, EventArgs e)
        {
            menuPresenter.getAllData();
            menuPresenter.AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNumMenu.Text == "" || txtDetailMenu.Text == "")
            {
                MessageBox.Show("من فظلك أكمل المعلومات الناقصة", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool check = menuPresenter.MenuInsert();
            if (check)
            {
                MessageBox.Show("تمت الإصافة بنجاح");
            }
            else
            {
                MessageBox.Show("فشل في عملية الإضافة");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool check = menuPresenter.MenuDelete();
            if (check)
            {
                MessageBox.Show("تم الحدف بنجاح");
            }
            else
            {
                MessageBox.Show("فشل في عمليةالحدف");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            menuPresenter.ClearFields();
            menuPresenter.AutoNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNumMenu.Text == "" || txtDetailMenu.Text == "")
            {
                MessageBox.Show("من فظلك أكمل المعلومات الناقصة", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool check = menuPresenter.MenuUpdate();
            if (check)
            {
                MessageBox.Show("تم التعديل بنجاح");
            }
            else
            {
                MessageBox.Show("فشل في عمليةالتعديل");
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            bool check = menuPresenter.MenuDeleteAll();
            if (check)
            {
                MessageBox.Show("تم حدف الكل بنجاح");
            }
            else
            {
                MessageBox.Show("فشل في عملية الحدف");
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                int countRow = Convert.ToInt32(menuPresenter.getLastRow().Rows[0][0]) - 1;
                row = countRow;
                menuPresenter.getRow(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int countRow = Convert.ToInt32(menuPresenter.getLastRow().Rows[0][0]);
                if (countRow == row)
                {
                    row = 0;
                }
                else
                {
                    row = row + 1;
                }
                menuPresenter.getRow(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            
            int countRow = Convert.ToInt32(menuPresenter.getLastRow().Rows[0][0]) - 1;
            if (row == 0)
            {
                row = countRow;
            }
            else
            {
                row = row - 1;
            }

            menuPresenter.getRow(row);
        }

        private void btnFrist_Click(object sender, EventArgs e)
        {
            row = 0;
            menuPresenter.getRow(row);
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}