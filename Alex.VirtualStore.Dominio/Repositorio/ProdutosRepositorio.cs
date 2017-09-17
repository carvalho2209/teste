using System.Collections.Generic;
using Alex.VirtualStore.Dominio.Entidades;

namespace Alex.VirtualStore.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> Produtos => _context.Produtos;
    }
}
