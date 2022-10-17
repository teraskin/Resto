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
    public partial class Frm_Plat : DevExpress.XtraEditors.XtraForm, ICategory
    {
        CategoryPresenter categoPresenter;

        public Frm_Plat()
        {
            InitializeComponent();
            categoPresenter = new CategoryPresenter(this);
        }

        public int IdCategorie { get => Convert.ToInt32(txtID.Text); set => txtID.Text = value.ToString(); }
        public string DesCategorie { get => Convert.ToString(txtDes.Text); set => txtDes.Text = value.ToString(); }
        public object dataGridView { get => Dgv.DataSource; set => Dgv.DataSource = value; }
        int ICategory.row { get => row; set => row = value; }
        object ICategory.btnNew { get => btnNew.Enabled; set => btnNew.Enabled = Convert.ToBoolean(value); }
        object ICategory.btnAdd { get => btnAdd.Enabled; set => btnAdd.Enabled = Convert.ToBoolean(value); }
        object ICategory.btnSave { get => btnSave.Enabled; set => btnSave.Enabled = Convert.ToBoolean(value); }
        object ICategory.btnDelete { get => btnDelete.Enabled; set => btnDelete.Enabled = Convert.ToBoolean(value); }
        object ICategory.btnDeleteAll { get => btnDeleteAll.Enabled; set => btnDeleteAll.Enabled = Convert.ToBoolean(value); }
        

        int row = 0;

        private void Frm_Plat_Load(object sender, EventArgs e)
        {
            categoPresenter.getAllData();
            categoPresenter.AutoNumber();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            categoPresenter.ClearFields();
            categoPresenter.AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtDes.Text == "" )
            {
                MessageBox.Show("من فظلك المعلومات الناقصة", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool check = categoPresenter.CategoryInsert();
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
            bool check = categoPresenter.CategoryDelete();
            if (check)
            {
                MessageBox.Show("تم الحدف بنجاح");
            }
            else
            {
                MessageBox.Show("فشل في عمليةالحدف");
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            bool check = categoPresenter.CategoryDeleteAll();
            if (check)
            {
                MessageBox.Show("تم حدف الكل بنجاح");
            }
            else
            {
                MessageBox.Show("فشل في عملية الحدف");
            }
        }

        private void btnFrist_Click(object sender, EventArgs e)
        {
            row = 0;
            categoPresenter.getRow(row);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int countRow = Convert.ToInt32(categoPresenter.getLastRow().Rows[0][0]) - 1;
            if (row == 0)
            {
                row = countRow;
            }
            else
            {
                row = row - 1;
            }

            categoPresenter.getRow(row);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int countRow = Convert.ToInt32(categoPresenter.getLastRow().Rows[0][0]);
                if (countRow == row)
                {
                    row = 0;
                }
                else
                {
                    row = row + 1;
                }
                categoPresenter.getRow(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                int countRow = Convert.ToInt32(categoPresenter.getLastRow().Rows[0][0]) - 1;
                row = countRow;
                categoPresenter.getRow(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtDes.Text == "")
            {
                MessageBox.Show("من فظلك المعلومات الناقصة", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool check = categoPresenter.CategoryUpdate();
            if (check)
            {
                MessageBox.Show("تم التعديل بنجاح");
            }
            else
            {
                MessageBox.Show("فشل في عمليةالتعديل");
            }
        }
    }
}