using DevExpress.XtraBars;
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
    public partial class Frm_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_Etablissemnt frm = new Frm_Etablissemnt();
            frm.ShowDialog();

        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_Fournisseur frm = new Frm_Fournisseur();
            frm.ShowDialog();
        }
    }
}