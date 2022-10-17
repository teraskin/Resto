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
    public partial class Frm_Fournisseur : DevExpress.XtraEditors.XtraForm, IFournisseur
    {
        FournisseurPresenter fourniPresenter;

        public Frm_Fournisseur()
        {
            InitializeComponent();
            fourniPresenter = new FournisseurPresenter(this);
        }

        public int IdFournisseur { get => Convert.ToInt32(txtID.Text); set => txtID.Text = value.ToString(); }
        public string NomFournisseur { get => Convert.ToString(txtNomFour.Text); set => txtNomFour.Text = value.ToString(); }
        public string Activite { get => Convert.ToString(txtActivite.Text); set => txtActivite.Text = value.ToString(); }
        public string NumRegistre { get => Convert.ToString(txtNumRegistre.Text); set => txtNumRegistre.Text = value.ToString(); }
        public string NumFiscal { get => Convert.ToString(txtNumFiscal.Text); set => txtNumFiscal.Text = value.ToString(); }
        public string Adresse { get => Convert.ToString(txtAdress.Text); set => txtAdress.Text = value.ToString(); }
        public string Telephone { get => Convert.ToString(txtTelephone.Text); set => txtTelephone.Text = value.ToString(); }
        public object dataGridView { get => Dgv.DataSource; set => Dgv.DataSource = value; }
        int IFournisseur.row { get => row; set => row = value; }
        object IFournisseur.btnNew { get => btnNew.Enabled; set => btnNew.Enabled = Convert.ToBoolean(value); }
        object IFournisseur.btnAdd { get => btnAdd.Enabled; set => btnAdd.Enabled = Convert.ToBoolean(value); }
        object IFournisseur.btnSave { get => btnSave.Enabled; set => btnSave.Enabled = Convert.ToBoolean(value); }
        object IFournisseur.btnDelete { get => btnDelete.Enabled; set => btnDelete.Enabled = Convert.ToBoolean(value); }
        object IFournisseur.btnDeleteAll { get => btnDeleteAll.Enabled; set => btnDeleteAll.Enabled = Convert.ToBoolean(value); }

        int row = 0;

        private void Frm_Fournisseur_Load(object sender, EventArgs e)
        {
            fourniPresenter.getAllData();
            fourniPresenter.AutoNumber();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            fourniPresenter.ClearFields();
            fourniPresenter.AutoNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNomFour.Text == "" || txtActivite.Text == "" || txtNumRegistre.Text == "" || txtNumFiscal.Text == "" ||
                txtAdress.Text == "" || txtTelephone.Text == "")
            {
                MessageBox.Show("من فظلك المعلومات الناقصة", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool check = fourniPresenter.FournisseurInsert();
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
            bool check = fourniPresenter.FournisseurDelete();
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
            bool check = fourniPresenter.FournisseurDeleteAll();
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
            fourniPresenter.getRow(row);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int countRow = Convert.ToInt32(fourniPresenter.getLastRow().Rows[0][0]) - 1;
            if (row == 0)
            {
                row = countRow;
            }
            else
            {
                row = row - 1;
            }

            fourniPresenter.getRow(row);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int countRow = Convert.ToInt32(fourniPresenter.getLastRow().Rows[0][0]);
                if (countRow == row)
                {
                    row = 0;
                }
                else
                {
                    row = row + 1;
                }
                fourniPresenter.getRow(row);
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
                int countRow = Convert.ToInt32(fourniPresenter.getLastRow().Rows[0][0]) - 1;
                row = countRow;
                fourniPresenter.getRow(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNomFour.Text == "" || txtActivite.Text == "" || txtNumRegistre.Text == "" || txtNumFiscal.Text == "" ||
                txtAdress.Text == "" || txtTelephone.Text == "")
            {
                MessageBox.Show("من فظلك المعلومات الناقصة", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool check = fourniPresenter.FournisseurUpdate();
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