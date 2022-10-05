using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Models
{
    public class FournisseurModel
    {
        public int IdFournisseur { get; set; }
        public string NomFournisseur { get; set; }
        public string Activite { get; set; }
        public string NumRegistre { get; set; }
        public string NumFiscal { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
       
    }
}
