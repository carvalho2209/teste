using System.Linq;
using System.Web.Mvc;
using Alex.VirtualStore.Dominio.Repositorio;
using Alex.VirtualStore.Web.Models;

namespace Alex.VirtualStore.Web.Controllers
{
    public class VitriniController : Controller
    {
        private ProdutosRepositorio _repositorio;
        private int ProdutosProPagina = 8;


        // GET: Vitrini
        public ActionResult ListaProdutos(int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

            var model = new ProdutosViewModel
            {
                Produtos = _repositorio.Produtos
                    .OrderBy(v => v.Descricao)
                    .Skip((pagina - 1)*ProdutosProPagina)
                    .Take(ProdutosProPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosProPagina,
                    ItensTotal =_repositorio.Produtos.Count(),
                }
            };
            
            return View(model);
        }
    }
}