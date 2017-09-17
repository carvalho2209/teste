using System.Linq;
using System.Web.Mvc;
using Alex.VirtualStore.Dominio.Repositorio;

namespace Alex.VirtualStore.Web.Controllers
{
    public class VitriniController : Controller
    {
        private ProdutosRepositorio _repositorio;
        private int ProdutosProPagina = 3;


        // GET: Vitrini
        public ActionResult ListaProdutos(int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

            var produtos = _repositorio.Produtos
                .OrderBy(v => v.Descricao)
                .Skip((pagina - 1)*ProdutosProPagina)
                .Take(ProdutosProPagina);


            return View(produtos);
        }
    }
}