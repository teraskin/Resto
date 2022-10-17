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
    public partial class Frm_Produit : DevExpress.XtraEditors.XtraForm, IProduit
    {
        ProduitPresenter prodPresenter;

        public Frm_Produit()
        {
            InitializeComponent();
            prodPresenter = new ProduitPresenter(this);
        }

        public int IdProduit { get => Convert.ToInt32(txtID.Text); set => txtID.Text = value.ToString(); }
        public string DesProduit { get => Convert.ToString(txtDes.Text); set => txtDes.Text = value.ToString(); }
        public float QuantStock { get => Convert.ToInt32(txtQuant.Text); set => txtQuant.Text = value.ToString(); }
        public float PrixAchat { get => Convert.ToInt32(txtPrixAchat.Text); set => txtPrixAchat.Text = value.ToString(); }
        public object dataGridView { get => Dgv.DataSource; set => Dgv.DataSource = value; }
        int IProduit.row { get => row; set => row = value; }
        object IProduit.btnNew { get => btnNew.Enabled; set => btnNew.Enabled = Convert.ToBoolean(value); }
        object IProduit.btnAdd { get => btnAdd.Enabled; set => btnAdd.Enabled = Convert.ToBoolean(value); }
        object IProduit.btnSave { get => btnSave.Enabled; set => btnSave.Enabled = Convert.ToBoolean(value); }
        object IProduit.btnDelete { get => btnDelete.Enabled; set => btnDelete.Enabled = Convert.ToBoolean(value); }
        object IProduit.btnDeleteAll { get => btnDeleteAll.Enabled; set => btnDeleteAll.Enabled = Convert.ToBoolean(value); }
       

        int row = 0;

        private void Frm_Produit_Load(object sender, EventArgs e)
        {
            prodPresenter.getAllData();
            prodPresenter.AutoNumber();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            prodPresenter.ClearFields();
            prodPresenter.AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDes.Text == "" || txtQuant.Text == "" || txtPrixAchat.Text == "")
            {
                MessageBox.Show("من فظلك المعلومات الناقصة", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool check = prodPresenter.ProduitInsert();
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
            bool check = prodPresenter.ProduitDelete();
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
            bool check = prodPresenter.ProduitDeleteAll();
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
            prodPresenter.getRow(row);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int countRow = Convert.ToInt32(prodPresenter.getLastRow().Rows[0][0]) - 1;
            if (row == 0)
            {
                row = countRow;
            }
            else
            {
                row = row - 1;
            }

            prodPresenter.getRow(row);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int countRow = Convert.ToInt32(prodPresenter.getLastRow().Rows[0][0]);
                if (countRow == row)
                {
                    row = 0;
                }
                else
                {
                    row = row + 1;
                }
                prodPresenter.getRow(row);
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
                int countRow = Convert.ToInt32(prodPresenter.getLastRow().Rows[0][0]) - 1;
                row = countRow;
                prodPresenter.getRow(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDes.Text == "" || txtQuant.Text == "" || txtPrixAchat.Text == "")
            {
                MessageBox.Show("من فظلك المعلومات الناقصة", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool check = prodPresenter.ProduitUpdate();
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