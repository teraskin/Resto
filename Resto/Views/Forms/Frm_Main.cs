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

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_Category frm = new Frm_Category();
            frm.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_Produit frm = new Frm_Produit();
            frm.ShowDialog();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_Repas frm = new Frm_Repas();
            frm.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_Menu frm = new Frm_Menu();
            frm.ShowDialog();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_User frm = new Frm_User();
            frm.ShowDialog();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_Plat frm = new Frm_Plat();
            frm.ShowDialog();

        }
    }
}