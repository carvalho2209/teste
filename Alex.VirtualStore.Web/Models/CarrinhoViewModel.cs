using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Alex.VirtualStore.Dominio.Entidades;

namespace Alex.VirtualStore.Web.Models
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }
        public string ReturnUrl { get; set; }
    }
}