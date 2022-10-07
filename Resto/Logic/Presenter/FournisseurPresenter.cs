using Resto.Logic.Services;
using Resto.Models;
using Resto.Views.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Logic.Presenter
{
    class FournisseurPresenter
    {
        // ناخد نسخة من interface
        IFournisseur ifournisseur;

        // تاخد instance 
        FournisseurModel fournisseurModel = new FournisseurModel();
        // الفائدة من كونسركثور اول ما يتم استدعاء الكلاص هادي اول كود يتنفد هو كوسيكثور
        public FournisseurPresenter(IFournisseur view)
        {
            this.ifournisseur = view;
        }
        private void connectBetweenModelInterface()
        {
            fournisseurModel.IdFournisseur = ifournisseur.IdFournisseur;
            fournisseurModel.NomFournisseur = ifournisseur.NomFournisseur;
            fournisseurModel.Activite = ifournisseur.Activite;
            fournisseurModel.NumRegistre = ifournisseur.NumRegistre;
            fournisseurModel.NumFiscal = ifournisseur.NumFiscal;
            fournisseurModel.Adresse = ifournisseur.Adresse;
            fournisseurModel.Telephone = ifournisseur.Telephone;
        }
        public bool FournisseurInsert()
        {
            connectBetweenModelInterface();
            return FournisseurService.fournisseurInsert(fournisseurModel.IdFournisseur, fournisseurModel.NomFournisseur, fournisseurModel.Activite,
               fournisseurModel.NumRegistre, fournisseurModel.NumFiscal, fournisseurModel.Adresse, fournisseurModel.Telephone);
        }

        // دالة التحدبث

        public bool FournisseurUpdate()
        {
            connectBetweenModelInterface();
            return FournisseurService.fournisseurUpdate(fournisseurModel.IdFournisseur, fournisseurModel.NomFournisseur, fournisseurModel.Activite,
               fournisseurModel.NumRegistre, fournisseurModel.NumFiscal, fournisseurModel.Adresse, fournisseurModel.Telephone);
        }
        // دالة الحدف
        public bool FournisseurDelete()
        {
            connectBetweenModelInterface();
            return FournisseurService.fournisseurDelete(fournisseurModel.IdFournisseur);
        }
        // دالة حدف الكل
        public bool FournisseurDeleteAll()
        {
            connectBetweenModelInterface();
            return FournisseurService.fournisseurDeleteAll();
        }

        public void ClearFields()
        {
            connectBetweenModelInterface();
            ifournisseur.IdFournisseur= 0;
            ifournisseur.NomFournisseur= "";
            ifournisseur.Activite = "";
            ifournisseur.NumRegistre = "";
            ifournisseur.NumFiscal = "";
            ifournisseur.Adresse = "";
            ifournisseur.Telephone = "";
           
        }

    }
}
