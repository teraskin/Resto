using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Views.Interface
{
    public interface IEtablissement
    {
         int IdEtablissement { get; set; }
         string Code { get; set; }
         string Designation { get; set; }
         string AmirSarf { get; set; }
         string Gerant { get; set; }
         string Grade { get; set; }
         string Adresse { get; set; }
         string Commune { get; set; }
         string Daira { get; set; }
         string Wilaya { get; set; }
         string Telephone { get; set; }
         string CCP { get; set; }
         string CompteTresor { get; set; }
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
