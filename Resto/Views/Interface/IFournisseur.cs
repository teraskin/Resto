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
         object dataGridView { get; set; }
         int row { get; set; }
        // نعمل كل الازرار المراد التحكم بها  على شكل اوبجي
        object btnNew { get; set; }
        object btnAdd { get; set; }
        object btnSave { get; set; }
        object btnDelete { get; set; }
        object btnDeleteAll { get; set; }
    }
}
