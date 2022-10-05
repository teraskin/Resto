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
        // // ناخد نسخة من IEtablissement
        IFournisseur ifournisseur;

        // تاخد instance 
        FournisseurModel fourModel = new FournisseurModel();

        // الفائدة من كونسركثور اول ما يتم استدعاء الكلاص هادي اول كود يتنفد هو كوسيكثور
        public FournisseurPresenter(IFournisseur view)
        {
            this.ifournisseur = view;
        }
        private void connectBetweenModelInterface()
        {
            fourModel.IdFournisseur = ifournisseur.IdFournisseur;
            fourModel.NomFournisseur = ifournisseur.NomFournisseur;
            fourModel.Activite = ifournisseur.Activite;
            fourModel.NumRegistre = ifournisseur.NumRegistre;
            fourModel.NumFiscal = ifournisseur.NumFiscal;
            fourModel.Adresse = ifournisseur.Adresse;
            fourModel.Telephone = ifournisseur.Telephone;
        }
        // دالة الادخال
        public bool FourInsert()
        {
            connectBetweenModelInterface();
            return FournisseurService.fournisseurInsert(fourModel.IdFournisseur, fourModel.NomFournisseur, fourModel.Activite,
               fourModel.NumRegistre, fourModel.NumFiscal, fourModel.Adresse, fourModel.Telephone);
        }
        // دالة التحدبث

        public bool FourUpdate()
        {
            connectBetweenModelInterface();
            return FournisseurService.fournisseurUpdate(fourModel.IdFournisseur, fourModel.NomFournisseur, fourModel.Activite,
               fourModel.NumRegistre, fourModel.NumFiscal, fourModel.Adresse, fourModel.Telephone);
        }
        // دالة الحدف
        public bool FourDelete()
        {
            connectBetweenModelInterface();
            return FournisseurService.fournisseurDelete(fourModel.IdFournisseur);
        }
        // دالة حدف الكل
        public bool FourDeleteAll()
        {
            connectBetweenModelInterface();
            return FournisseurService.fournisseurDeleteAll();
        }
        public void ClearFields()
        {
            connectBetweenModelInterface();
            ifournisseur.IdFournisseur = 0;
            ifournisseur.NomFournisseur = "";
            ifournisseur.Activite = "";
            ifournisseur.NumRegistre = "";
            ifournisseur.NumFiscal = "";
            ifournisseur.Adresse = "";
            ifournisseur.Telephone = "";
            
        }
    }
}
