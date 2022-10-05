using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Models
{
    public class EtablissementModel
    {
        public int IdEtablissement { get; set; }
        public string Code { get; set; }
        public string Designation { get; set; }
        public string AmirSarf { get; set; }
        public string Gerant { get; set; }
        public string Grade { get; set; }
        public string Adresse { get; set;}
        public string Commune { get; set; }
        public string Daira { get; set; }
        public string Wilaya { get; set; }
        public string Telephone { get; set; }
        public string CCP { get; set; }
        public string CompteTresor { get; set; }

    }
}
