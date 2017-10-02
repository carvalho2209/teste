using System;
using System.Collections.Generic;
using Alex.VirtualStore.Dominio.Entidades;

namespace Alex.VirtualStore.Web.Models
{
    public class ProdutosViewModel
    {
        public IEnumerable<Produto> Produtos;
        public Paginacao Paginacao { get; set; }
        public String CategoriaAtual { get; set; }
    }
}