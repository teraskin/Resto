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
    public partial class Frm_Repas : DevExpress.XtraEditors.XtraForm, IRepas
    {
        RepasPresenter repaPresenter;

        public Frm_Repas()
        {
            InitializeComponent();
            repaPresenter = new RepasPresenter(this);
        }

        public int IdRepas { get => Convert.ToInt32(txtID.Text); set => txtID.Text = value.ToString(); }
        public string DesRepas { get => Convert.ToString(txtDes.Text); set => txtDes.Text = value.ToString(); }
        public object dataGridView { get => Dgv.DataSource; set => Dgv.DataSource = value; }
        int IRepas.row { get => row; set => row = value; }
        object IRepas.btnNew { get => btnNew.Enabled; set => btnNew.Enabled = Convert.ToBoolean(value); }
        object IRepas.btnAdd { get => btnAdd.Enabled; set => btnAdd.Enabled = Convert.ToBoolean(value); }
        object IRepas.btnSave { get => btnSave.Enabled; set => btnSave.Enabled = Convert.ToBoolean(value); }
        object IRepas.btnDelete { get => btnDelete.Enabled; set => btnDelete.Enabled = Convert.ToBoolean(value); }
        object IRepas.btnDeleteAll { get => btnDeleteAll.Enabled; set => btnDeleteAll.Enabled = Convert.ToBoolean(value); }
        

        int row = 0;

        private void Frm_Repas_Load(object sender, EventArgs e)
        {
            repaPresenter.getAllData();
            repaPresenter.AutoNumber();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            repaPresenter.ClearFields();
            repaPresenter.AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtDes.Text == "" )
            {
                MessageBox.Show("من فظلك المعلومات الناقصة", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool check = repaPresenter.RepasInsert();
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
            bool check = repaPresenter.RepasDelete();
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
            bool check = repaPresenter.RepasDeleteAll();
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
            repaPresenter.getRow(row);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int countRow = Convert.ToInt32(repaPresenter.getLastRow().Rows[0][0]) - 1;
            if (row == 0)
            {
                row = countRow;
            }
            else
            {
                row = row - 1;
            }

            repaPresenter.getRow(row);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int countRow = Convert.ToInt32(repaPresenter.getLastRow().Rows[0][0]);
                if (countRow == row)
                {
                    row = 0;
                }
                else
                {
                    row = row + 1;
                }
                repaPresenter.getRow(row);
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
                int countRow = Convert.ToInt32(repaPresenter.getLastRow().Rows[0][0]) - 1;
                row = countRow;
                repaPresenter.getRow(row);
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

            bool check = repaPresenter.RepasUpdate();
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