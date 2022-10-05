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
    class EtablissementPresenter
    {
        // // ناخد نسخة من IEtablissement
        IEtablissement ietablissement;
        // تاخد instance 
        EtablissementModel etabModel = new EtablissementModel();

        // الفائدة من كونسركثور اول ما يتم استدعاء الكلاص هادي اول كود يتنفد هو كوسيكثور
         public EtablissementPresenter(IEtablissement view)
        {
            this.ietablissement = view;
        }

        private void connectBetweenModelInterface()
        {
            etabModel.IdEtablissement = ietablissement.IdEtablissement;
            etabModel.Code = ietablissement.Code;
            etabModel.Designation = ietablissement.Designation;
            etabModel.AmirSarf = ietablissement.AmirSarf;
            etabModel.Gerant = ietablissement.Gerant;
            etabModel.Grade = ietablissement.Grade;
            etabModel.Adresse = ietablissement.Adresse;
            etabModel.Commune = ietablissement.Commune;
            etabModel.Daira = ietablissement.Daira;
            etabModel.Wilaya = ietablissement.Wilaya;
            etabModel.Telephone = ietablissement.Telephone;
            etabModel.CCP = ietablissement.CCP;
            etabModel.CompteTresor = ietablissement.CompteTresor;
        }

        // دالة الادخال
        public bool EtabInsert()
        {
            connectBetweenModelInterface();
            return EtablissementService.etablissementInsert(etabModel.IdEtablissement, etabModel.Code, etabModel.Designation,
               etabModel.AmirSarf, etabModel.Gerant, etabModel.Grade, etabModel.Adresse, etabModel.Commune, etabModel.Daira,
               etabModel.Wilaya, etabModel.Telephone, etabModel.CCP, etabModel.CompteTresor);
        }

        // دالة التحدبث

        public bool EtabUpdate()
        {
            connectBetweenModelInterface();
            return EtablissementService.etablissementUpdate(etabModel.IdEtablissement, etabModel.Code, etabModel.Designation,
               etabModel.AmirSarf, etabModel.Gerant, etabModel.Grade, etabModel.Adresse, etabModel.Commune, etabModel.Daira,
               etabModel.Wilaya, etabModel.Telephone, etabModel.CCP, etabModel.CompteTresor);
        }
        // دالة الحدف
        public bool EtabDelete()
        {
            connectBetweenModelInterface();
            return EtablissementService.etablissementDelete(etabModel.IdEtablissement);
        }
        // دالة حدف الكل
        public bool EtabDeleteAll()
        {
            connectBetweenModelInterface();
            return EtablissementService.etablissementDeleteAll();
        }

        public void ClearFields()
        {
            connectBetweenModelInterface();
            ietablissement.IdEtablissement = 0;
            ietablissement.Code = "";
            ietablissement.Designation = "";
            ietablissement.AmirSarf = "";
            ietablissement.Gerant = "";
            ietablissement.Grade = "";
            ietablissement.Adresse = "";
            ietablissement.Commune = "";
            ietablissement.Daira = "";
            ietablissement.Wilaya = "";
            ietablissement.Telephone = "";
            ietablissement.CCP = "";
            ietablissement.CompteTresor = "";
        }

    }
}
