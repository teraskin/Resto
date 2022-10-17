using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Models
{
    public class ProduitModel
    {
        public int IdProduit { get; set; }
        public string DesProduit { get; set; }
        public float QuantStock { get; set; }
        public float PrixAchat { get; set; }
        
    }
}
