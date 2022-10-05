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
    public partial class Frm_Fournisseur : DevExpress.XtraEditors.XtraForm,IFournisseur
    {
        public Frm_Fournisseur()
        {
            InitializeComponent();

        }

        FournisseurPresenter fourPresenter;
        public int IdFournisseur { get => Convert.ToInt32(txtID.Text); set => txtID.Text = value.ToString(); }
        public string NomFournisseur { get => Convert.ToString(txtNomFour.Text); set => txtNomFour.Text = value.ToString(); }
        public string Activite { get => Convert.ToString(txtActivite.Text); set => txtActivite.Text = value.ToString(); }
        public string NumRegistre { get => Convert.ToString(txtNumRegistre.Text); set => txtNumRegistre.Text = value.ToString(); }
        public string NumFiscal { get => Convert.ToString(txtNumFiscal.Text); set => txtNumFiscal.Text = value.ToString(); }
        public string Adresse { get => Convert.ToString(txtAdress.Text); set => txtAdress.Text = value.ToString(); }
        public string Telephone { get => Convert.ToString(txtTelephone.Text); set => txtTelephone.Text = value.ToString(); }


        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void Frm_F_Load(object sender, EventArgs e)
        {

        }
    }
}