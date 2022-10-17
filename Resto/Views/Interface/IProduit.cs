using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Views.Interface
{
    public interface IProduit
    {
         int IdProduit { get; set; }
         string DesProduit { get; set; }
         float QuantStock { get; set; }
         float PrixAchat { get; set; }
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
