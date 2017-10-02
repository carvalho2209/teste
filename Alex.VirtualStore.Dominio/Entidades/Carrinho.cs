using System;
using System.Collections.Generic;
using System.Linq;

namespace Alex.VirtualStore.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itemCarrinhos = new List<ItemCarrinho>();

        public void AdicionarItem(Produto produto, int quantidade)
        {
            try
            {
                var item = _itemCarrinhos.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

                if (item == null)
                {
                    _itemCarrinhos.Add(new ItemCarrinho
                    {
                        Produto = produto,
                        Quantidade = quantidade
                    });
                }
                else
                {
                    item.Quantidade += quantidade;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoverItem(Produto produto)
        {
            try
            {
                _itemCarrinhos.RemoveAll(p => p.Produto.ProdutoId == produto.ProdutoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public decimal ObterValorTotal()
        {
            try
            {
                return _itemCarrinhos.Sum(v => v.Produto.Preco*v.Quantidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LimparCarrinho()
        {
            try
            {
                _itemCarrinhos.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ItemCarrinho> ItemCarrinhos
        {
            get { return _itemCarrinhos; }
        }
    }
}