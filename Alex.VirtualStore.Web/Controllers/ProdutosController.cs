using System.Linq;
using System.Web.Mvc;
using Alex.VirtualStore.Dominio.Repositorio;

namespace Alex.VirtualStore.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutosRepositorio _repositorio;
        //
        // GET: /Produtos/
        public ActionResult Index()
        {
            _repositorio = new ProdutosRepositorio();
            var produtos = _repositorio.Produtos.Take(3);
            
            return View(produtos);
        }
    }
}