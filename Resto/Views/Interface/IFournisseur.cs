using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Views.Interface
{
    public interface IFournisseur
    {
         int IdFournisseur { get; set; }
         string NomFournisseur { get; set; }
         string Activite { get; set; }
         string NumRegistre { get; set; }
         string NumFiscal { get; set; }
         string Adresse { get; set; }
         string Telephone { get; set; }
    }
}
