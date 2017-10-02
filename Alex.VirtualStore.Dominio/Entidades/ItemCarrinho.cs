using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.VirtualStore.Dominio.Entidades
{
    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
