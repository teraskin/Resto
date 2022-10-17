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
    public partial class Frm_Etablissemnt : DevExpress.XtraEditors.XtraForm, IEtablissement
    {
        // ناخد نسخة
        EtablissementPresenter etabPresenter;

        public int IdEtablissement { get => Convert.ToInt32(txtID.Text); set => txtID.Text = value.ToString(); }
        public string Code { get => Convert.ToString(txtCode.Text); set => txtCode.Text = value.ToString(); }
        public string Designation { get => Convert.ToString(txtDesg.Text); set => txtDesg.Text = value.ToString(); }
        public string AmirSarf { get => Convert.ToString(txtamirSerf.Text); set => txtamirSerf.Text = value.ToString(); }
        public string Gerant { get => Convert.ToString(txtGerant.Text); set => txtGerant.Text = value.ToString(); }
        public string Grade { get => Convert.ToString(txtgrade.Text); set => txtgrade.Text = value.ToString(); }
        public string Adresse { get => Convert.ToString(txtAdressEtablissemnt.Text); set => txtAdressEtablissemnt.Text = value.ToString(); }
        public string Commune { get => Convert.ToString(txtCommune.Text); set => txtCommune.Text = value.ToString(); }
        public string Daira { get => Convert.ToString(txtDaira.Text); set => txtDaira.Text = value.ToString(); }
        public string Wilaya { get => Convert.ToString(txtWilaya.Text); set => txtWilaya.Text = value.ToString(); }
        public string Telephone { get => Convert.ToString(txtNumTel.Text); set => txtNumTel.Text = value.ToString(); }
        public string CCP { get => Convert.ToString(txtCcp.Text); set => txtCcp.Text = value.ToString(); }
        public string CompteTresor { get => Convert.ToString(txtCompteTresore.Text); set => txtCompteTresore.Text = value.ToString(); }
        public object dataGridView { get => Dgv.DataSource; set => Dgv.DataSource = value; }
        int IEtablissement.row { get => row; set => row = value; }
        object IEtablissement.btnNew { get => btnNew.Enabled; set => btnNew.Enabled = Convert.ToBoolean(value); }
        object IEtablissement.btnAdd { get => btnAdd.Enabled; set => btnAdd.Enabled = Convert.ToBoolean(value); }
        object IEtablissement.btnSave { get => btnSave.Enabled; set => btnSave.Enabled = Convert.ToBoolean(value); }
        object IEtablissement.btnDelete { get => btnDelete.Enabled; set => btnDelete.Enabled = Convert.ToBoolean(value); }
        object IEtablissement.btnDeleteAll { get => btnDeleteAll.Enabled; set => btnDeleteAll.Enabled = Convert.ToBoolean(value); }

        int row = 0;

        public Frm_Etablissemnt()
        {
            InitializeComponent();
            etabPresenter = new EtablissementPresenter(this);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Frm_Etablissemnt_Load(object sender, EventArgs e)
        {
            etabPresenter.getAllData();
            etabPresenter.AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtDesg.Text == "" || txtamirSerf.Text == "" || txtGerant.Text == "" || txtgrade.Text == "" 
                || txtCommune.Text == "" || txtAdressEtablissemnt.Text == "" || txtDaira.Text == "" || txtWilaya.Text == "" || txtNumTel.Text == ""
                || txtCcp.Text == "" || txtCompteTresore.Text == "")
            {
                MessageBox.Show("من فظلك أكمل المعلومات الناقصة", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool check = etabPresenter.EtabInsert();
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
            bool check = etabPresenter.EtabDelete();
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
            etabPresenter.ClearFields();
            etabPresenter.AutoNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtDesg.Text == "" || txtamirSerf.Text == "" || txtGerant.Text == "" || txtgrade.Text == ""
                || txtCommune.Text == "" || txtAdressEtablissemnt.Text == "" || txtDaira.Text == "" || txtWilaya.Text == "" || txtNumTel.Text == ""
                || txtCcp.Text == "" || txtCompteTresore.Text == "")
            {
                MessageBox.Show("من فظلك أكمل المعلومات الناقصة", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool check = etabPresenter.EtabUpdate();
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
            bool check = etabPresenter.EtabDeleteAll();
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
                int countRow = Convert.ToInt32(etabPresenter.getLastRow().Rows[0][0]) - 1;
                row = countRow;
                etabPresenter.getRow(row);
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
                int countRow = Convert.ToInt32(etabPresenter.getLastRow().Rows[0][0]);
                if (countRow == row)
                {
                    row = 0;
                }
                else
                {
                    row = row + 1;
                }
                etabPresenter.getRow(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            
            int countRow = Convert.ToInt32(etabPresenter.getLastRow().Rows[0][0]) - 1;
            if (row == 0)
            {
                row = countRow;
            }
            else
            {
                row = row - 1;
            }

            etabPresenter.getRow(row);
        }

        private void btnFrist_Click(object sender, EventArgs e)
        {
            row = 0;
            etabPresenter.getRow(row);
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}